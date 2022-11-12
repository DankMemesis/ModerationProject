using ModeratingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeratingProject.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<List<UserModel>>> GetUsers(TextBox _textBoxSearch);
        //добавление
        Task<Result<int>> AddUser(UserModel user);
        //удаление
        Task<Result<int>> RemoveUser(int id);
        //обновление
        Task<Result<int>> UpdateUser(UserModel user);
       // Task<Result<List<UserModel>>> SearchUser(UserModel user);
    }
}
