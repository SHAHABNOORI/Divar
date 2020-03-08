namespace Divar.Framework.Domain.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}