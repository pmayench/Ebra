using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace ProcessModule.VM
{
    public class ProcessViewModel : BindableBase
    {
        public Process SelectedProcess { get; set; }
        public ObservableCollection<ProcessDTO> Processes { get; set; }
        public ProcessViewModel() 
        {
            //var ListProcess = Process.GetProcesses();
            //var ListProcessDTO = AutoMapper.Mapper.Map<List<Process>, List<ProcessDTO>>(ListProcess.ToList());
            //Processes = new ObservableCollection<ProcessDTO>(Process.GetProcesses());
            //SelectedProcess = Processes[0];
        }
    }

    public class ProcessDTO
    {
        public string Name { get; set; }
        public double CPU { get; set; }
        public double Memory { get; set; }
        public double Disk { get; set; }
        public double Network { get; set; }
    }
}
