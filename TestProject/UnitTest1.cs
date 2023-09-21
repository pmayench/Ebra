using Moq;
using FluentAssertions;
using Tamarack.Pipeline;
using Ebra.App.Models;
using Ebra.App.Services.Interfaces;
using Xamarin.Forms;
using Ebra.App.Services;
using Ebra.App.ViewModels.Start;

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

    public interface ITestMoqInterface
    {
        string Metodo(string value);
    }

    public class ClaseInyeccion
    {
        public ITestMoqInterface _testMoqInterface { get; set; }
        public ClaseInyeccion(ITestMoqInterface testMoqInterface)
        {
            _testMoqInterface = testMoqInterface;
        }
    }

    [TestClass]
    [TestCategory("PasswordTest")]
    public class PasswordTest
    {
        [TestMethod]
        public void testeoContraseña()
        {
            string password = "Password123!";
            //crea un método que haga un testeo de la contraseña de minimo 12 caracteres (minimo 1 mayuscula, 1 minuscula, 1 numero y 1 simbolo) usando Fluent Assertions            //crea un método que haga un testeo de la contraseña de minimo 12 caracteres (minimo 1 mayuscula, 1 minuscula, 1 numero y 1 simbolo) usando Fluent Assertions
            //https://fluentassertions.com/introduction
            password.Should().NotBeNullOrEmpty();
            password.Should().HaveLength(12, "la contraseña debe tener 12 caracteres");
            password.Should().MatchRegex("[a-z]", "la contraseña debe tener al menos una minuscula");
            password.Should().MatchRegex("[A-Z]", "la contraseña debe tener al menos una mayuscula");
            password.Should().MatchRegex("[0-9]", "la contraseña debe tener al menos un numero");
            password.Should().MatchRegex("[^0-9a-zA-Z]", "la contraseña debe tener al menos un caracter especial");
            
        }
    }

    [TestClass]
    [TestCategory("Patterns")]
    public class PatternChainOfResponibilityTest
    {
        [TestMethod]
        public void CORBasic()
        {
            var contexto = new Context(new MockOfferService(), new MockArticleService(), new MockOrderService());
            var pipeline = new Pipeline<Context, Context>()
            .Add(new SyncArticles())
            .Add(new SyncOffers())
            .Add(new SyncOrders())
            .Finally(context => context);

            var response = pipeline.Execute(contexto);

            Assert.IsNotNull(response);
        }
    }
}