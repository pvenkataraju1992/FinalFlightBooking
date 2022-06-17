using FBS.Service.Common;
using FBS.Service.UserManagement.Api.Models;
using FBS.Service.UserManagement.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.Processor
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUsersRepository _userRepository;
        public UserProcessor(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Response<TokenDetails> Authenticate(UserLogin user)
        {
            return _userRepository.Authenticate(user);
        }
        public Response<bool> AddUser(UserRegister user)
        {
            return _userRepository.AddUser(user);
        }
    }
}
