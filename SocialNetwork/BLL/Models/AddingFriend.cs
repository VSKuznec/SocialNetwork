using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class AddingFriend
    {
        public int Id { get; }
        public string UserEmail { get; }
        public string FriendEmail { get; }

        public AddingFriend(int id, string userEmail, string friendEmail)
        {
            this.Id = id;
            this.UserEmail = userEmail;
            this.FriendEmail = friendEmail;
        }
    }
}
