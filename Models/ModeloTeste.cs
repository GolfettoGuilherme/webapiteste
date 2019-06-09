using System;

namespace Teste02.Models
{
    public class ModeloTeste
    {
        public string fare_id { get; set;}
        public double price { get; set;}
        public string currency_type { get; set;}
        public string payment_method { get; set;}
        public int transfers { get; set;}
        public double transfer_duration { get; set;}
    }


    public class ModeloDadosLinha
    {
        public string NomeLinha { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string CorLinha { get; set; }

    }

    public class ModeloInfoLinha
    {
        public string idLinha { get; set; }
        public string NomeLinha { get; set; }
    }

    public class ModeloBuscaLinha
    {
        public string idLinha { get; set; }

        public string NomeLinha { get; set; }

        public double MediaPassageiros { get; set; }

        public double MediaPassageirosPagantes { get; set; }

        public double MediaGratuidade { get; set; }

        public double MediaPagEstudante { get; set; }
    }

    public class ModeloExtracao 
    {
        public DateTime datadem { get; set; }
        public string tipo { get; set; }
        public string area { get; set; }
        public string empresa { get; set; }
        public string linha { get; set; }
        public int pass_pgtdin {get; set;}
        public int pass_pgtcomum {get; set;}
        public int pass_pgtbu_comum {get; set;}
        public int pass_pgt_estud {get; set;}
        public int pass_pgtbu_estudm {get; set;}
        public int pass_pgtbu_vt {get; set;}
        public int pass_pgtbu_vtm {get; set;}
        public int pass_pgtint_mcptm {get; set;}
        public int pass_pgtint_mcptmm {get; set;}
        public int pass_pgt {get; set;}
        public int pass_int_onon {get; set;}
        public int pass_grat {get; set;}
        public int pass_grat_estud {get; set;}
        public int total_pass {get; set;}
    }
}