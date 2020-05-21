using AutoMapper;
using FD.BLL.JsonModels;
using FD.BLL.Models.User;
using FD.DAL.Repository.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ConnectionStrings _connectionStrings;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository, IOptions<ConnectionStrings> connectionStrings)
        {
            _mapper = mapper;
            _connectionStrings = connectionStrings.Value;
            _userRepository = userRepository;
        }

        public UserModel GetUser(UserLogIn user)
        {
            try
            {
                var result = _userRepository.GetUserByEmail(user.Email);
                if(result != null)
                {
                    // check if provided password is correct or not
                    //if incorrect return null
                    //if correct return map result and return
                    if(user.Password == "admin")
                        return _mapper.Map<UserModel>(result);

                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
