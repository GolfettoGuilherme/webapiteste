using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste02.Models;

namespace Teste02.Controllers
{
    public class ContextoSql
    {
        //nao dava tempo de colocar em um lugar mais seguro, vai que vai 
        private string ConnectionString = "Server=tcp:hackathon-sampa-14.database.windows.net,1433;Initial Catalog=hackathon_db;Persist Security Info=False;User ID=admin-banco-hack;Password=(beba2cafe5);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<ModeloDadosLinha> GetLinha(string idLinha)
        {
            List<ModeloDadosLinha> lista = new List<ModeloDadosLinha>();

            string SQLRaw = "spSelGetRotas @idLinha";
            
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SQLRaw,conn))
                {

                    cmd.Parameters.AddWithValue("@idLinha", idLinha);
                    
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            lista.Add(new ModeloDadosLinha()
                            {
                                NomeLinha = reader["NomeLinha"].ToString(),

                                Latitude = Convert.ToDouble(reader["Latitude"].ToString()) / 1000000,

                                Longitude = Convert.ToDouble(reader["Longitude"].ToString()) / 1000000,

                                CorLinha = reader["CorLinha"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
        public ModeloInfoLinha GetDadosLinha(string texto)
        {
            ModeloInfoLinha model = new ModeloInfoLinha();
            string SQLRaw = "spSelGetLinha @texto";

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(SQLRaw,conn))
                {
                    cmd.Parameters.AddWithValue("@texto",texto);

                    using(var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read()){
                            model.idLinha = reader["route_id"].ToString();
                            model.NomeLinha = reader["route_long_name"].ToString();
                        }
                    }
                }
            }

            return model;
        }
    
        public ModeloBuscaLinha spSelBuscaLinha(string idlinha, DateTime dataInicio, DateTime dataFim)
        {
            var model = new ModeloBuscaLinha();

            string SQLRaw = "spSelBuscaLinha @idLinha, @dataInicio, @dataFim";

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SQLRaw,conn))
                {
                    cmd.Parameters.AddWithValue("@idLinha", idlinha);
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);

                    using(var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            model.idLinha = idlinha;
                            model.NomeLinha = reader["NomeLinha"].ToString();
                            model.MediaPassageiros = Convert.ToDouble(reader["Mediapassageiros"].ToString());
                            model.MediaPassageirosPagantes = Convert.ToDouble(reader["MediaPassageirosPagantes"].ToString());
                            model.MediaGratuidade = Convert.ToDouble(reader["MediaGratuidade"].ToString());
                            model.MediaPagEstudante = Convert.ToDouble(reader["MediaPagEstudante"].ToString());
                        }
                    }
                }
            }
            return model;
        }
    
        public List<ModeloExtracao> Extracao(string idlinha, DateTime dataInicio, DateTime dataFim)
        {
            List<ModeloExtracao> lista = new List<ModeloExtracao>();

            string sqlRaw = "spSelExtracao @idlinha, @datamin,@dataMax";

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(sqlRaw, conn))
                {
                    cmd.Parameters.AddWithValue("@idlinha", idlinha);
                    cmd.Parameters.AddWithValue("@datamin", dataInicio);
                    cmd.Parameters.AddWithValue("@dataMax",dataFim);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            lista.Add(new ModeloExtracao(){
                                datadem = Convert.ToDateTime(reader["datadem"]),
                                tipo = reader["tipo"].ToString(),
                                area = reader["area"].ToString(),
                                empresa = reader["empresa"].ToString(),
                                linha = reader["linha"].ToString(),
                                pass_pgtdin = Convert.ToInt32(reader["pass_pgtdin"]),
                                pass_pgtcomum = Convert.ToInt32(reader["pass_pgtcomum"]),
                                pass_pgtbu_comum = Convert.ToInt32(reader["pass_pgtbu_comum"]),
                                pass_pgt_estud = Convert.ToInt32(reader["pass_pgt_estud"]),
                                pass_pgtbu_estudm = Convert.ToInt32(reader["pass_pgtbu_estudm"]),
                                pass_pgtbu_vt = Convert.ToInt32(reader["pass_pgtbu_vt"]),
                                pass_pgtbu_vtm = Convert.ToInt32(reader["pass_pgtbu_vtm"]),
                                pass_pgtint_mcptm = Convert.ToInt32(reader["pass_pgtint_mcptm"]),
                                pass_pgtint_mcptmm = Convert.ToInt32(reader["pass_pgtint_mcptmm"]),
                                pass_pgt = Convert.ToInt32(reader["pass_pgt"]),
                                pass_int_onon = Convert.ToInt32(reader["pass_int_onon"]),
                                pass_grat = Convert.ToInt32(reader["pass_grat"]),
                                pass_grat_estud = Convert.ToInt32(reader["pass_grat_estud"]),
                                total_pass = Convert.ToInt32(reader["total_pass"])

                            });
                        }
                    }
                }
            }
        
            return lista;
        }
    }
}