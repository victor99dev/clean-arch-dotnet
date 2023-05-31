namespace Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        { }

        public static void When(bool hasErrors, string error)
        {
            if (hasErrors)
                throw new DomainExceptionValidation(error);
        }
    }
}