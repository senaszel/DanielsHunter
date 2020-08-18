namespace DanielsHunter
{
    public interface IMenu
    {
        void Add(MenuItem menuItem);
        void Print();
        void EnableChoice();
        MenuItem ChosenItem { get; }
        MenuItem NextItem();
        MenuItem PreviousItem();
    }
}