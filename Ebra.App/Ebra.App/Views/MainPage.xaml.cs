using Ebra.App.Repositories;
using Ebra.App.ViewModels.Start;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebra.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}