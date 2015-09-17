using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Forms;
using Npgsql;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.MessageBox;

namespace GerenciadorSuporte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Connectionstring =
            "Server=186.202.116.166;Database=suporteremoto;User=postgres;Password=thiago;Port=5432";

        private NotifyIcon MyNotifyIcon;

        private string _momedoservico = "SihlSuporte";

        public static bool VerificaProgramaEmExecucao()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;
        }

        public MainWindow()
        {
            if (VerificaProgramaEmExecucao())
            {
                MessageBox.Show("Programa já está executando!");
                Close();
            }
            InitializeComponent();
            try
            {
                MyNotifyIcon = new NotifyIcon();
                MyNotifyIcon.Icon = new Icon(Environment.CurrentDirectory + @"\suporte.ico");
                MyNotifyIcon.MouseDoubleClick +=
                    new MouseEventHandler
                        (MyNotifyIcon_MouseDoubleClick);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            btninstalar.IsEnabled = false;
            btnremova.IsEnabled = false;
            btnstart.IsEnabled = false;
            btnStop.IsEnabled = false;
            txtnomepc.IsEnabled = false;
            Loaded += Window_Loaded;

            
        }

        void MyNotifyIcon_MouseDoubleClick(object sender,MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                MyNotifyIcon.BalloonTipTitle = "Sihl Suporte";
                MyNotifyIcon.BalloonTipText = "Sihl Suporte";
                MyNotifyIcon.ShowBalloonTip(400);
                MyNotifyIcon.Visible = true;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                MyNotifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private int _idvnc;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdministrator())
            {
                if (!string.IsNullOrEmpty(txtlogin.Text) && !string.IsNullOrEmpty(txtsenha.Password))
                {
                    var idempresa = Logarusuario(txtlogin.Text, txtsenha.Password);
                    if (idempresa > 0)
                    {
                        if (!string.IsNullOrEmpty(txtnomepc.Text))
                        {

                            try
                            {

                                    _idvnc = Salvarcliente(txtnomepc.Text, idempresa);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao pegar id: " + ex);
                            }

                            
                            if (_idvnc > 999)
                            {
                                try
                                {
                                    if (InstallService(_idvnc))
                                    {
                                        try
                                        {
                                            GravarConfiguracao("idvnc", _idvnc.ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("erro ao gravar o idvnc" + ex);
                                        }
                                        
                                        txtnomepc.IsEnabled = false;
                                        txtlogin.Text = string.Empty;
                                        txtsenha.Password = string.Empty;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro: " + ex.Message);
                                }
                            }
                            else MessageBox.Show("idvnc gerado incorreto");
                        }
                        else MessageBox.Show("Preencha o nome do computador");

                    }
                    else MessageBox.Show("Usuário sem permissão\nEntre em contato com o Suporte SIHL");
                }
                else MessageBox.Show("Login e senha não pode ficar em branco\nEntre em contato com o suporte da Sihl");
            }
            else MessageBox.Show("Sem premissão de Administrador");
        }

        public static void GravarConfiguracao(string chave, string valor)
        {
            try
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config1.AppSettings.Settings[chave].Value = valor;
                config1.Save(ConfigurationSaveMode.Minimal);
            }
            catch (Exception ex)
            {

                MessageBox.Show("erro grava informaçoes" + ex);
                throw;
            }
            
        }

        public void StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (service.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    btnstart.IsEnabled = false;
                    btnStop.IsEnabled = true;
                }
                else MessageBox.Show("Serviço já está em execução");
            }
            catch
            {
                // ...
            }
        }

        public void StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                if ((service.Status.Equals(ServiceControllerStatus.Running)) ||
                    (service.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    btnstart.IsEnabled = true;
                    btnStop.IsEnabled = false;
                }
                else MessageBox.Show("Serviço já está parado");
            }
            catch
            {
                // ...
            }
        }

        public bool InstallService(int Idcliente)
        {
            try
            {
                string reg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "reg.exe");

                Process process1;
                process1 = new Process();
                process1.StartInfo.FileName = reg;
                process1.StartInfo.Arguments = @"add HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v SoftwareSASGeneration /t REG_DWORD /d 1 /f";
                process1.Start();
                process1.WaitForExit();
                 }
            catch(Exception ex)
            {
                MessageBox.Show("erro chave do registro: " + ex);
                return false;
            }
            try
            {
                Process process;
                process = new Process();
                process.StartInfo.FileName = Environment.CurrentDirectory + @"\winvnc.exe";
                process.StartInfo.Arguments = " -install -sc_prompt -sc_exit -id:" + Idcliente +
                                              " -autoreconnect -connect 186.202.116.166:3478";
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Execite pelo vnc");
                btninstalar.IsEnabled = false;
                btnremova.IsEnabled = true;
                btnstart.IsEnabled = false;
                btnStop.IsEnabled = true;
                return true;
            }
            catch (Exception ex)
            {
                //
                try
                {
                    var InstallUtil = @"C:\Windows\System32\sc.exe";
                    var exe = "\"" + Environment.CurrentDirectory + @"\winvnca.exe -sc_prompt -sc_exit -id:"+Idcliente+" -connect 186.202.116.166:3478 -autoreconnect -service\"";
                    string param = " create " + _momedoservico + " binPath= " + exe + "  start= auto";
                    var process = new Process();
                    process.StartInfo.FileName = InstallUtil;
                    process.StartInfo.Arguments = param;
                    process.Start();
                    process.WaitForExit();
                    StartService(_momedoservico);
                    return true;

                }
                catch
                {
                    return false;
                }
            }
        }

        public void RemoveService(string ServiceName)
        {
            try
            {
                var InstallUtil = @"C:\Windows\System32\sc.exe";
                string param = @"delete " +ServiceName;

                Process process = Process.Start(InstallUtil, param);
                btninstalar.IsEnabled = true;
                btnremova.IsEnabled = false;
                btnstart.IsEnabled = false;
                btnStop.IsEnabled = false;
            }
            catch
            {
                // ...
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StartService(_momedoservico);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtlogin.Text) && !string.IsNullOrEmpty(txtsenha.Password))
            {
                var idempresa = Logarusuario(txtlogin.Text, txtsenha.Password);
                if (idempresa > 0)
                {
                    StopService(_momedoservico);
                }
            }
        
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtlogin.Text) && !string.IsNullOrEmpty(txtsenha.Password))
            {
                var idempresa = Logarusuario(txtlogin.Text, txtsenha.Password);
                if (idempresa > 0)
                {
                    RemoveService(_momedoservico);
                    if (_idvnc > 999)
                    {
                        try
                        {
                            Deletetarcliente(_idvnc);
                            txtnomepc.IsEnabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            var service = new ServiceController(_momedoservico);
            try
            {
                btninstalar.IsEnabled = false;
                btnremova.IsEnabled = true;
                if (service.Status == ServiceControllerStatus.Running)
                {
                    _idvnc = int.Parse(ConfigurationSettings.AppSettings["idvnc"]);
                    txtnomepc.Text = pegarnomecliente(_idvnc);
                    btnStop.IsEnabled = true;
                    btnstart.IsEnabled = false;
                }
                else
                {
                    btnStop.IsEnabled = false;
                    btnstart.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                txtnomepc.IsEnabled = true;
                btninstalar.IsEnabled = true;
                btnremova.IsEnabled = false;
            }
        }

        private string pegarnomecliente(int id)
        {
            try
            {

                return NomeCliente(id);
            }
            catch (Exception ex)
            {

                MessageBox.Show("erro ao pegar nome: " + ex);
                return "";

            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (
                MessageBox.Show("Deseja minimizar a aplicaçao\n se cancelar será fechada", "Aviso!",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                e.Cancel = true;
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                e.Cancel = false;
                Environment.Exit(0);

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();

            if (null != identity)
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }

        public int Salvarcliente(string nome, int codempresa)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Connectionstring))
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
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
                                        "INSERT INTO cliente (clie_nome,clie_idvnc, empr_codigo) values ('" + nome + "'," + id + "," + codempresa + ")", conn,
                                        trans))
                            {
                                cmd.ExecuteNonQuery();
                                trans.Commit();
                                return id;
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Erro ao salvar cliente: " + ex);
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar para salvar cliente: " + ex);
                return 0;
            }
            
        }

        public int Logarusuario(string login, string senha)
        {
            using (var conn = new NpgsqlConnection(Connectionstring))
            {
                conn.Open();
                try
                {
                    int id = 0;
                    using (
                        var cmd =
                            new NpgsqlCommand(
                                "SELECT empr_codigo FROM usuario wHERE usua_login Ilike '" + login +
                                "' and usua_senha = '" + senha + "'", conn))
                    {
                        var dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        
                        foreach (DataRow item in dt.AsEnumerable().ToList())
                        {


                            id = (int) item[0];

                        }
                        return id;


                    }
                }
                catch (Exception)
                {
                    return 0;
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
                        using (var cmd = new NpgsqlCommand("delete from cliente where clie_idvnc = " + id, conn, trans))
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

    }
}
