namespace Divar.Framework.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }

        protected abstract void ValidateInvariants();
    }
}