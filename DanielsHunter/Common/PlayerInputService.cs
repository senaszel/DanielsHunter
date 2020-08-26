using System;

namespace DanielsHunter
{
    static class PlayerInputService
    {

        public static void GetPlayersInput(Screen screen, User user)
        {
            (int ofX, int ofY) modification = DirectionMenager.GetDirection();
            if (user.X == user.X + modification.ofX &&
                user.Y == user.Y + modification.ofY )
            {
                // todo here will be menu to choose action shown on the screen below the board
                new UserActionController(user).ChopTree(screen.Board);
            }
            else
            {
                new UserActionController(user).MoveUser(modification, screen);
            }
        }

    }
}
