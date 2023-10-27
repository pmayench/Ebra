using ConfigurationModule.Views;
using Ebra.Infrastructure.Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using ProcessModule.Views;
using ProcessModule.VM;
using System;
using System.Threading.Tasks;

namespace Ebra.WPF.VM
{
    internal class MenuViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _container;
        private IRegion _leftRegion, _centralRegion;
        ProcessListView _processListView;
        ProcessDetailView _processDetailView;
        ConfigurationListView _configurationListView;
        ProcessViewModel _processViewModel;

        public MenuViewModel(IRegionManager regionManager, IContainerExtension container)
        {
            ProcessCommand = new DelegateCommand<string>(ExecuteProcess, CanExecute);
            ConfigurationCommand = new DelegateCommand(ExecuteConfiguration);
            _regionManager = regionManager;
            _container = container;

            Load();
        }

        private void Load()
        {
            _processListView = _container.Resolve<ProcessListView>();
            _processDetailView = _container.Resolve<ProcessDetailView>();
            _configurationListView = _container.Resolve<ConfigurationListView>();
            _processViewModel = _container.Resolve<ProcessViewModel>();
            
            _centralRegion = _regionManager.Regions[RegionNames.CentralRegion.ToString()];
            _leftRegion = _regionManager.Regions[RegionNames.LeftRegion.ToString()];

            _leftRegion.Add(_processListView);
            _leftRegion.Add(_configurationListView);
            _centralRegion.Add(_processDetailView);
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
            if(_processListView.DataContext == null)
                _processListView.DataContext = _processViewModel;
            if (_processDetailView.DataContext == null)
                _processDetailView.DataContext = _processViewModel;

            _leftRegion.Activate(_processListView);
            _centralRegion.Activate(_processDetailView);
            _processViewModel.Load();
            return;
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
            _leftRegion.Activate(_configurationListView);
            return;
            _regionManager.RequestNavigate(RegionNames.LeftRegion.ToString(), ViewNames.ConfigurationListView.ToString());
            _regionManager.RequestNavigate(RegionNames.CentralRegion.ToString(), ViewNames.ConfigurationDetailView.ToString());
        }
        #endregion
    }
}
