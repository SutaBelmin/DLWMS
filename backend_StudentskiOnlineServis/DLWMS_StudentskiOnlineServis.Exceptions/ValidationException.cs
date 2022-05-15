using System;

namespace DLWMS_StudentskiOnlineServis.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
