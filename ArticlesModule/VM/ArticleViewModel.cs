using System.Collections.ObjectModel;
using System.ComponentModel;
using Ebra.Models.Interfaces;
using Ebra.Models.Models;

namespace ArticlesModule.VM
{
    public class ArticleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Article> Articles { get; set; }
        private IArticleService _articleService;
        public string notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(notification)));

            }
        }
        private string _notification;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Article SelectedArticle { get; set; }

        public ArticleViewModel(IArticleService articleService)
        {
            _articleService = articleService;
            Articles = new ObservableCollection<Article>(_articleService.GetArticles());
            notification = Articles.Count.ToString();
        }
    }
}
