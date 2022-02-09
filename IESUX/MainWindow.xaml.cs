using IESUX.Business;
using IESUX.Models;
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

namespace IESUX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductsBusiness products = new ProductsBusiness();
        public MainWindow()
        {
            InitializeComponent();
            
            ProductDTO product = new ProductDTO();
            product.Id = 11;
            product.Cost = 10.55f;
            product.Description = "wifi router by xiaomi";
            products.Add(product);
            product = new ProductDTO();
            product.Id = 15;
            product.Cost = 14.55f;
            product.Description = "xiaomi";
            products.Add(product);
            product = new ProductDTO();
            product.Id = 11;
            product.Cost = 11.55f;
            product.Description = "xiaomisd";
            products.Edit(product);

            //ProductDTO product = products.Get();


            UsersBusiness users = new UsersBusiness();
            UserDTO user = new UserDTO();
            user.name = "Alberti";
            user.email = "Alberti@gmail.com";
            users.Add(user);
            user = new UserDTO();
            user.name = "berti";
            user.email = "berti@gmail.com";
            users.Add(user);
            user = new UserDTO();
            user.name = "Alberti";
            user.email = "Alberti@gmail.com";
            users.Add(user);
            //UserDTO user = users.Get();
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.ShowDialog();
        }
    }
}
