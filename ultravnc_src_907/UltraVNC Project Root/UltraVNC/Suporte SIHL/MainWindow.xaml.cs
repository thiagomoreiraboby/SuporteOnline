using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Suporte_SIHL.Servico;
using System.Collections.ObjectModel;
using Microsoft.Win32;


namespace Suporte_SIHL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private List<ClienteDto> _clientes;
        private ClienteDto _cliente;
        private List<GrupclienteDto> _grupos;
        private GrupclienteDto _grupo;
        private UsuarioDto _usuariologado;
        private Visibility _logar;
        private Visibility _logado;

        public List<ClienteDto> Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged("Clientes");
            }
        }

        public ClienteDto Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        public List<GrupclienteDto> Grupos
        {
            get { return _grupos; }
            set
            {
                _grupos = value;
                OnPropertyChanged("Grupos");
            }
        }

        public GrupclienteDto Grupo
        {
            get { return _grupo; }
            set
            {
                _grupo = value;
                OnPropertyChanged("Grupo");
            }
        }

        public Visibility Logar
        {
            get { return _logar; }
            set
            {
                _logar = value;
                OnPropertyChanged("Logar");
            }
        }

        public Visibility Logado
        {
            get { return _logado; }
            set
            {
                _logado = value;
                OnPropertyChanged("Logado");
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            Logado = Visibility.Collapsed;
            Logar = Visibility.Visible;
        }

        private void carregagrupos()
        {
            using (var proxy = new Servico.ClientesClient())
            {
                Grupos = new List<GrupclienteDto>(proxy.Listargrupo(_usuariologado.empr_codigo).OrderBy(x=> x.grcl_nome));
            } 
        }

        private void Atualizarclientes()
        {
            new Thread(carregagrupos).Start();
            using (var proxy = new Servico.ClientesClient())
            {
                Clientes = new List<ClienteDto>(proxy.Listarcliente(_usuariologado.empr_codigo));

                ListCollectionView lista = new ListCollectionView(Clientes);
                lista.GroupDescriptions.Add(new PropertyGroupDescription("grcl_codigo.grcl_nome"));
                dgcliente.ItemsSource = lista;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Atualizarclientes();
            this.Cursor = Cursors.Arrow;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var conta = e.Row.Item as ClienteDto;
            if (conta != null)
            {
                if (!conta.clie_status)
                {
                    e.Row.IsEnabled = false;
                    // e.Row.FontSize = 10;
                    //e.Row.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    e.Row.IsEnabled = true;
                    e.Row.Foreground = new SolidColorBrush(Colors.Blue);
                    //e.Row.FontSize = 20;
                    //e.Row.Background = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        private void ButtonBase_OnClickconectar(object sender, RoutedEventArgs e)
        {
            if (Cliente != null)
            {
                if (verificarclienteativo(Cliente.clie_idvnc))
                {
                    string app = Environment.CurrentDirectory + @"\sihlviewer";
                    string param = " -proxy 186.202.116.166:16168 ID:" + Cliente.clie_idvnc;
                    System.Diagnostics.Process process = System.Diagnostics.Process.Start(app, param);
                    bloquearcliente(Cliente.clie_idvnc);
                    
                }
                else MessageBox.Show("Cliente ja esta sendo atendido!");

                Atualizarclientes();
            }
        }

        private void bloquearcliente(int p)
        {
            using (var proxy = new Servico.ClientesClient())
            {
                proxy.Bloquearcliente(p, _usuariologado);
            }
        }

        private bool verificarclienteativo(int p)
        {
            using (var proxy = new Servico.ClientesClient())
            {
                return proxy.Clientebloqueado(p);
            }
        }

        private void alterarnomecliente(object sender, RoutedEventArgs e)
        {
            if (Cliente != null)
            {
                if (Cliente.grcl_codigo != null && Cliente.grcl_codigo.grcl_codigo != null)
                {
                    using (var proxy = new ClientesClient())
                    {
                        proxy.Atualizarcliente(Cliente.clie_idvnc, Cliente.clie_nome, Cliente.clie_obs,
                            (int) Cliente.grcl_codigo.grcl_codigo);
                        Atualizarclientes();

                        TabControl1.SelectedIndex = 1;
                    }
                }
            }
        }

        private void addgrupos(object sender, RoutedEventArgs e)
        {
            if (Grupo != null)
            {
                using (var proxy = new ClientesClient())
                {
                    Grupo.empr_codigo = _usuariologado.empr_codigo;
                    proxy.SalvarGrupo(Grupo);
                    Atualizarclientes();
                   
                }
            }
            Grupo = new GrupclienteDto();
        }

        private void deletargrupo(object sender, RoutedEventArgs e)
        {
            if (dggrupos.SelectedItem != null)
            {
                var grup = dggrupos.SelectedItem as GrupclienteDto;
                if (grup.grcl_codigo == 1)
                {
                    MessageBox.Show("Este Grupo não pode ser deletado");
                    return;
                }
                using (var proxy = new ClientesClient())
                {

                    if (proxy.Deletetargrupo((int) grup.grcl_codigo))
                        Atualizarclientes();

                }
            }
        }

        private void entrar_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtlogin.Text) && !string.IsNullOrEmpty(txtsenha.Password))
            {
                using (var proxy = new Servico.ClientesClient())
                {
                    _usuariologado = proxy.Logarusuario(txtlogin.Text, txtsenha.Password);
                    if (_usuariologado.usua_codigo != null && _usuariologado.usua_codigo > 0)
                    {
                        if (_usuariologado.usua_logar)
                        {
                            Atualizarclientes();
                            Grupo = new GrupclienteDto();
                            Logado = Visibility.Visible;
                            Logar = Visibility.Collapsed;
                            TabControl1.SelectedIndex = 1;
                            txtusuario.Text = _usuariologado.usua_nome;
                        }
                        else
                        {
                            MessageBox.Show("Usuário não tem premissão");
                        }
                    }
                }
                
            }
            else MessageBox.Show("Login e senha não pode ficar em branco!");
        }

        private void checkabrirgrupos(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
