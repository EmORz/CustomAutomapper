namespace MyApp.Core.Commands.Interface
{
    public interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}