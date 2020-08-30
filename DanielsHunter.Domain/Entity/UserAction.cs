using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Entity
{
   public  class UserAction : BaseEntity
    {
        public UserActionEnum Name { get; set; }
        public bool IsChosen { get; set; }
        public UserAction(UserActionEnum userActionEnum)
        {
            Name = userActionEnum;
            IsChosen = false;
        }
    }
}
