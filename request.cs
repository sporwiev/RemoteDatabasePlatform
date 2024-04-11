using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seva
{
    public class request
    {
        
        
        public int countColumn(string dbname, string table)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"SHOW COLUMNS FROM {table};", db.getConnection());
            db.OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read()) 
            {
                i++;        
            }
            reader.Close();
            db.CloseConnection();
            return i;
        }
        public string typecolumn(string dbname, string tablename,string column_name)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand($"USE {dbname}; DESC {tablename}", db.getConnection());
            db.OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while(reader.Read())
            {
                //list.Add(reader.GetString("Field"));
                //list.Add(reader.GetString("Type"));
                if (reader.GetString("Field").ToString() == column_name)
                {
                    return reader.GetString("Type").ToString();
                }
            }

            reader.Close();
            db.CloseConnection();
            return null;
            
        }
    }
}
