namespace Servicos.Model
{
    public class ClienteDto
    {
        public int? clie_codigo { get; set; }
        public string clie_nome { get; set; }
        public int clie_idvnc { get; set; }
        public bool clie_status { get; set; }
        public string clie_obs { get; set; }
        public GrupclienteDto grcl_codigo { get; set; }
        public int empr_codigo { get; set; }
        public string usua_nome { get; set; }
    }
}
