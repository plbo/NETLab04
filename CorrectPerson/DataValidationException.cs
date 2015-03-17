using System;

namespace CorrectPerson
{
    public class DataValidationException : Exception
    {
        public const string ValidationErrorMessageFormat = "Data validation failed on person '{0}' with value '{1}' and message '{2}'";
        public const string UnknownValue = "Unknown value";
    }
}
