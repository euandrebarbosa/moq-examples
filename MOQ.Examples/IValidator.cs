using MOQ.Examples.Model;

namespace MOQ.Examples
{
    public interface IValidator
    {
        bool CodeValidator(IPerson person, ValidatorType type);

        void ClearCode(IPerson person);
    }
}