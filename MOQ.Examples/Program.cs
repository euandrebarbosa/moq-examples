using MOQ.Examples.Model;

namespace MOQ.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();

            var isOnlyNumbers = validator.CodeValidator(new Person() { Code = "7As67qw3" }, ValidatorType.OnlyNumbers);
            var isValid = validator.CodeValidator(new Person() { Code = "7As67qw3" }, ValidatorType.Mixed);
        }
    }
}