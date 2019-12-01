using System;

namespace Framework_Domain
{
    public class LessThanOrEqaulZeroValueException : Exception
    {
        public LessThanOrEqaulZeroValueException()
        {
            
        }
        public LessThanOrEqaulZeroValueException(string message) : base(message)
        {
        }
    }
}