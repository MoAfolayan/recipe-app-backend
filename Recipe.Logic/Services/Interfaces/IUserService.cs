using System;
using Recipe.Data.Entities;

namespace Recipe.Logic.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        User GetUserByAuth0Id(string id);
    }
}
