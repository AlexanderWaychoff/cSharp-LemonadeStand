//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//using System.Data.SqlClient;

//namespace LemonadeStand
//{
//    public partial class Form1
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            //SqlConnection con = new SqlConnection("Data Source=NiluNilesh;Integrated Security=True");  
//            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True");
//            SqlCommand cmd = new SqlCommand("sp_insert", con);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@name", textBox1.Text);
//            cmd.Parameters.AddWithValue("@email", textBox2.Text);
//            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
//            cmd.Parameters.AddWithValue("@address", textBox4.Text);
//            con.Open();
//            int i = cmd.ExecuteNonQuery();

//            con.Close();

//            if (i != 0)
//            {
//                MessageBox.Show(i + "Data Saved");
//            }




//        }

//        public static void main(string[] args)
//        {

//            Application.Run(new Form1());

//        }
//    }
//}