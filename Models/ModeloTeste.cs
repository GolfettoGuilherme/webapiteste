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
}