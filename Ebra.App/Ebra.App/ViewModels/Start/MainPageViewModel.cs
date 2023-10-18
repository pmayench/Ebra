using Tamarack.Pipeline;
using Ebra.App.Services;
using System.Collections.ObjectModel;
using Ebra.Models.Models;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using Ebra.App.Factories;

namespace Ebra.App.ViewModels.Start
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Constructor
        public MainPageViewModel()
        {
            Title = "Start";

            Articles = new ObservableCollection<Article>();
            SynchronizeCommand = new Command(async () => await ExecuteSynchronizeCommand());
            ExecuteSynchronizeCommand();
        }
        #endregion

        #region Properties
        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                SetProperty(ref _selectedArticle, value);
                OnArticleSelected(value);
            }
        }
        #endregion

        #region Collections
        public ObservableCollection<Article> Articles { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Offer> Offers { get; set; }
        #endregion

        #region Commands
        public Command SynchronizeCommand { get; }

        async Task ExecuteSynchronizeCommand()
        {
            IsBusy = true;

            try
            {
                Articles.Clear();
                var contexto = new CreatorSyncroContext().FactoryMethod();
                var pipeline = ChainOfResponsibilityFactory.CreateCORSyncro();

                var response = pipeline.Execute(contexto);
                //await Task.FromResult(response);

                //var articlesService = new SyncArticles();
                //articlesService.Execute(contexto, null);

                foreach (var article in contexto.Articles)
                {
                    Articles.Add(article);
                }

                //Articles.Add(new Article("description", "name", 1.5));

                //Articles = new ObservableCollection<Article>(response.Articles);
                //Orders = new ObservableCollection<Order>(response.Orders);
                //Offers = new ObservableCollection<Offer>(response.Offers);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }

            finally { IsBusy = false; }
        }
        #endregion

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedArticle = null;
        }

        #region Methods
        async void OnArticleSelected(Article article)
        {
            if (article == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(MainPageViewModel)}?{nameof(MainPageViewModel.SelectedArticle.id)}={article.Id}");
        }
        #endregion
    }
}