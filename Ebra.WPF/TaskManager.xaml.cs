using Ebra.Infrastructure.Prism;
using Ebra.WPF.Views;
using Prism.Events;
using Prism.Regions;
using System.Windows;

namespace Ebra.WPF
{
    /// <summary>
    /// Lógica de interacción para TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        public TaskManager(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion(RegionNames.MenuRegion.ToString(), typeof(MenuView));
        
            this.DataContext = new TaskManagerVM(eventAggregator);
        }
    }
}
