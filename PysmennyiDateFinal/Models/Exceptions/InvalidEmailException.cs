namespace PysmennyiDateFinal.Models.Exceptions
{
    using System;

    public class InvalidEmailException : ArgumentException
    {

        public string? InvalidEmail { get; private set; }

        public InvalidEmailException()
            : base("Invalid email format.")
        {
        }

        public InvalidEmailException(string invalidEmail)
            : base($"The email '{invalidEmail}' is not a valid email address.")
        {
            InvalidEmail = invalidEmail;
        }

        public InvalidEmailException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
