using System;

namespace IsuExtra.Tools
{
    public class OGNPException : Exception
    {
        public OGNPException()
        {
        }

        public OGNPException(string message)
            : base(message)
        {
        }

        public OGNPException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
