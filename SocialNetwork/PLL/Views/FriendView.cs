using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        FriendService friendService;
        UserService userService;

        public FriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                var addingFriendData = new AddingFriendData();

                Console.WriteLine("Введите Email пользователя, которого хотите добавить в друзья: ");

                addingFriendData.FriendEmail = Console.ReadLine();
                addingFriendData.UserId = user.Id;

                friendService.AddFriend(addingFriendData);

                SuccessMessage.Show("Вы добавили указанного пользователя в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении пользователя в друзья!");
            }
        }
    }
}
