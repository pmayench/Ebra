using AutoMapper;
using ProcessModule.VM;
using System.Diagnostics;

namespace ProcessModule.Mappers
{
    public class ProcessAutoMapper : Profile
    {
        private PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public ProcessAutoMapper()
        {
            CreateMap<Process, ProcessDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProcessName))
                .ForMember(dest => dest.CPU, opt => opt.MapFrom(src => GetCPU(src)))
                .ForMember(dest => dest.Memory, opt => opt.Ignore())//.MapFrom(src => GetMemory(src)))
                .ForMember(dest => dest.Disk, opt => opt.Ignore())//.MapFrom(src => GetDisk(src)))
                .ForMember(dest => dest.Network, opt => opt.Ignore());//.MapFrom(src => GetNetwork(src)));
        }

        public double GetCPU(Process process)
        {
            try
            {
                var cpu = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                return cpu.NextValue();
            }
            catch
            {
                return 0;
            }
        }

        public double GetMemory(Process process)
        {
            try
            {
                var memory = new PerformanceCounter("Process", "% Working Set", process.ProcessName);
                return memory.NextValue();
            }
            catch
            {
                return 0;
            }
        }

        public double GetDisk(Process process)
        {
            return process.TotalProcessorTime.TotalMilliseconds;
        }

        public double GetNetwork(Process process)
        {
            return process.TotalProcessorTime.TotalMilliseconds;
        }
    }
}
