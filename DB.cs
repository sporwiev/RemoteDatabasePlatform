using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Seva
{
    internal class DB
    { //ОТкрываешь MAMP там открываешь Open WebStart Page шаходишь там данные после этих переменных server port и тд , на сайте ты увидешь Host это ыукмук если что, database ты увидишь после того как перейдешь по ссылке "phpmyadmin" на той страничке, далее создашь базу назови ее лучше registers чтобы не менять данные в коде таблицу создай строго как у меня чтобы все было норм//
      //

        public MySqlConnection conn = new MySqlConnection($"server=localhost;port=3306;username=root;password=root;database=users");
         
        
        public void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            
           


        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

        }
        public MySqlConnection getConnection()
        {
            return conn;
        }
        
    }
}
