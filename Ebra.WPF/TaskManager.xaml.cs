using Ebra.Infrastructure.Prism;
using Ebra.WPF.Views;
using Prism.Regions;
using System.Windows;

namespace Ebra.WPF
{
    /// <summary>
    /// Lógica de interacción para TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        public TaskManager(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion(RegionNames.MenuRegion.ToString(), typeof(MenuView));
        }
    }
}
