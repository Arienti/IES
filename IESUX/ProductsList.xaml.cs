using IESUX.Business;
using IESUX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Page
    {
        private ProductsBusiness products = null;
        private CategoriesBusiness categories = new CategoriesBusiness();


        public ProductsList()
        {
            products = new ProductsBusiness(categories);
            InitializeComponent();

            /* GridView gridView = new GridView();
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
             });*/
            RefreshCategoryList();

            List<CategoryDTO> categoriesList = categories.Get();
            if ((categoriesList != null) && (categoriesList.Count != 0))
            {
                RefreshProductsList(categoriesList[0].CategoryId);
            }
            

        }
        private void RefreshProductsList(int categoryId)
        {
            ProductsDTO productsDTO = products.GetByCategoryId(categoryId);
            productList.Items.Clear();
            foreach (ProductDTO product in productsDTO.Items)
            {
                productList.Items.Add(product);
            }
        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO productDTO = productList.SelectedItem as ProductDTO;
            ResultDTO resultDTO = products.Delete(productDTO);

            List<CategoryDTO> categoriesList = categories.Get();
            if ((categoriesList != null) && (categoriesList.Count != 0))
            {
                RefreshProductsList(categoriesList[0].CategoryId);
            }

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            //pruductDialogWindow.Owner = this;
            List<CategoryDTO> categoriesDTO = categories.Get();
            pruductDialogWindow.categoryList.Items.Clear();
            foreach (CategoryDTO category in categoriesDTO)
            {
                pruductDialogWindow.categoryList.Items.Add(category);
            }
            if (pruductDialogWindow.ShowDialog() == true)
            {
                List<CategoryDTO> categoriesList = categories.Get();
                if ((categoriesList != null) && (categoriesList.Count != 0))
                {
                    RefreshProductsList(categoriesList[0].CategoryId);
                }

            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            PruductDialogWindow pruductDialogWindow = new PruductDialogWindow(products);
            pruductDialogWindow.AddMode = false;
            pruductDialogWindow.Title = "Edit Product";
            
            //  pruductDialogWindow.Owner = this;
            List<CategoryDTO> categoriesDTO = categories.Get();
            pruductDialogWindow.categoryList.Items.Clear();
            foreach (CategoryDTO category in categoriesDTO)
            {
                pruductDialogWindow.categoryList.Items.Add(category);
            }
            ProductsList productsList = new ProductsList();
            ProductDTO product = productList.SelectedItem as ProductDTO;
            pruductDialogWindow.ID.Text = product.Id.ToString();
            pruductDialogWindow.Description.Text = product.Description.ToString();
            pruductDialogWindow.Cost.Text = product.Cost.ToString();

            if (pruductDialogWindow.ShowDialog() == true)
            {
                List<CategoryDTO> categoriesList = categories.Get();
                if ((categoriesList != null) && (categoriesList.Count != 0))
                {
                    RefreshProductsList(categoriesList[0].CategoryId);
                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO product = productList.SelectedItem as ProductDTO;
            ResultDTO resultDTO = products.Delete(product);
            ProductsDTO productsDTO = new ProductsDTO();

            List<CategoryDTO> categoriesList = categories.Get();
            if ((categoriesList != null) && (categoriesList.Count != 0))
            {
                RefreshProductsList(categoriesList[0].CategoryId);
            }

        }
        private void RefreshCategoryList()
        {
            List<CategoryDTO> categoriesDTO = categories.Get();
            categoryList.Children.Clear();

            foreach (CategoryDTO category in categoriesDTO)
            {
                ListItem listItem = new ListItem();
                listItem.ItemName.Text = category.CategoryName;
                listItem.PreviewMouseDown += ListItem_MouseDown;
                listItem.Tag = category;

                categoryList.Children.Add(listItem);
            }
        }

        private void ListItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListItem listItem = sender as ListItem;
            CategoryDTO category = listItem.Tag as CategoryDTO;
            RefreshProductsList(category.CategoryId);
        }
    }
}



