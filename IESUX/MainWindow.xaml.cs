using IESUX.Business;
using IESUX.Models;
using IESUX.Repository;
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
using static IESUX.MainWindow;

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
            products = new ProductsBusiness(categories); ;
            InitializeComponent();

            //test -----------
            /* CategoryDTO category = new CategoryDTO();
             category.Id = 1;
             category.Name = "First";
             categories.Add(category);
             category = new CategoryDTO();
             category.Id = 5;
             category.Name = "Second";
             categories.Add(category);

             category = new CategoryDTO();
             category.Id = 1;
             category.Name = "Second";
             categories.Add(category);
            */
            //----------------

            GridView gridView = new GridView();
            ProductsListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Category Id",
                DisplayMemberBinding = new Binding("CategoryId")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Category Name",
                DisplayMemberBinding = new Binding("CategoryName")
            });

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
            RefreshCategoryList();
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
        private void RefreshCategoryList()
        {
            List<CategoryDTO> categoriesDTO = categories.Get();
            ProductsListView.Items.Clear();
            
            foreach (CategoryDTO category in categoriesDTO)
            {
             ProductsListView.Items.Add(category);
            }
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.Owner = this;
            List<CategoryDTO> categoriesDTO = categories.Get();
            pruductDialogWindow.categoryList.Items.Clear();
            foreach (CategoryDTO category in categoriesDTO)
            {
                pruductDialogWindow.categoryList.Items.Add(category);  
            }
            if (pruductDialogWindow.ShowDialog() == true)
            {
                RefreshProductsList();
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.AddMode = false;
            pruductDialogWindow.Title = "Edit Product";
            pruductDialogWindow.ID.IsReadOnly = true;
            pruductDialogWindow.Owner = this;
            List<CategoryDTO> categoriesDTO = categories.Get();
            pruductDialogWindow.categoryList.Items.Clear();
            foreach (CategoryDTO category in categoriesDTO)
            {
                pruductDialogWindow.categoryList.Items.Add(category);
            }

            ProductDTO product = ProductsListView.SelectedItem as ProductDTO;
                pruductDialogWindow.ID.Text = product.Id.ToString();
                pruductDialogWindow.Description.Text = product.Description.ToString();
                pruductDialogWindow.Cost.Text = product.Cost.ToString();

            if (pruductDialogWindow.ShowDialog() == true)
            {
                RefreshProductsList();
            }
        }
        
        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(categories);
            categoryWindow.Title = "Add Category";
            categoryWindow.Owner = this;

            if (categoryWindow.ShowDialog() == true)
            {
               RefreshCategoryList();
            }
        }
        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(categories);
            categoryWindow.Owner = this;
            categoryWindow.Title = "Edit Category";
            
            categoryWindow.AddMode = false;
            categoryWindow.CategoryID.IsReadOnly = true;
            

            CategoryDTO categoryDTO = ProductsListView.SelectedItem as CategoryDTO;
            categoryWindow.CategoryID.Text = categoryDTO.CategoryId.ToString();
            categoryWindow.CategoryName.Text = categoryDTO.CategoryName.ToString();

            if (categoryWindow.ShowDialog() == true)
            {
                RefreshCategoryList();
            }    
        }
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryDTO category = ProductsListView.SelectedItem as CategoryDTO;
            ResultDTO resultDTO = categories.Delete(category);
            ProductsListView.Items.Remove(category);
            RefreshCategoryList();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO productDTO = ProductsListView.SelectedItem as ProductDTO;
            ResultDTO resultDTO = products.Delete(productDTO);
            RefreshProductsList();
        }
    }
}
