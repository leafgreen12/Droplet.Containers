using System;

namespace Settings.Domain.Exceptions
{
    public class SettingsDomainException : Exception
    {
        public SettingsDomainException()
        { }

        public SettingsDomainException(string message)
            : base(message)
        { }

        public SettingsDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}