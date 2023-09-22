namespace TestProject
{
    public class ClaseInyeccion
    {
        public ITestMoqInterface _testMoqInterface { get; set; }
        public ClaseInyeccion(ITestMoqInterface testMoqInterface)
        {
            _testMoqInterface = testMoqInterface;
        }
    }
}