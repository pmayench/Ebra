using AutoMapper;
using ProcessModule.VM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessModule.Mappers
{
    public class EbraProcessMapperConfiguration : MapperConfiguration
    {
        public EbraProcessMapperConfiguration(MapperConfigurationExpression configurationExpression) : base(configurationExpression)
        {
            configurationExpression.AddProfile<ProcessAutoMapper>();

#if DEBUG
            try
            {
                AssertConfigurationIsValid();
            }
            catch (Exception)
            {
                throw;
            }
#endif
        }
    }

    public class PruebasActionFunction
    {
        public void prueba1()
        {
            Action a1 = Accion1;
            a1.Invoke();

            Action<string> a2 = Accion2;
            a2.Invoke("parametro");

            Func<string, string> a3 = Accion3;
            var result = a3.Invoke("parametro");

            Func<string, string, string> a4 = Accion4;

            Accion5(Accion1);
            Accion5(() => { });

            Accion6((s) => { });
            
            Accion7(Accion3);
            Accion7((s) => { return s;});

            Accion8((s) => { return s;}, (x) => { return x; }, (y) => { return y; });

            Accion9((s) => { return s.Name; }, (x) => { return x.ProcessName; });
        }

        public void Accion1()
        {
            
        }
        public void Accion2(string parametro)
        {

        }

        public string Accion3(string parametro)
        {
            return string.Empty;
        }

        public string Accion4(string parametro1, string parametro2)
        {
            return string.Empty;
        }

        public void Accion5(Action action)
        {

        }

        public void Accion6(Action<string> action)
        {

        }

        public void Accion7(Func<string, string> func)
        {

        }

        public void Accion8(Func<string, string> func, Func<string, string> func2, Func<string, string> func3)
        {

        }

        public void Accion9(Func<ProcessDTO, string> func, Func<Process, string> func2)
        {

        }
    }
}
