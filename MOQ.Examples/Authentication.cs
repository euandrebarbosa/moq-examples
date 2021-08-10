using MOQ.Examples.Model;
using System;

namespace MOQ.Examples
{
    public class Authentication
    {
        private readonly IValidator validator;

        public Authentication(IValidator validator)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public bool CanLogin(IPerson person, ValidatorType type) 
            => validator.CodeValidator(person, type);
    }
}