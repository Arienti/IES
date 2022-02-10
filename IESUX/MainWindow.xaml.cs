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
    /// Main window class 
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductsBusiness products = new ProductsBusiness();
        public MainWindow()
        {
            InitializeComponent();


            GridView gridView = new GridView();

            ProductsListView.View = gridView;

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Description",
                DisplayMemberBinding = new Binding("Description")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Cost",
                DisplayMemberBinding = new Binding("Cost")
            });

            RefreshProductsList();
        }

        private void RefreshProductsList()
        {
            ProductsDTO productsDTO = products.Get();

            ProductsListView.Items.Clear();

            foreach(ProductDTO product in productsDTO.Items)
            {
                ProductsListView.Items.Add(product);
            }


        }


        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.Owner = this;

            if (pruductDialogWindow.ShowDialog() == true)
            {
                RefreshProductsList();
            }
        }
    }
}
