using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDebt.Utils.Database;

namespace TechDebt.Utils.Entities
{
    public class Consortium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string BornBirth { get; set; }
        public string Category { get; set; }


        public Consortium(int id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, NUMERO, EMAIL, CEP, CPF, DATANASCIMENTO, CATEGORIA WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        Name = reader.GetString(1);
                        Number = reader.GetString(2);
                        Email = reader.GetString(3);
                        CEP = reader.GetString(4);
                        CPF = reader.GetString(5);
                        Category = reader.GetString(6);
                        BornBirth = reader.GetString(7);
                    }
                }
            }
        }

        public Consortium()
        {
        }

        public static List<Consortium> QuerryAll()
        {
            var list = new List<Consortium>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, NUMERO, EMAIL, CEP, CPF, DATANASCIMENTO, CATEGORIA FROM CONSORCIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        list.Add(new Consortium()
                        {
                            Id = id,
                            Name = reader.GetString(2),
                            Number = reader.GetString(3),
                            Email = reader.GetString(4),
                            CEP = reader.GetString(5),
                            CPF = reader.GetString(6),
                            Category = reader.GetString(7),
                            BornBirth = reader.GetString(8)
                            
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
                var cmd = new SqlCommand($"INSERT INTO CONSORCIOS (ID, NOME, NUMERO, EMAIL, CEP, CPF, DATANASCIMENTO, CATEGORIA) VALUES (NEXT VALUE FOR CONSORCIOS_SEQ, '{Name}','{Number}', '{Email}', '{CEP}', '{CPF}', '{BornBirth}', '{Category}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE CONSORCIOS SET NOME = '{Name}', NUMERO = '{Number}', EMAIL = '{Email}', CEP = '{CEP}', CPF = '{CPF}', DATANASCIMENTO = '{BornBirth}', CATEGORIA = '{Category}' WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM CONSORCIOS WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
