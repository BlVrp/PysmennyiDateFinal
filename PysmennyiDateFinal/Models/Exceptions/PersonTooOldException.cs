namespace PysmennyiDateFinal.Models.Exceptions
{
    public class PersonTooOldException : BirthdateException
    {
        public PersonTooOldException(string message)
            : base(message)
        {
        }

        public PersonTooOldException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PersonTooOldException(DateTime providedBirthdate)
            : base(providedBirthdate,
                $"The provided birthdate '{providedBirthdate.ToShortDateString()}' is too far in the past. Please pick another date.")
        {
        }

        public PersonTooOldException(DateTime providedBirthdate, DateTime closestValidBirthdate)
            : base(providedBirthdate, closestValidBirthdate,
                $"The provided birthdate '{providedBirthdate.ToShortDateString()}' is too far in the past. Please pick '{closestValidBirthdate.ToShortDateString()}' or a more recent date.")
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}, ProvidedBirthdate: {ProvidedBirthdate.ToShortDateString()}";
        }
    }
}
