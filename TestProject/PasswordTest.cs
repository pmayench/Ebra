using FluentAssertions;

namespace TestProject
{
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
}