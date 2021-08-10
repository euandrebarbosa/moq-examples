using MOQ.Examples.Model;
using System.Text.RegularExpressions;

namespace MOQ.Examples
{
    public class Validator : IValidator
    {
        private readonly Regex regex = new Regex("^[0-9]+$");

        public bool CodeValidator(IPerson person, ValidatorType type)
        {
            return type switch
            {
                ValidatorType.OnlyNumbers => ValidateLength(person.Code) && regex.IsMatch(person.Code),
                ValidatorType.Mixed => ValidateLength(person.Code),
                _ => false,
            };
        }

        public void ClearCode(IPerson person)
            => person.Code = string.Empty;

        private bool ValidateLength(string code) => code.Length > 6;
    }

    public enum ValidatorType
    {
        OnlyNumbers = 0,
        Mixed = 1
    }
}