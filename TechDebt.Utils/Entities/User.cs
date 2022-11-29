using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechDebt.Utils.Database;

namespace TechDebt.Utils.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
  

        public User(int id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMAIL, SENHA FROM USUARIOS WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        Email = reader.GetString(2);
                        Senha = reader.GetString(3);
                    
                    }
                }
            }
         }
        public User()
        {
        }

        public static List<User> QuerryAll()
        {
            var list = new List<User>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMAIL, SENHA FROM USUARIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        list.Add(new User()
                        {
                            Id = id,
                            Nome = reader.GetString(1),
                            Email = reader.GetString(2),
                            Senha = reader.GetString(3),
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
                var cmd = new SqlCommand($"INSERT INTO USUARIOS (ID, NOME, EMAIL, SENHA) VALUES (NEXT VALUE FOR USUARIOS_SEQ, '{Nome}', '{Email}', '{GenerateHash(Senha)}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE USUARIOS SET NOME = '{Nome}', EMAIL = '{Email}', SENHA = '{GenerateHash(Senha)}') WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM USUARIOS WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public static string GenerateHash(string text)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(text);

            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }

                return hashedInputStringBuilder.ToString();
            }
        }

    }
}
