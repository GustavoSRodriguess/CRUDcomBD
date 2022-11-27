using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace perdeuMane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Mane> listaManes = new List<Mane>();

        public MainWindow()
        {
            InitializeComponent();


            listaManes.Add(new Mane() { Codigo = 1, Nome = "Jorge", Email = "jorge@gmail.com", Celular = "(47)9962822" });
            listaManes.Add(new Mane() { Codigo = 2, Nome = "Felipe", Email = "Felipe@gmail.com", Celular = "(48)9948521" });
            listaManes.Add(new Mane() { Codigo = 3, Nome = "Sales", Email = "Sales@gmail.com", Celular = "(47)94821637" });

            DTGmanes.ItemsSource = listaManes;
            DTGmanes.Items.Refresh();
        }




        private void BTNgravar_Click(object sender, RoutedEventArgs e)
        {
            if (TBXcodigo.IsEnabled == true)
            {
                // trata-se de um cadastro
                listaManes.Add(
                    new Mane()
                    {
                        Codigo = Convert.ToInt16(TBXcodigo.Text),
                        Nome = TBXnome.Text,
                        Email = TBXemail.Text,
                        Celular = TBXcelular.Text
                    });
            }
            else
            {
                // trata-se de uma edição
                int x;
                for(x=0; x<listaManes.Count; x++)
                {
                    if (listaManes[x].Codigo.ToString() == TBXcodigo.Text)
                    {
                        break;
                    }
                }

                listaManes[x].Nome = TBXnome.Text;
                listaManes[x].Email = TBXemail.Text;
                listaManes[x].Celular = TBXcelular.Text;
            }

            DTGmanes.Items.Refresh();

            ativarNavegacao();
        }


        private void BTNcadastrar_Click(object sender, RoutedEventArgs e)
        {
            ativarEdicao();

            TBXcodigo.Text = "";
            TBXnome.Text = "";
            TBXemail.Text = "";
            TBXcelular.Text = "";

            TBXcodigo.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DTGmanes.CanUserAddRows = false;
            DTGmanes.CanUserDeleteRows = false;

            selecionarRegistro();
            ativarNavegacao();
        }


        private void ativarNavegacao()
        {
            // desativar o formulario
            TBXcodigo.IsEnabled = false;
            TBXnome.IsEnabled = false;
            TBXemail.IsEnabled = false;
            TBXcelular.IsEnabled = false;
            BTNgravar.IsEnabled = false;
            BTNcancelar.IsEnabled = false;

            // ativa o datagrid e os botões de operação
            BTNalterar.IsEnabled = true;
            BTNcadastrar.IsEnabled = true;
            BTNapagar.IsEnabled = true;
            DTGmanes.IsEnabled = true;
            DTGmanes.Focus();
        }


        private void ativarEdicao()
        {
            // ativar o formulario
            TBXcodigo.IsEnabled = true;
            TBXnome.IsEnabled = true;
            TBXemail.IsEnabled = true;
            TBXcelular.IsEnabled = true;
            BTNgravar.IsEnabled = true;
            BTNcancelar.IsEnabled = true;

            // desativa o datagrid e os botões de operação
            BTNalterar.IsEnabled = false;
            BTNcadastrar.IsEnabled = false;
            BTNapagar.IsEnabled = false;
            DTGmanes.IsEnabled = false;
        }

        private void BTNcancelar_Click(object sender, RoutedEventArgs e)
        {
            ativarNavegacao();
        }



        private void selecionarRegistro()
        {
            if (listaManes.Count > 0)
            {
                DTGmanes.SelectedIndex = 0;
            }
        }

        private void DTGmanes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DTGmanes.SelectedIndex >= 0)
            {
                Mane m = (Mane)DTGmanes.Items[DTGmanes.SelectedIndex];
                
                TBXcodigo.Text = m.Codigo.ToString();
                TBXnome.Text = m.Nome;
                TBXemail.Text = m.Email;
                TBXcelular.Text = m.Email;
            }
        }

        private void BTNalterar_Click(object sender, RoutedEventArgs e)
        {
            ativarEdicao();
            TBXcodigo.IsEnabled = false;
            TBXnome.Focus();
        }
    }
}
