namespace OtavioStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);  
    }
}