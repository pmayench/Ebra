using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ArticlesModule.VM
{
    public class ArticleViewModelPrism : BindableBase
    {
        public ObservableCollection<Article> Articles { get; set; }
        private IArticleService _articleService;
        private string _notification;
        public string notification 
        { 
            get { return _notification; } 
            set 
            { 
                SetProperty(ref _notification, value);
            } 
        }
        public Article SelectedArticle { get; set; }

        public ArticleViewModelPrism(IArticleService articleService)
        {
            _articleService = articleService;
            Articles = new ObservableCollection<Article>(_articleService.GetArticles());
            notification = Articles.Count.ToString();
            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);
        }

        private bool CanExecute()
        {
            return (notification == "1");
        }

        private void Execute()
        {
            notification = "Execute";
        }

        public DelegateCommand ExecuteDelegateCommand { get; set; }
    }
}
