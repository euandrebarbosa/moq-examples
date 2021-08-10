namespace MOQ.Examples.Model
{
    public class Person : IPerson
    {
        public string Code { get; set; }

        public void SetCode(string code)
        {
            this.Code = code;
        }
    }
}