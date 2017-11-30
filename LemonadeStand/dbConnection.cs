using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class dbConnection
    {
        public dbConnection()
        {
            string strProject = "YourServer"; //Enter your SQL server instance name
            string strDatabase = "YourDatabase"; //Enter your database name
            string strUserID = "testUser"; // Enter your SQL Server User Name
            string strPassword = "testPassword"; // Enter your SQL Server Password
            string strconn = "data source=" + strProject +
              ";Persist Security Info=false;database=" + strDatabase +
              ";user id=" + strUserID + ";password=" +
              strPassword + ";Connection Timeout = 0";
            //conn = new SqlConnection(strconn);
        }
    }
}
