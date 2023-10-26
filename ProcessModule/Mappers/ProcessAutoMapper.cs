using AutoMapper;
using ProcessModule.VM;
using System.Diagnostics;

namespace ProcessModule.Mappers
{
    public class ProcessAutoMapper : Profile
    {
        public ProcessAutoMapper()
        {
            CreateMap<Process, ProcessDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProcessName))
                .ForMember(dest => dest.CPU, opt => opt.MapFrom(src => GetCPU(src)))
                .ForMember(dest => dest.Memory, opt => opt.MapFrom(src => GetMemory(src)))
                .ForMember(dest => dest.Disk, opt => opt.MapFrom(src => GetDisk(src)))
                .ForMember(dest => dest.Network, opt => opt.MapFrom(src => GetNetwork(src)));
        }

        public double GetCPU(Process process)
        {
            return process.TotalProcessorTime.TotalMilliseconds;
        }

        public double GetMemory(Process process)
        {
            return process.WorkingSet64;
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
