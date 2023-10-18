using Ebra.Models.Models;

using Xamarin.Forms;

namespace TestProject
{
    [TestClass]
    [TestCategory("TipoA")]
    public class MiembrosDeUnaClase
    {
        [TestMethod]
        public void CampoTest()
        {
            var result = new Class1();

            result.Campo = 1;

            Assert.AreEqual(typeof(int), result.Campo.GetType());
            Assert.IsNotNull(result.Campo);
            Assert.AreEqual(1, result.Campo);
        }

        [TestMethod]
        public void PropertyTest()
        {
            var result = new Class1();


            result.Propiedad = 1;
            result.Campo = 1;

            Assert.AreEqual(typeof(int), result.Campo.GetType());
            Assert.IsNotNull(result.Campo);
            Assert.AreEqual(1, result.Campo);
        }

        [TestMethod]
        public void MethodActionTest()
        {
            var result = new Class1();

            result.MetodoAccion();

            Assert.AreEqual(typeof(bool), result.metodoInvocado.GetType());
            Assert.IsNotNull(result.metodoInvocado);
            Assert.AreEqual(true, result.metodoInvocado);
        }

        Class1 class1;
        [TestInitialize]
        public void initialize()
        {
            class1 = new Class1()
            {
                Campo = 1,
                Propiedad = 1,
                metodoInvocado = false
            };
        }

        [TestMethod]
        public void initialationTest()
        {
            Assert.AreEqual(typeof(bool), class1.metodoInvocado.GetType());
            Assert.IsNotNull(class1.metodoInvocado);
            Assert.AreEqual(false, class1.metodoInvocado);
        }

        [TestCleanup]
        public void clean()
        {
            class1 = null;
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void workWithData(int value)
        {
            var result = value + 1;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [DataRow("hola")]
        [DataRow("e")]
        public void workWithDataText(string value)
        {
            Assert.AreEqual(true, value.Contains("a"));
            var claseHija = new ClaseHija("hola");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPropia))]
        public void trabajarConExcepciones()
        {
            var claseHija = new ClaseHija("hola");
        }
    }
}