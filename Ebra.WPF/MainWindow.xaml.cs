using System.Windows;
using Ebra.Models.Services;
using Ebra.WPF.Views;
using Ebra.WPF.VM;

namespace Ebra.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ArticleViewModel = new ArticleViewModel(new MockArticleService());
            var ArticleListView = new ArticleListView();

            ArticleListView.DataContext = ArticleViewModel;
            ArticleListView.Show();
        }
    }
}
