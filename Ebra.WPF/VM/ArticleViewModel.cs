using System.Collections.ObjectModel;
using Ebra.Models.Interfaces;
using Ebra.Models.Models;

namespace Ebra.WPF.VM
{
    public class ArticleViewModel
    {
        public ObservableCollection<Article> Articles { get; set; }
        private IArticleService _articleService;
        public Article SelectedArticle { get; set; }

        public ArticleViewModel(IArticleService articleService)
        {
            _articleService = articleService;
            Articles = new ObservableCollection<Article>(_articleService.GetArticles());
        }
    }
}
