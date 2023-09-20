using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<AddingFriend> GetFriendsByUserId(int userId)
        {
            var adding = new List<AddingFriend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(a =>
            {
                var userEntity = userRepository.FindById(a.user_id);
                var friendsEntity = userRepository.FindById(a.friend_id);

                adding.Add(new AddingFriend(a.id, userEntity.email, friendsEntity.email));
            });

            return adding;
        }

        public void AddFriend(AddingFriendData addingFriendData)
        {
            var findUserEntity = this.userRepository.FindByEmail(addingFriendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = addingFriendData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}