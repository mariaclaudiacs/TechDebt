using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDebt.Utils.Database
{
    public class DBInfo
    {
        /// <summary>
        /// Data Source: Origem de dados -> Servidor
        /// Initial Catalog: Base de dados que apontamos
        /// User: Usuário de login no banco
        /// Password: Senha de login no banco
        /// </summary>
        public const string DBConnection = @"Data Source=BUE206D03\SQLEXPRESS;Initial catalog=DadosMTM;User=sa;Password=Senac@2021;";
        //public const string DBConnection = @"Data Source=BUE205D017\SQLEXPRESS;Initial catalog=TechStudents_DB;User=sa;Password=Senac@2021;Trusted_Connection=True;";

        public static void TestarBanco()
        {
            using (var conn = new SqlConnection(DBConnection))
            {
                var cmd = new SqlCommand("SELECT * FROM USUARIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[1]}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
