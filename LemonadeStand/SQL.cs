﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LemonadeStand
{
public class SQL
    {
        public SqlConnection conn;
        public SqlTransaction transaction;
        public SqlDataAdapter sda;
        public SqlCommandBuilder scb;
        public SqlCommand cmd;
        DataTable dt;
        public SQL()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\HighScores.mdf;Integrated Security=True";
            conn = new SqlConnection(strconn);

        }
        public void ObtainHighScores()
        {
            conn.Close();
            conn.Open();
            sda = new SqlDataAdapter("SELECT * FROM HighScore ORDER BY score DESC", conn);
            //transaction = conn.BeginTransaction("SELECT * FROM HighScore");
            dt = new DataTable();
            sda.Fill(dt);
            Console.WriteLine("TOP 5 SCORES");
            Console.WriteLine("1. " + dt.Rows[0][1].ToString() + " played " + dt.Rows[0][2].ToString() + " days with a score of: " + dt.Rows[0][3].ToString());
            Console.WriteLine("2. " + dt.Rows[1][1].ToString() + " played " + dt.Rows[1][2].ToString() + " days with a score of: " + dt.Rows[1][3].ToString());
            Console.WriteLine("3. " + dt.Rows[2][1].ToString() + " played " + dt.Rows[2][2].ToString() + " days with a score of: " + dt.Rows[2][3].ToString());
            Console.WriteLine("4. " + dt.Rows[3][1].ToString() + " played " + dt.Rows[3][2].ToString() + " days with a score of: " + dt.Rows[3][3].ToString());
            Console.WriteLine("5. " + dt.Rows[4][1].ToString() + " played " + dt.Rows[4][2].ToString() + " days with a score of: " + dt.Rows[4][3].ToString());
        }
        public void SubmitHighScore(Player player, Inventory userInventory, int gameDays)
        {
            string highScore = "INSERT INTO dbo.HighScore VALUES(@Name, @Days, @Score);";
            using (SqlConnection openCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Andross\\Desktop\\school_projects\\C#\\LemonadeStand\\LemonadeStand\\HighScores.mdf;Integrated Security=True"))
            {
                using (SqlCommand querySaveStaff = new SqlCommand(highScore))
                {
                    openCon.Open();
                    querySaveStaff.Connection = openCon;
                    querySaveStaff.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = player.Name;
                    querySaveStaff.Parameters.Add("@Days", SqlDbType.Int).Value = gameDays;
                    querySaveStaff.Parameters.Add("@Score", SqlDbType.Float).Value = userInventory.OverallProfit;

                    querySaveStaff.ExecuteNonQuery();
                    
                }
            }
        }
        public void CloseConnection()
        {
            conn.Close();
        }
        public void CommitConnection()
        {

        }
        public void RollbackTransaction()
        {
            transaction.Rollback();
            conn.Close();
        }
    }
}
