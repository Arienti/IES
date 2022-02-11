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
        private ProductsBusiness products = null;
        private CategoriesBusiness categories = new CategoriesBusiness();
        public MainWindow()
        {
            products = new ProductsBusiness(categories);


            InitializeComponent();

            //test -----------
            CategoryDTO category = new CategoryDTO();
            category.Id = 1;
            category.Name = "First";
            categories.Add(category);

            category = new CategoryDTO();
            category.Id = 2;
            category.Name = "Second";
            categories.Add(category);

            //----------------

            GridView gridView = new GridView(); 
            ProductsListView.View = gridView;
  
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Category Id",
                DisplayMemberBinding = new Binding("CategoryId")
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

            foreach (ProductDTO product in productsDTO.Items)
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
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.AddMode = false;
            pruductDialogWindow.ID.IsReadOnly = true;
            pruductDialogWindow.Owner = this;

            GridView gridView= new GridView();

            ProductDTO product = ProductsListView.SelectedItem as ProductDTO;
            pruductDialogWindow.ID.Text = product.Id.ToString();
            pruductDialogWindow.Description.Text = product.Description.ToString();
            pruductDialogWindow.Cost.Text = product.Cost.ToString();
            
            if (pruductDialogWindow.ShowDialog() == true)
            {
                RefreshProductsList();
            }
        }
    }
}
