using System.Windows;
using Ebra.Models.Services;
using Ebra.WPF.Views;
using Ebra.WPF.VM;
using Prism.Ioc;
using Prism.Regions;

namespace Ebra.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Region activada por código forzado


        //public MainWindow(IRegionManager regionManager)
        //{
        //    InitializeComponent();
        //    //view discovery
        //    regionManager.RegisterViewWithRegion("ContentRegion", typeof(ucArticleList));
        //}

        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion contentRegion;
        ucArticleList ucArticleList;
        ArticleViewModel vModel;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
        }



        private void LoadRegion(object sender, RoutedEventArgs e)
        {
            if(contentRegion == null)
            {
                contentRegion = _regionManager.Regions["ContentRegion"];
            }
            
            LoadMVVM();
            contentRegion.Add(ucArticleList);
        }

        private void LoadMVVM()
        {
            ucArticleList = _container.Resolve<ucArticleList>();
            vModel = _container.Resolve<ArticleViewModel>();
            ucArticleList.DataContext = vModel;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var ArticleViewModel = new ArticleViewModel(new MockArticleService());
        //    var ArticleListView = new ArticleListView();

        //    ArticleListView.DataContext = ArticleViewModel;
        //    ArticleListView.Show();
        //}

        //Region activada a evento
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            contentRegion.Activate(ucArticleList);
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            contentRegion.Deactivate(ucArticleList);
        }
    }
}
