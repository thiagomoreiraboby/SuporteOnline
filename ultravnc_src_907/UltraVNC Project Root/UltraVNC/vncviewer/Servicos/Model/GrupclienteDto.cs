namespace Servicos.Model
{
    public class GrupclienteDto
    {
        public GrupclienteDto() { }


        public int? grcl_codigo { get; set; }
        public string grcl_nome { get; set; }
        public bool grcl_ativo { get; set; }
        public int empr_codigo { get; set; }
    }
}
