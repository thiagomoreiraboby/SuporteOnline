﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suporte_SIHL.Servico {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClienteDto", Namespace="http://schemas.datacontract.org/2004/07/Servicos.Model")]
    [System.SerializableAttribute()]
    public partial class ClienteDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> clie_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int clie_idvncField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string clie_nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string clie_obsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool clie_statusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int empr_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Suporte_SIHL.Servico.GrupclienteDto grcl_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usua_nomeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> clie_codigo {
            get {
                return this.clie_codigoField;
            }
            set {
                if ((this.clie_codigoField.Equals(value) != true)) {
                    this.clie_codigoField = value;
                    this.RaisePropertyChanged("clie_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int clie_idvnc {
            get {
                return this.clie_idvncField;
            }
            set {
                if ((this.clie_idvncField.Equals(value) != true)) {
                    this.clie_idvncField = value;
                    this.RaisePropertyChanged("clie_idvnc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string clie_nome {
            get {
                return this.clie_nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.clie_nomeField, value) != true)) {
                    this.clie_nomeField = value;
                    this.RaisePropertyChanged("clie_nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string clie_obs {
            get {
                return this.clie_obsField;
            }
            set {
                if ((object.ReferenceEquals(this.clie_obsField, value) != true)) {
                    this.clie_obsField = value;
                    this.RaisePropertyChanged("clie_obs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool clie_status {
            get {
                return this.clie_statusField;
            }
            set {
                if ((this.clie_statusField.Equals(value) != true)) {
                    this.clie_statusField = value;
                    this.RaisePropertyChanged("clie_status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int empr_codigo {
            get {
                return this.empr_codigoField;
            }
            set {
                if ((this.empr_codigoField.Equals(value) != true)) {
                    this.empr_codigoField = value;
                    this.RaisePropertyChanged("empr_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Suporte_SIHL.Servico.GrupclienteDto grcl_codigo {
            get {
                return this.grcl_codigoField;
            }
            set {
                if ((object.ReferenceEquals(this.grcl_codigoField, value) != true)) {
                    this.grcl_codigoField = value;
                    this.RaisePropertyChanged("grcl_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usua_nome {
            get {
                return this.usua_nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.usua_nomeField, value) != true)) {
                    this.usua_nomeField = value;
                    this.RaisePropertyChanged("usua_nome");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GrupclienteDto", Namespace="http://schemas.datacontract.org/2004/07/Servicos.Model")]
    [System.SerializableAttribute()]
    public partial class GrupclienteDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int empr_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool grcl_ativoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> grcl_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string grcl_nomeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int empr_codigo {
            get {
                return this.empr_codigoField;
            }
            set {
                if ((this.empr_codigoField.Equals(value) != true)) {
                    this.empr_codigoField = value;
                    this.RaisePropertyChanged("empr_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool grcl_ativo {
            get {
                return this.grcl_ativoField;
            }
            set {
                if ((this.grcl_ativoField.Equals(value) != true)) {
                    this.grcl_ativoField = value;
                    this.RaisePropertyChanged("grcl_ativo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> grcl_codigo {
            get {
                return this.grcl_codigoField;
            }
            set {
                if ((this.grcl_codigoField.Equals(value) != true)) {
                    this.grcl_codigoField = value;
                    this.RaisePropertyChanged("grcl_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string grcl_nome {
            get {
                return this.grcl_nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.grcl_nomeField, value) != true)) {
                    this.grcl_nomeField = value;
                    this.RaisePropertyChanged("grcl_nome");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioDto", Namespace="http://schemas.datacontract.org/2004/07/Servicos.Model")]
    [System.SerializableAttribute()]
    public partial class UsuarioDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int empr_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> usua_codigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool usua_logarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usua_loginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usua_nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usua_senhaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool usua_statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int empr_codigo {
            get {
                return this.empr_codigoField;
            }
            set {
                if ((this.empr_codigoField.Equals(value) != true)) {
                    this.empr_codigoField = value;
                    this.RaisePropertyChanged("empr_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> usua_codigo {
            get {
                return this.usua_codigoField;
            }
            set {
                if ((this.usua_codigoField.Equals(value) != true)) {
                    this.usua_codigoField = value;
                    this.RaisePropertyChanged("usua_codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool usua_logar {
            get {
                return this.usua_logarField;
            }
            set {
                if ((this.usua_logarField.Equals(value) != true)) {
                    this.usua_logarField = value;
                    this.RaisePropertyChanged("usua_logar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usua_login {
            get {
                return this.usua_loginField;
            }
            set {
                if ((object.ReferenceEquals(this.usua_loginField, value) != true)) {
                    this.usua_loginField = value;
                    this.RaisePropertyChanged("usua_login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usua_nome {
            get {
                return this.usua_nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.usua_nomeField, value) != true)) {
                    this.usua_nomeField = value;
                    this.RaisePropertyChanged("usua_nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usua_senha {
            get {
                return this.usua_senhaField;
            }
            set {
                if ((object.ReferenceEquals(this.usua_senhaField, value) != true)) {
                    this.usua_senhaField = value;
                    this.RaisePropertyChanged("usua_senha");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool usua_status {
            get {
                return this.usua_statusField;
            }
            set {
                if ((this.usua_statusField.Equals(value) != true)) {
                    this.usua_statusField = value;
                    this.RaisePropertyChanged("usua_status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Servico.IClientes")]
    public interface IClientes {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Salvarcliente", ReplyAction="http://tempuri.org/IClientes/SalvarclienteResponse")]
        int Salvarcliente(string nome, int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Salvarcliente", ReplyAction="http://tempuri.org/IClientes/SalvarclienteResponse")]
        System.Threading.Tasks.Task<int> SalvarclienteAsync(string nome, int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Deletetarcliente", ReplyAction="http://tempuri.org/IClientes/DeletetarclienteResponse")]
        bool Deletetarcliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Deletetarcliente", ReplyAction="http://tempuri.org/IClientes/DeletetarclienteResponse")]
        System.Threading.Tasks.Task<bool> DeletetarclienteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Listarcliente", ReplyAction="http://tempuri.org/IClientes/ListarclienteResponse")]
        System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.ClienteDto> Listarcliente(int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Listarcliente", ReplyAction="http://tempuri.org/IClientes/ListarclienteResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.ClienteDto>> ListarclienteAsync(int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Logarusuario", ReplyAction="http://tempuri.org/IClientes/LogarusuarioResponse")]
        Suporte_SIHL.Servico.UsuarioDto Logarusuario(string login, string senha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Logarusuario", ReplyAction="http://tempuri.org/IClientes/LogarusuarioResponse")]
        System.Threading.Tasks.Task<Suporte_SIHL.Servico.UsuarioDto> LogarusuarioAsync(string login, string senha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Usuarioatualizarusuario", ReplyAction="http://tempuri.org/IClientes/UsuarioatualizarusuarioResponse")]
        void Usuarioatualizarusuario(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Usuarioatualizarusuario", ReplyAction="http://tempuri.org/IClientes/UsuarioatualizarusuarioResponse")]
        System.Threading.Tasks.Task UsuarioatualizarusuarioAsync(int codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Bloquearcliente", ReplyAction="http://tempuri.org/IClientes/BloquearclienteResponse")]
        void Bloquearcliente(int id, Suporte_SIHL.Servico.UsuarioDto usuariologado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Bloquearcliente", ReplyAction="http://tempuri.org/IClientes/BloquearclienteResponse")]
        System.Threading.Tasks.Task BloquearclienteAsync(int id, Suporte_SIHL.Servico.UsuarioDto usuariologado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Clientebloqueado", ReplyAction="http://tempuri.org/IClientes/ClientebloqueadoResponse")]
        bool Clientebloqueado(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Clientebloqueado", ReplyAction="http://tempuri.org/IClientes/ClientebloqueadoResponse")]
        System.Threading.Tasks.Task<bool> ClientebloqueadoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Atualizarcliente", ReplyAction="http://tempuri.org/IClientes/AtualizarclienteResponse")]
        void Atualizarcliente(int id, string nome, string obs, int idgrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Atualizarcliente", ReplyAction="http://tempuri.org/IClientes/AtualizarclienteResponse")]
        System.Threading.Tasks.Task AtualizarclienteAsync(int id, string nome, string obs, int idgrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/NomeCliente", ReplyAction="http://tempuri.org/IClientes/NomeClienteResponse")]
        string NomeCliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/NomeCliente", ReplyAction="http://tempuri.org/IClientes/NomeClienteResponse")]
        System.Threading.Tasks.Task<string> NomeClienteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Listargrupo", ReplyAction="http://tempuri.org/IClientes/ListargrupoResponse")]
        System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.GrupclienteDto> Listargrupo(int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Listargrupo", ReplyAction="http://tempuri.org/IClientes/ListargrupoResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.GrupclienteDto>> ListargrupoAsync(int codempresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/SalvarGrupo", ReplyAction="http://tempuri.org/IClientes/SalvarGrupoResponse")]
        void SalvarGrupo(Suporte_SIHL.Servico.GrupclienteDto entidade);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/SalvarGrupo", ReplyAction="http://tempuri.org/IClientes/SalvarGrupoResponse")]
        System.Threading.Tasks.Task SalvarGrupoAsync(Suporte_SIHL.Servico.GrupclienteDto entidade);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Deletetargrupo", ReplyAction="http://tempuri.org/IClientes/DeletetargrupoResponse")]
        bool Deletetargrupo(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IClientes/Deletetargrupo", ReplyAction="http://tempuri.org/IClientes/DeletetargrupoResponse")]
        System.Threading.Tasks.Task<bool> DeletetargrupoAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClientesChannel : Suporte_SIHL.Servico.IClientes, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClientesClient : System.ServiceModel.ClientBase<Suporte_SIHL.Servico.IClientes>, Suporte_SIHL.Servico.IClientes {
        
        public ClientesClient() {
        }
        
        public ClientesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClientesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClientesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Salvarcliente(string nome, int codempresa) {
            return base.Channel.Salvarcliente(nome, codempresa);
        }
        
        public System.Threading.Tasks.Task<int> SalvarclienteAsync(string nome, int codempresa) {
            return base.Channel.SalvarclienteAsync(nome, codempresa);
        }
        
        public bool Deletetarcliente(int id) {
            return base.Channel.Deletetarcliente(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeletetarclienteAsync(int id) {
            return base.Channel.DeletetarclienteAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.ClienteDto> Listarcliente(int codempresa) {
            return base.Channel.Listarcliente(codempresa);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.ClienteDto>> ListarclienteAsync(int codempresa) {
            return base.Channel.ListarclienteAsync(codempresa);
        }
        
        public Suporte_SIHL.Servico.UsuarioDto Logarusuario(string login, string senha) {
            return base.Channel.Logarusuario(login, senha);
        }
        
        public System.Threading.Tasks.Task<Suporte_SIHL.Servico.UsuarioDto> LogarusuarioAsync(string login, string senha) {
            return base.Channel.LogarusuarioAsync(login, senha);
        }
        
        public void Usuarioatualizarusuario(int codigo) {
            base.Channel.Usuarioatualizarusuario(codigo);
        }
        
        public System.Threading.Tasks.Task UsuarioatualizarusuarioAsync(int codigo) {
            return base.Channel.UsuarioatualizarusuarioAsync(codigo);
        }
        
        public void Bloquearcliente(int id, Suporte_SIHL.Servico.UsuarioDto usuariologado) {
            base.Channel.Bloquearcliente(id, usuariologado);
        }
        
        public System.Threading.Tasks.Task BloquearclienteAsync(int id, Suporte_SIHL.Servico.UsuarioDto usuariologado) {
            return base.Channel.BloquearclienteAsync(id, usuariologado);
        }
        
        public bool Clientebloqueado(int id) {
            return base.Channel.Clientebloqueado(id);
        }
        
        public System.Threading.Tasks.Task<bool> ClientebloqueadoAsync(int id) {
            return base.Channel.ClientebloqueadoAsync(id);
        }
        
        public void Atualizarcliente(int id, string nome, string obs, int idgrupo) {
            base.Channel.Atualizarcliente(id, nome, obs, idgrupo);
        }
        
        public System.Threading.Tasks.Task AtualizarclienteAsync(int id, string nome, string obs, int idgrupo) {
            return base.Channel.AtualizarclienteAsync(id, nome, obs, idgrupo);
        }
        
        public string NomeCliente(int id) {
            return base.Channel.NomeCliente(id);
        }
        
        public System.Threading.Tasks.Task<string> NomeClienteAsync(int id) {
            return base.Channel.NomeClienteAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.GrupclienteDto> Listargrupo(int codempresa) {
            return base.Channel.Listargrupo(codempresa);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Suporte_SIHL.Servico.GrupclienteDto>> ListargrupoAsync(int codempresa) {
            return base.Channel.ListargrupoAsync(codempresa);
        }
        
        public void SalvarGrupo(Suporte_SIHL.Servico.GrupclienteDto entidade) {
            base.Channel.SalvarGrupo(entidade);
        }
        
        public System.Threading.Tasks.Task SalvarGrupoAsync(Suporte_SIHL.Servico.GrupclienteDto entidade) {
            return base.Channel.SalvarGrupoAsync(entidade);
        }
        
        public bool Deletetargrupo(int id) {
            return base.Channel.Deletetargrupo(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeletetargrupoAsync(int id) {
            return base.Channel.DeletetargrupoAsync(id);
        }
    }
}
