namespace PysmennyiDateFinal.Models.Exceptions
{
    public abstract class BirthdateException : ArgumentOutOfRangeException
    {
        public DateTime ProvidedBirthdate { get; protected set; }
        public DateTime? ClosestValidBirthdate { get; protected set; }

        protected BirthdateException() : base() { }

        protected BirthdateException(string message)
            : base(message)
        {
        }

        protected BirthdateException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected BirthdateException(DateTime providedBirthdate, string message)
            : base(message)
        {
            ProvidedBirthdate = providedBirthdate;
        }

        protected BirthdateException(DateTime providedBirthdate, DateTime closestValidBirthdate, string message)
            : base(message)
        {
            ProvidedBirthdate = providedBirthdate;
            ClosestValidBirthdate = closestValidBirthdate;
        }
    }
}
