using DanielsHunter.App.Common;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DanielsHunter.App.Concrete
{
    public class ActionService : BaseService<UserAction>
    {
        private User user;
        private UserAction currentAction;
        private UserAction CurrentAction { get => Items.FirstOrDefault(x => x.IsChosen == true); set { currentAction = value; } }
        private int CurrentIndex { get { return Items.IndexOf(CurrentAction); } }
        public ActionService()
        {
        }
        public ActionService(User user)
        {
            this.user = user;
            Initialise();
        }

        public UserActionEnum PreviousAction()
        {
            int newIndex;
            if (CurrentIndex == Items.IndexOf(Items.First()))
            {
                newIndex = Items.IndexOf(Items.Last());
            }
            else
            {
                newIndex = CurrentIndex - 1;
            }
            CurrentAction.IsChosen = false;
            Items[newIndex].IsChosen = true;
            user.ChosenAction = CurrentAction.Name;
            return user.ChosenAction;
        }

        public UserActionEnum NextAction()
        {
            int newIndex;
            if (CurrentIndex == Items.IndexOf(Items.Last()))
            {
                newIndex = 0;
            }
            else
            {
                newIndex = CurrentIndex + 1;
            }
            CurrentAction.IsChosen = false;
            Items[newIndex].IsChosen = true;
            user.ChosenAction = CurrentAction.Name;
            return user.ChosenAction;
        }

        public UserActionEnum ResetToMOVE()
        {
            CurrentAction.IsChosen = false;
            Items.First(x => x.Name == UserActionEnum.MOVE).IsChosen = true;
            user.ChosenAction = CurrentAction.Name;
            return user.ChosenAction;
        }

        private void Initialise()
        {
            Items.Add(new UserAction(UserActionEnum.MOVE));
            Items[0].IsChosen = true;
            Items.Add(new UserAction(UserActionEnum.CHOP_TREE));
            Items.Add(new UserAction(UserActionEnum.SHOOT));
            Items.Add(new UserAction(UserActionEnum.WAIT));
        }

    }
}
