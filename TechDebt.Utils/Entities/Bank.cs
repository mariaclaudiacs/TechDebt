using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDebt.Utils.Database;

namespace TechDebt.Utils.Entities
{

    public class Bank
    {
        public Bank(int id)
        {
            Id = id;
        }

        public Bank()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Perfee { get; set; }

        public double VehFee { get; set; }

        public static List<Bank> QuerryAll()
        {
            var list = new List<Bank>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, TJPESSOAL, TJVEICULAR FROM BANCOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        list.Add(new Bank()
                        {
                            Id = id,
                            Nome = reader.GetString(1),
                            Perfee = reader.GetDouble(2),
                            VehFee = reader.GetDouble(3),
                        });
                    }
                }
            }

            return list;
        }
        public void Create()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO BANCOS (ID, NOME, TJPESSOAL, TJVEICULAR) VALUES (NEXT VALUE FOR BANCOS_SEQ, '{Nome}', '{Perfee}', '{VehFee}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE BANCOS SET NOME = '{Nome}', TJPESSOAL = '{Perfee}', TJVEICULAR = '{VehFee}') WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM BANCOS WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
