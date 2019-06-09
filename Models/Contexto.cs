using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Teste02.Models
{
    public class Contexto
    {
        public string ConnectionString {get; set;}

        public Contexto(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        } 

        public User InsertUser(User user)
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO users(username,password) VALUES(@username, @password);select last_insert_id();",conn);
                cmd.Parameters.AddWithValue("@username",user.username);
                cmd.Parameters.AddWithValue("@password", user.password);

                user.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return user;
        }
        public List<User> GetUsers()
        {
            List<User> list = new List<User>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read()){
                            list.Add(new User()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                username = reader["username"].ToString(),
                                password = reader["password"].ToString()
                            });
                        }
                    }
                }

            }

            return list;
        }
    }
}