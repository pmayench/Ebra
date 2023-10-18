using System.Collections.ObjectModel;
using Ebra.Models.Models;

namespace Ebra.WPF.VM
{
    public class ArticleViewModel
    {
        public ObservableCollection<Article> Articles { get; set; }

        public ArticleViewModel()
        {

        }
    }
}
