using DanielsHunter.Common;
using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    static class UserInputService
    {

        public static void GetPlayersInput(Screen screen, User user)
        {
            (int ofX, int ofY) modification = DirectionMenager.GetDirection();
            if (user.X == user.X + modification.ofX &&
                user.Y == user.Y + modification.ofY )
            {
                new MenuService().EnabelActionChoice(screen, user);
            }
            else
            {
                new UserService(user).MoveUser(modification, screen);
            }
        }

    }
}
