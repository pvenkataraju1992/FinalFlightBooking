using FBS.Service.Common;
using FBS.Service.UserManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.Processor
{
    public interface IUserProcessor
    {
        Response<TokenDetails> Authenticate(UserLogin user);
        Response<bool> AddUser(UserRegister user);
    }
}
