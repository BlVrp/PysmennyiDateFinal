namespace PysmennyiDateFinal.Models.Exceptions
{
    using System;
    public class PersonNotBornException : BirthdateException
    {
        public PersonNotBornException()
            : base("Birthdate cannot be in the future.")
        {
        }

        public PersonNotBornException(string message)
            : base(message)
        {
        }

        public PersonNotBornException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PersonNotBornException(DateTime providedBirthdate)
            : base(providedBirthdate,
                $"The provided birthdate '{providedBirthdate.ToShortDateString()}' is in the future, which is not allowed. Please pick another date.")
        {
        }

        public PersonNotBornException(DateTime providedBirthdate, DateTime closestValidBirthdate)
            : base(providedBirthdate, closestValidBirthdate,
                $"The provided birthdate '{providedBirthdate.ToShortDateString()}' is in the future. Please pick '{closestValidBirthdate.ToShortDateString()}' or an earlier date.")
        {
        }
    }
}
