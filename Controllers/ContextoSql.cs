using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste02.Models;

namespace Teste02.Controllers
{
    public class ContextoSql
    {
        private string ConnectionString = "Server=tcp:hackathon-sampa-14.database.windows.net,1433;Initial Catalog=hackathon_db;Persist Security Info=False;User ID=admin-banco-hack;Password=(beba2cafe5);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private SqlConnection GetConnection(){
            return new SqlConnection(ConnectionString);
        } 

        public List<ModeloTeste> GetLinha()
        {
            List<ModeloTeste> lista = new List<ModeloTeste>();
            
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM gs_fare_attributes",conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            lista.Add(new ModeloTeste()
                            {
                                currency_type = reader["currency_type"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}