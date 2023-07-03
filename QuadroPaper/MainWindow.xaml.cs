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
using System.Data.SqlClient;
using System.Data;

namespace QuadroPaper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private List<Product> products;
        private List<Material> materials;
        private List<Production> productions;

        public int totalPages;
        public int curPage;
        public int pageSize;

        private double savedScaleX;
        private double savedScaleY;

        public MainWindow()
        {
            InitializeComponent();

            pageSize = 20;
        }

        private void DB_Load(object sender, RoutedEventArgs e)
        {
            string a = @"Server = DESKTOP-UQ9O0DO; Database = house; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(a))
            {
                connection.Open();

                SqlCommand commandProd = new SqlCommand("SELECT * FROM products_b_import$", connection);
                SqlCommand commandMaterial = new SqlCommand("SELECT * FROM ProdMats", connection);
                SqlCommand commandProduction = new SqlCommand("SELECT * FROM Production", connection);

                SqlDataAdapter adapterProd = new SqlDataAdapter(commandProd);
                SqlDataAdapter adapterMaterial = new SqlDataAdapter(commandMaterial);
                SqlDataAdapter adapterProduction = new SqlDataAdapter(commandProduction);

                DataTable dtProd = new DataTable();
                DataTable dtMaterial = new DataTable();
                DataTable dtProduction = new DataTable();

                adapterProd.Fill(dtProd);
                adapterMaterial.Fill(dtMaterial);
                adapterProduction.Fill(dtProduction);

                products = new List<Product>();
                materials = new List<Material>();
                productions = new List<Production>();

                foreach (DataRow rows in dtProd.Rows)
                {
                    Product product = new Product()
                    {
                        ProdName = rows["Наименование продукции"].ToString(),
                        ArticleNum = Convert.ToInt32(rows["Артикул"]),
                        MinPriceForAgent = Convert.ToInt32(rows["Минимальная стоимость для агента"]),
                        Image = rows["Изображение"].ToString(),
                        ProdType = rows["Тип продукции"].ToString(),
                        PeopleCount = Convert.ToInt32(rows["Количество человек для производства"]),
                        ProdNum = Convert.ToInt32(rows["Номер для производства"])
                    };

                    products.Add(product);
                }

                foreach (DataRow rows in dtMaterial.Rows)
                {
                    Material material = new Material()
                    {
                        MaterialName = rows["Наименование материала"].ToString(),
                        MaterialType = rows["Тип материала"].ToString(),
                        CountInPack = Convert.ToInt32(rows["Количество в упаковке"]),
                        Unity = rows["Единица измерения"].ToString(),
                        CountOnStock = Convert.ToInt32(rows["Количество на складе"]),
                        MinPosBalance = Convert.ToInt32(rows["Минимальный возможный остаток"]),
                        Price = Convert.ToInt32(rows["Стоимость"])
                    };

                    materials.Add(material);
                }

                foreach (DataRow rows in dtProduction.Rows)
                {
                    Production production = new Production()
                    {
                        Products = rows["Продукция"].ToString(),
                        MaterialName = rows["Наименование материала"].ToString(),
                        RequiredAmountMaterial = Convert.ToInt32(rows["Необходимое количество материала"])
                    };

                    productions.Add(production);
                }

            }

            curPage = 1;
            totalPages = (int)Math.Ceiling((double)products.Count / pageSize);

            Button1.TextDecorations = TextDecorations.Underline;

            if (products != null && products.Count > 0)
            {
                products = products.OrderBy(p => p.ProdName).ToList();
            }

            if (products != null && products.Count > 0)
            {
                var productTypes = products.Select(p => p.ProdType).Distinct().ToList();
                foreach (var type in productTypes)
                {
                    FilterCB.Items.Add(new ComboBoxItem() { Content = type });
                }
            }

            UpdateListView(products);
            DisplayCurPage();
        }

        private void DisplayCurPage()
        {
            int startIndex = (curPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize - 1, products.Count - 1);

            if (products == null || !products.Any())
            {
                return;
            }

            LV.Items.Clear();

            for (int i = startIndex; i <= endIndex; i++)
            {
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.Margin = new Thickness(0, 5, 0, 5);
                border.BorderThickness = new Thickness(1);
                border.Width = 760;
                border.Height = 95;
                border.HorizontalAlignment = HorizontalAlignment.Center;

                StackPanel stackPanelOut = new StackPanel();
                stackPanelOut.Orientation = Orientation.Horizontal;

                Image image = new Image();
                if (products[i].Image != "отсутствует")
                {
                    image.Source = new BitmapImage(new Uri(products[i].Image, UriKind.Relative));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri("picture.png", UriKind.Relative));
                }
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Center;
                image.Margin = new Thickness(15, 0, 0, 0);
                image.Width = 76;
                image.Height = 76;

                StackPanel stackPanelInner = new StackPanel();
                stackPanelInner.Orientation = Orientation.Vertical;

                TextBlock nameTB = new TextBlock();
                nameTB.Text = products[i].ProdType + " | " + products[i].ProdName;
                nameTB.Margin = new Thickness(30, 5, 0, 0);
                nameTB.Width = 500;
                nameTB.Height = 25;
                nameTB.FontSize = 16;
                nameTB.FontWeight = FontWeights.SemiBold;

                TextBlock articleTB = new TextBlock();
                articleTB.Text = products[i].ArticleNum.ToString();
                articleTB.Margin = new Thickness(30, 0, 0, 0);
                articleTB.Width = 500;
                articleTB.Height = 25;
                articleTB.FontSize = 14;

                TextBlock materialsTB = new TextBlock();
                materialsTB.Text = "Материалы: " + GetMaterialsForProduct(products[i].ProdName);
                materialsTB.Margin = new Thickness(30, 0, 0, 0);
                materialsTB.Width = 500;
                materialsTB.Height = 40;
                materialsTB.FontSize = 12;
                materialsTB.HorizontalAlignment = HorizontalAlignment.Left;
                materialsTB.TextWrapping = TextWrapping.Wrap;

                StackPanel stackPanelForPrice = new StackPanel();
                stackPanelForPrice.Orientation = Orientation.Horizontal;

                TextBlock priceTB = new TextBlock();
                priceTB.Text = products[i].MinPriceForAgent.ToString() + " ₽";
                priceTB.Margin = new Thickness(40, 10, 0, 0);
                priceTB.Width = 90;
                priceTB.Height = 40;
                priceTB.FontSize = 14;
                priceTB.HorizontalAlignment = HorizontalAlignment.Right;
                priceTB.VerticalAlignment = VerticalAlignment.Top;

                stackPanelInner.Children.Add(nameTB);
                stackPanelInner.Children.Add(articleTB);
                stackPanelInner.Children.Add(materialsTB);

                stackPanelForPrice.Children.Add(priceTB);

                stackPanelOut.Children.Add(image);
                stackPanelOut.Children.Add(stackPanelInner);
                stackPanelOut.Children.Add(stackPanelForPrice);

                border.Child = stackPanelOut;

                LV.Items.Add(border);
            }

        }

        private void ButtonPageClick(object sender, RoutedEventArgs e)
        {
            TextBlock clckbtn = (TextBlock)sender;
            int clkcPage = int.Parse(clckbtn.Text);

            curPage = clkcPage;

            Console.WriteLine(totalPages);

            if (curPage > 3)
            {
                Button4.Text = curPage.ToString();
                Button3.Text = (Int32.Parse(Button4.Text) - 1).ToString();
                Button2.Text = (Int32.Parse(Button3.Text) - 1).ToString();
                Button1.Text = (Int32.Parse(Button2.Text) - 1).ToString();
            }

            if (curPage == 3 & Int32.Parse(Button4.Text) >= 5)
            {
                Button1.Text = "1";
                Button2.Text = "2";
                Button3.Text = curPage.ToString();
                Button4.Text = "4";
            }

            if (curPage == 2 & Int32.Parse(Button4.Text) >= 5)
            {
                Button1.Text = "1";
                Button2.Text = curPage.ToString();
                Button3.Text = "3";
                Button4.Text = "4";
            }

            UpdatePages();
            DisplayCurPage();
        }

        private void PrevPageButtonClick(object sender, RoutedEventArgs e)
        {
            if (curPage > 1)
            {
                curPage--;

                if ((curPage < totalPages) && (curPage != 1 & curPage != 2 & curPage != 3))
                {
                    Button1.Text = (Int32.Parse(Button1.Text) - 1).ToString();
                    Button2.Text = (Int32.Parse(Button2.Text) - 1).ToString();
                    Button3.Text = (Int32.Parse(Button3.Text) - 1).ToString();
                    Button4.Text = (Int32.Parse(Button4.Text) - 1).ToString();
                }

                if (curPage == 3 & Int32.Parse(Button4.Text) >= 5)
                {
                    Button1.Text = "1";
                    Button2.Text = "2";
                    Button3.Text = curPage.ToString();
                    Button4.Text = "4";
                }

                if (curPage == 2 & Int32.Parse(Button4.Text) >= 5)
                {
                    Button1.Text = "1";
                    Button2.Text = curPage.ToString();
                    Button3.Text = "3";
                    Button4.Text = "4";
                }

                UpdatePages();
                DisplayCurPage();
            }
        }

        private void NextPageButtonClick(object sender, RoutedEventArgs e)
        {
            if (curPage < totalPages)
            {
                curPage++;
                if (curPage > 4)
                {
                    Button1.Text = (Int32.Parse(Button1.Text) + 1).ToString();
                    Button2.Text = (Int32.Parse(Button2.Text) + 1).ToString();
                    Button3.Text = (Int32.Parse(Button3.Text) + 1).ToString();
                    Button4.Text = (Int32.Parse(Button4.Text) + 1).ToString();
                }

                UpdatePages();
                DisplayCurPage();
            }
        }

        private void UpdatePages()
        {
            Button1.TextDecorations = null;
            Button2.TextDecorations = null;
            Button3.TextDecorations = null;
            Button4.TextDecorations = null;

            if (Int32.Parse(Button1.Text) == curPage)
            {
                Button1.TextDecorations = TextDecorations.Underline;
            }
            else if (Int32.Parse(Button2.Text) == curPage)
            {
                Button2.TextDecorations = TextDecorations.Underline;
            }
            else if (Int32.Parse(Button3.Text) == curPage)
            {
                Button3.TextDecorations = TextDecorations.Underline;
            }
            else if (Int32.Parse(Button4.Text) == curPage)
            {
                Button4.TextDecorations = TextDecorations.Underline;
            }
        }

        private void TB_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TB_Search.Text.ToLower();

            if (products != null)
            {
                List<Product> filteredProducts = products.Where(p => p.ProdName.ToLower().Contains(searchText)
                                                    || p.ArticleNum.ToString().Contains(searchText)
                                                    || p.ProdType.ToLower().Contains(searchText)
                                                    || GetMaterialsForProduct(p.ProdName).ToLower().Contains(searchText)
                                                    || p.MinPriceForAgent.ToString().Contains(searchText))
                                                .ToList();

                UpdateListView(filteredProducts);
            }
        }

        private void UpdateListView(List<Product> filteredProducts)
        {
            LV.Items.Clear();

            foreach (Product product in filteredProducts)
            {
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.Margin = new Thickness(0, 5, 0, 5);
                border.BorderThickness = new Thickness(1);
                border.Width = 760;
                border.Height = 95;
                border.HorizontalAlignment = HorizontalAlignment.Center;

                StackPanel stackPanelOut = new StackPanel();
                stackPanelOut.Orientation = Orientation.Horizontal;

                Image image = new Image();
                if (product.Image != "отсутствует")
                {
                    image.Source = new BitmapImage(new Uri(product.Image, UriKind.Relative));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri("picture.png", UriKind.Relative));
                }
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Center;
                image.Margin = new Thickness(15, 0, 0, 0);
                image.Width = 76;
                image.Height = 76;

                StackPanel stackPanelInner = new StackPanel();
                stackPanelInner.Orientation = Orientation.Vertical;

                TextBlock nameTB = new TextBlock();
                nameTB.Text = product.ProdType + " | " + product.ProdName;
                nameTB.Margin = new Thickness(30, 5, 0, 0);
                nameTB.Width = 500;
                nameTB.Height = 25;
                nameTB.FontSize = 16;
                nameTB.FontWeight = FontWeights.SemiBold;

                TextBlock articleTB = new TextBlock();
                articleTB.Text = product.ArticleNum.ToString();
                articleTB.Margin = new Thickness(30, 0, 0, 0);
                articleTB.Width = 500;
                articleTB.Height = 25;
                articleTB.FontSize = 14;

                TextBlock materialsTB = new TextBlock();
                materialsTB.Text = "Материалы: " + GetMaterialsForProduct(product.ProdName);
                materialsTB.Margin = new Thickness(30, 0, 0, 0);
                materialsTB.Width = 500;
                materialsTB.Height = 40;
                materialsTB.FontSize = 12;
                materialsTB.HorizontalAlignment = HorizontalAlignment.Left;
                materialsTB.TextWrapping = TextWrapping.Wrap;

                StackPanel stackPanelForPrice = new StackPanel();
                stackPanelForPrice.Orientation = Orientation.Horizontal;

                TextBlock priceTB = new TextBlock();
                priceTB.Text = product.MinPriceForAgent.ToString() + " ₽";
                priceTB.Margin = new Thickness(40, 10, 0, 0);
                priceTB.Width = 90;
                priceTB.Height = 40;
                priceTB.FontSize = 14;
                priceTB.HorizontalAlignment = HorizontalAlignment.Right;
                priceTB.VerticalAlignment = VerticalAlignment.Top;

                stackPanelInner.Children.Add(nameTB);
                stackPanelInner.Children.Add(articleTB);
                stackPanelInner.Children.Add(materialsTB);

                stackPanelForPrice.Children.Add(priceTB);

                stackPanelOut.Children.Add(image);
                stackPanelOut.Children.Add(stackPanelInner);
                stackPanelOut.Children.Add(stackPanelForPrice);

                border.Child = stackPanelOut;

                LV.Items.Add(border);
            }
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)SortCB.SelectedItem;
            string sortTag = selectedItem.Tag.ToString();

            if (products != null & TB_Search.Text != "Введите для поиска")
            {
                switch (sortTag)
                {
                    case "NameAsc":
                        products = products.OrderBy(p => p.ProdName).ToList();
                        break;
                    case "NameDesc":
                        products = products.OrderByDescending(p => p.ProdName).ToList();
                        break;
                    case "ProductionNumAsc":
                        products = products.OrderBy(p => p.ProdNum).ToList();
                        break;
                    case "ProductionNumDesc":
                        products = products.OrderByDescending(p => p.ProdNum).ToList();
                        break;
                    case "MinPriceAsc":
                        products = products.OrderBy(p => p.MinPriceForAgent).ToList();
                        break;
                    case "MinPriceDesc":
                        products = products.OrderByDescending(p => p.MinPriceForAgent).ToList();
                        break;
                }

                curPage = 1;
                totalPages = (int)Math.Ceiling((double)products.Count / pageSize);

                UpdatePages();
                DisplayCurPage();
            }
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedType = (FilterCB.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (selectedType == "Все типы")
            {
                UpdateListView(products);
            }
            else
            {
                List<Product> filteredProducts = products.Where(p => p.ProdType == selectedType).ToList();
                UpdateListView(filteredProducts);
            }
        }

        private string GetMaterialsForProduct(string productName)
        {
            var materialsForProduct = productions.Where(p => p.Products == productName)
                                                 .Select(p => p.MaterialName);

            if (string.IsNullOrEmpty(string.Join(", ", materialsForProduct)))
            {
                return "Отсутствуют данные";
            }

            return string.Join(", ", materialsForProduct);
        }
        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Search.Text = "";
        }

        private void TB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Search.Text))
            {
                TB_Search.Text = "Введите для поиска";
            }
        }

        //Сюда не стоит смотреть, я думал это чуть по-другому будет выглядеть
        private void SaveCurrentScale()
        {
            savedScaleX = mainGrid.LayoutTransform.Value.M11;
            savedScaleY = mainGrid.LayoutTransform.Value.M22;
        }

        private void ToggleFullscreen()
        {
            if (WindowStyle == WindowStyle.None)
            {
                mainGrid.LayoutTransform = new ScaleTransform(savedScaleX, savedScaleY);

                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
            }
            else
            {
                SaveCurrentScale();

                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;

                double scaleX = ActualWidth / SystemParameters.PrimaryScreenWidth;
                double scaleY = ActualHeight / SystemParameters.PrimaryScreenHeight;
                mainGrid.LayoutTransform = new ScaleTransform(scaleX, scaleY);
            }
        }

        private void FullscreenButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleFullscreen(); //тогл миниатюризация
        }
    }
}