using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=people;password=1234321;";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();
            // ЗАПРОС на несколько результатов нескольких столбцов
            string sql = "SELECT id, name FROM men WHERE age = 22";

            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
            }
            Console.ReadLine();
            reader.Close();

            /* ЗАПРОС на несколько результатов 1 столбца
            
            string sql = "SELECT name FROM men WHERE age = 22";

            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            Console.ReadLine();
            reader.Close();
            */

            /*  ЗАПРОС на 1 результат 1 столбца
            
            string sql = "SELECT name FROM men WHERE id = 2";

            MySqlCommand command = new MySqlCommand(sql,conn);
            string name = command.ExecuteScalar().ToString();
            Console.WriteLine(name);
            Console.ReadKey();
            */
            conn.Close();
        }
    }
}
