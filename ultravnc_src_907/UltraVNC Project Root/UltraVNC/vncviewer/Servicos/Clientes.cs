using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using Servicos.Contratos;
using Servicos.Model;

namespace Servicos
{
    public partial class Service : IClientes
    {

        public Service()
        {
            if (!_rodando)
            {
                _rodando = true;
                //new Thread(() =>
                //{
                //    while (_rodando)
                //    {
                //        Thread.Sleep(60000);
                //        Usuarioadesativar();
                //    }
                //}).Start();
            }
        }
        private const string Connectionstring =
            "Server=186.202.116.166;Database=suporteremoto;User=postgres;Password=thiago;Port=5432";

        private static bool _rodando = false;

        public int Salvarcliente(string nome, int codempresa)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans  = conn.BeginTransaction())
                {
                    try
                    {
                        int id;
                        using (var cmd = new NpgsqlCommand("SELECT MIN(PORT_VNC) FROM PORTAS WHERE PORT_VNC NOT iN(SELECT CLIE_IDVNC FROM CLIENTE)", conn, trans))
                        {
                           id = int.Parse(cmd.ExecuteScalar().ToString());
                            
                        }
                        using (
                            var cmd =
                                new NpgsqlCommand(
                                    "INSERT INTO cliente (clie_nome,clie_idvnc, empr_codigo) values ('" + nome + "'," + id + ","+codempresa+")", conn,
                                    trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            return id;
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
        }

        public void SalvarGrupo(GrupclienteDto entidade)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (
                            var cmd =
                                new NpgsqlCommand(
                                    "INSERT INTO grupcliente (grcl_nome, grcl_ativo,empr_codigo) values ('" + entidade.grcl_nome + "'," + entidade.grcl_ativo + ","+entidade.empr_codigo+")", conn,
                                    trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        public void Atualizarcliente(int id, string nome, string obs, int idgrupo)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (
                            var cmd =
                                new NpgsqlCommand(
                                    "update cliente set clie_nome = '" + nome + "', clie_obs = '" + obs + "', grcl_codigo = "+idgrupo+" where clie_idvnc = " + id, conn,
                                    trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        public string NomeCliente(int id)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();

                try
                {
                    using (var cmd = new NpgsqlCommand("select clie_nome from cliente where clie_idvnc = " + id, conn))
                    {
                        return cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public bool Deletetarcliente(int id)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand("delete from cliente where clie_idvnc = "+id, conn, trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Deletetargrupo(int id)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand("update cliente set grcl_codigo = 1 where grcl_codigo = " + id, conn, trans))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new NpgsqlCommand("delete from grupcliente where grcl_codigo = " + id, conn, trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Clientebloqueado(int id)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();

                    try
                    {
                        using (var cmd = new NpgsqlCommand("select clie_status from cliente where clie_idvnc = " + id, conn))
                        {
                            return bool.Parse(cmd.ExecuteScalar().ToString());
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
        }

        public void Bloquearcliente(int id, UsuarioDto usuariologado)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new NpgsqlCommand("update cliente set clie_status = false, usua_codigo = "+usuariologado.usua_codigo+" where clie_idvnc = " + id, conn, trans))
                        {
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        public List<GrupclienteDto> Listargrupo(int codempresa)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("select * from grupcliente where empr_codigo = " + codempresa, conn))
                    {
                        var dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        return RetonagrupclienteDtos(dt);
                    }
                }
                catch (Exception)
                {
                    return new List<GrupclienteDto>();
                }
            }
        }

        private static List<GrupclienteDto> RetonagrupclienteDtos(DataTable dt)
        {
            var lista = new List<GrupclienteDto>();
            foreach (DataRow item in dt.AsEnumerable().ToList())
            {
                var grup = new GrupclienteDto()
                {
                    grcl_codigo = (int)item["grcl_codigo"],
                    grcl_nome = item["grcl_nome"].ToString(),
                    grcl_ativo = (bool)item["grcl_ativo"]
                };

                lista.Add(grup);
            }
            return lista;
        }

        public List<ClienteDto> Listarcliente(int codempresa)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("select * from cliente inner join grupcliente on cliente.grcl_codigo = grupcliente.grcl_codigo" +
                                                       " left outer join usuario on cliente.usua_codigo = usuario.usua_codigo" +
                                                       " where cliente.empr_codigo = " + codempresa, conn))
                    {
                        var dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        return RetonaClienteDtos(dt);
                    }
                }
                catch (Exception)
                {
                    return new List<ClienteDto>();
                }
            }
        }
        
        private static List<ClienteDto> RetonaClienteDtos(DataTable dt)
        {
            var lista = new List<ClienteDto>();
            foreach (DataRow item in dt.AsEnumerable().ToList())
            {

                var clie = new ClienteDto();
                clie.clie_codigo = (int) item["clie_codigo"];
                clie.clie_nome = item["clie_nome"].ToString();
                clie.clie_idvnc = (int) item["clie_idvnc"];
                clie.clie_status = (bool) item["clie_status"];
                clie.clie_obs = item["clie_obs"].ToString();
                clie.usua_nome = item["usua_nome"].ToString();
                clie.grcl_codigo = new GrupclienteDto()
                {
                    grcl_codigo = (int)item["grcl_codigo"],
                    grcl_nome = item["grcl_nome"].ToString(),
                    grcl_ativo = (bool)item["grcl_ativo"]
                };
                lista.Add(clie);
            }
            return lista;
        }

        public UsuarioDto Logarusuario(string login, string senha)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    int id;
                    using (
                        var cmd =
                            new NpgsqlCommand(
                                "SELECT * FROM usuario wHERE usua_login Ilike '" + login +
                                "' and usua_senha = '" + senha + "'", conn))
                    {
                        var dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        UsuarioDto usua = new UsuarioDto();
                        foreach (DataRow item in dt.AsEnumerable().ToList())
                        {
                            usua = new UsuarioDto()
                            {
                                usua_codigo = (int)item["usua_codigo"],
                                usua_login = item["usua_login"].ToString(),
                                usua_senha = item["usua_senha"].ToString(),
                                usua_nome = item["usua_nome"].ToString(),
                                //usua_status = (bool)item["usua_status"],
                                empr_codigo = (int)item["empr_codigo"],
                                //usua_logar = (bool)item["usua_logar"]
                            };
                        }
                        return usua;

                        
                    }
                }
                catch (Exception)
                {
                    return new UsuarioDto();
                }
            }
        }

        public void Usuarioatualizarusuario(int codigo)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    int id;
                    using (
                        var cmd =
                            new NpgsqlCommand(
                                "update usuario set usua_status = true where usua_codigo = " + codigo + "", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void Usuarioadesativar()
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    int id;
                    using (
                        var cmd =
                            new NpgsqlCommand(
                                "update usuario set usua_status = false", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
    
}
