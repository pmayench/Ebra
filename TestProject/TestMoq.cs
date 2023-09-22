using Moq;

namespace TestProject
{
    [TestClass]
    [TestCategory("MOQ")]
    public class TestMoq
    {
        [TestMethod]
        //Implementa con MOQ el método de la interfaz
        public void MethodTest()
        {
            var mock = new Mock<ITestMoqInterface>();
            mock.Setup(x => x.Metodo("hola")).Returns("hola");

            mock.Setup(x => x.Metodo("adios")).Returns("adios");

            var result = mock.Object.Metodo("hola");
            Assert.AreEqual("hola", result);

            var result2 = mock.Object.Metodo("adios");
            Assert.AreEqual("adios", result2);
        }

        [TestMethod]
        //Implementa con MOQ el método de la interfaz
        public void InjectionTest()
        {
            var mock = new Mock<ITestMoqInterface>();
            mock.Setup(x => x.Metodo("metodo")).Returns("hola");

            ITestMoqInterface interfaz = mock.Object;
            var target = new ClaseInyeccion(interfaz);
            Assert.AreEqual("hola", target._testMoqInterface.Metodo("metodo"));
        }
    }
}