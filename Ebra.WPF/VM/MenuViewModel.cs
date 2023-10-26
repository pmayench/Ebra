using Ebra.Infrastructure.Prism;
using Prism.Commands;
using Prism.Regions;
using System;

namespace Ebra.WPF.VM
{
    internal class MenuViewModel
    {
        private readonly IRegionManager _regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            ProcessCommand = new DelegateCommand<string>(ExecuteProcess, CanExecute);
            ConfigurationCommand = new DelegateCommand(ExecuteConfiguration);
            _regionManager = regionManager;
        }
        #region Process
        public DelegateCommand<string> ProcessCommand { get; set; }

        private bool CanExecute(string arg)
        {
            //Comprobar que se accede a los procesos
            return true;
        }

        private void ExecuteProcess(string navigatePath)
        {
            if (navigatePath == null) return;

            _regionManager.RequestNavigate(RegionNames.LeftRegion.ToString(), ViewNames.ProcessListView.ToString());
            _regionManager.RequestNavigate(RegionNames.CentralRegion.ToString(), ViewNames.ProcessDetailView.ToString());
        }

        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }
        #endregion

        #region Configuration
        public DelegateCommand ConfigurationCommand { get; set; }

        private void ExecuteConfiguration()
        {
            _regionManager.RequestNavigate(RegionNames.LeftRegion.ToString(), ViewNames.ConfigurationListView.ToString());
            _regionManager.RequestNavigate(RegionNames.CentralRegion.ToString(), ViewNames.ConfigurationDetailView.ToString());
        }
        #endregion
    }
}
