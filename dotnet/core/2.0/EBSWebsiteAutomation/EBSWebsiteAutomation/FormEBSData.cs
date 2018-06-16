using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace EBSWebsiteAutomation
{
    public partial class FormEbsData : Form
    {
        public static Navigation NavigationData { get; set; }
        delegate void Operation();

        public FormEbsData()
        {
            InitializeComponent();
        }

        private void FormEBSData_Load(object sender, EventArgs e)
        {
            Navigate();
        }

        private bool _loginCompleted;
        private bool _fieldsCompleted;
        private bool _portalCompleted;
        private bool _menuCompleted;

        private void Navigate()
        {
            Dictionary<string, string> fields = new Dictionary<string, string> { { "perfilCliente", "empresa" },
                                             { "loginEmpresa", ConfigurationManager.AppSettings["ClientLoginA"]},
                                             { "senhaEmpresa", ConfigurationManager.AppSettings["ClientPassA"] } };

            Operation operation = () =>
            {
                if (!_fieldsCompleted)
                    _fieldsCompleted = NavigationData.SetValueManyElements(fields);

                else if (!_loginCompleted)
                    _loginCompleted = NavigationData.SingleElementClick("login-envio-empresa");

                else if (!_portalCompleted)
                {
                    _portalCompleted = NavigationData.SingleElementClickNodes("portal_de_servicos_empresa", new[] { 0 });
                }
                else if (!_menuCompleted)
                {
                    NavigationData.WebBrowser.Navigate(ConfigurationManager.AppSettings["ClientUrlA"] + "cli/asp/cli0011a.asp?p_aux_funcao=DAF&pt=Demonstrativo%20Anal%EDtico%20do%20Faturamento&pprf=EMPRESA_WEB01&pprm=N,N,N,N,N,S&pcf=91.1201&pm=91&pr=N");
                    _menuCompleted = true;
                }
            };

            NavigationData = new Navigation(webBrowser1, ConfigurationManager.AppSettings["ClientUrlA"] + "portal/web/servicos/usuario/cliente/login", operation);
        }
    }
}
