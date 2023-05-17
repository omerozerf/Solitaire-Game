namespace _Scripts.Solitaire
{
    public interface ICommand
    {
        void Execute();
        
        void Undo();
    }
}