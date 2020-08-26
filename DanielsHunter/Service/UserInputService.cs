﻿using DanielsHunter.Common;
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
                // todo here will be menu to choose action shown on the screen below the board
                new UserService(user).ChopTree(screen.Board);
            }
            else
            {
                new UserService(user).MoveUser(modification, screen);
            }
        }

    }
}