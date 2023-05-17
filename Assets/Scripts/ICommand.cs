namespace _Scripts.Solitaire
{
    public interface ICommand
    {
        bool Execute();
        
        bool Undo();
        
    }
}