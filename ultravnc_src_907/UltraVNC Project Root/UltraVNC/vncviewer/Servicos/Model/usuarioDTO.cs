namespace Servicos.Model
{
    public class UsuarioDto
    {
        public int? usua_codigo { get; set; }
        public string usua_login { get; set; }
        public string usua_senha { get; set; }
        public string usua_nome { get; set; }
        //public bool usua_status { get; set; }
       // public bool usua_logar { get; set; }
        public int empr_codigo { get; set; }
    }
}
