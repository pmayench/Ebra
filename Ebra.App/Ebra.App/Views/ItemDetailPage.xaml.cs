using Ebra.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Ebra.App.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}