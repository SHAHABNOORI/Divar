namespace Divar.Framework.Domain.ApplicationServices
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}