using Moq;
using MOQ.Examples;
using MOQ.Examples.Model;
using System;
using System.Linq.Expressions;
using Xunit;

namespace MOQ.Tests
{
    public class VerifyFunctionTests
    {
        [Fact]
        public void VerificandoSeUmMetodoFoiInvocado()
        {
            var mockValidator = new Mock<IValidator>();
            var person = new Person() { Code = "7As67qw3" };
            
            mockValidator.Object.CodeValidator(person, ValidatorType.Mixed);

            mockValidator.Verify(x => x.CodeValidator(It.IsAny<Person>(), ValidatorType.Mixed));
        }

        [Fact]
        public void VerificandoSeUmMetodoNaoFoiInvocado()
        {
            var mockValidator = new Mock<IValidator>();
            Expression<Action<IValidator>> expr = (x) => x.CodeValidator(It.IsAny<Person>(), ValidatorType.Mixed);

            mockValidator.Verify(expr, Times.Never);
        }

        [Fact]
        public void VerificandoQuantasVezesUmMetodoFoiInvocado()
        {
            var mockValidator = new Mock<IValidator>();
            Expression<Action<IValidator>> expr = (x) => x.CodeValidator(It.IsAny<Person>(), ValidatorType.Mixed);
            
            mockValidator.Object.CodeValidator(new Person() { Code = "78912qw1" }, ValidatorType.Mixed);
            mockValidator.Object.CodeValidator(new Person() { Code = "7Asq2qw2" }, ValidatorType.Mixed);
            mockValidator.Object.CodeValidator(new Person() { Code = "7A788qw3" }, ValidatorType.Mixed);
            mockValidator.Object.CodeValidator(new Person() { Code = "7As33qw4" }, ValidatorType.Mixed);
            mockValidator.Object.CodeValidator(new Person() { Code = "7As67qw5" }, ValidatorType.Mixed);

            mockValidator.Verify(expr, Times.Exactly(5));
        }

        // Esse método irá falhar propositalmente para exemplificar o uso da mensagem de falha
        [Fact]
        public void AdicionandoUmErroCustomizadoAValidacao()
        {
            var mockValidator = new Mock<IValidator>();
            Expression<Action<IValidator>> expr = (x) => x.CodeValidator(It.IsAny<Person>(), ValidatorType.Mixed);
            var person = new Person() { Code = "7As67qw3" };

            mockValidator.Object.CodeValidator(person, ValidatorType.Mixed);

            mockValidator.Verify(expr, Times.Never, "Erro personalizado em caso de falha na execução do método.");
        }

        [Fact]
        public void VerificandoSeUmaPropriedadeFoiAcessada_GetProperty()
        {
            var validator = new Validator();
            var authentication = new Authentication(validator);

            var mockPerson = new Mock<IPerson>();
            mockPerson.SetupProperty(x => x.Code, "7As67qw3");

            authentication.CanLogin(mockPerson.Object, ValidatorType.Mixed);

            mockPerson.VerifyGet(x => x.Code, Times.Once);
        }

        [Fact]
        public void VerificandoSeUmaPropriedadeFoiAlterada_SetProperty()
        {
            var validator = new Validator();

            var mockPerson = new Mock<IPerson>();
            mockPerson.SetupProperty(x => x.Code, "7As67qw3");

            validator.ClearCode(mockPerson.Object);

            mockPerson.VerifySet(x => x.Code, "Se não foi modificada a propriedade essa é a mensagem de falha.");
        }
    }
}