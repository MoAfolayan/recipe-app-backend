using System;
using Recipe.Data.Entities;

namespace Recipe.Logic.Services
{
    public interface IUserService
    {
        User GetUser(int id);
    }
}
