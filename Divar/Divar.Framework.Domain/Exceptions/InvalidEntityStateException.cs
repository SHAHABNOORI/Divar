using System;

namespace Divar.Framework.Domain.Exceptions
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(object entity, string message)
            : base($"امکان تغییر وضعیت {entity.GetType().Name} وجود ندارد. {message}")
        {
        }
    }
}
