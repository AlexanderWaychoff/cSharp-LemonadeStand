using System;
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
        DataTable dt;
        public SQL()
        {
            //string strProject = ".\\SQLExpress;"; //Enter your SQL server instance name
            //string strDatabase = "User Instance=true;"; //Enter your database name
            //string strUserID = "Integrated Security=true;"; // Enter your SQL Server User Name
            //string strPassword = "testPassword"; // Enter your SQL Server Password

            //string strconn = "Data Source=.\\SQLExpress;" +
            //    "User Instance=true;" +
            //    "Integrated Security=true;" +
            //    "AttachDbFilename=|DataDirectory|Database1.mdf;";

            //string strconn = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\\HighScores.mdf; Integrated Security = True";
            string strconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Andross\\Desktop\\school_projects\\C#\\LemonadeStand\\LemonadeStand\\HighScores.mdf;Integrated Security=True";
            conn = new SqlConnection(strconn);
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\HighScores.mdf; Integrated Security = True
            
            //"Data Source=" + strProject +
            //  ";Persist Security Info=false;database=" + strDatabase +
            //  ";user id=" + strUserID + ";password=" +
            //  strPassword + ";Connection Timeout = 0";
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
            Console.WriteLine("1. " + dt.Rows[0][1].ToString() + " with score: " + dt.Rows[0][2].ToString());
            Console.WriteLine("2. " + dt.Rows[1][1].ToString() + " with score: " + dt.Rows[1][2].ToString());
            Console.WriteLine("3. " + dt.Rows[2][1].ToString() + " with score: " + dt.Rows[2][2].ToString());
            Console.WriteLine("4. " + dt.Rows[3][1].ToString() + " with score: " + dt.Rows[3][2].ToString());
            Console.WriteLine("5. " + dt.Rows[4][1].ToString() + " with score: " + dt.Rows[4][2].ToString());
        }
        public void SubmitHighScore()
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
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
