using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    static class UserInputManager
    {
        public static void GetPlayersInput(Screen screen, User user,AssetService assetService)
        {
            (int ofX, int ofY) modification = DirectionMenager.GetDirection();
            if (user.X == user.X + modification.ofX &&
                user.Y == user.Y + modification.ofY)
            {
                new MenuManager().EnabelActionChoice(screen, user,assetService);
            }
            else
            {
                new UserActionManager(user).MoveUser(modification, screen,assetService);
            }
        }

    }
}
