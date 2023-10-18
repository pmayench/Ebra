using System;

namespace Ebra.Models.Exceptions
{
    public class NotFoundVersionException : Exception
    {
        public NotFoundVersionException() : base("There is no version for this Entity. Async data for getting the last version")
        {

        }
    }
}
