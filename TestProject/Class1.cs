namespace TestProject
{
    internal class Class1 : IDisposable
    {
        public Class1()
        {
        }

        public int Campo;

        public int Propiedad { get; set; }

        public bool metodoInvocado;

        internal void MetodoAccion()
        {
            metodoInvocado = true;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~Class1()
        {
            //Destructor
        }
    }



}