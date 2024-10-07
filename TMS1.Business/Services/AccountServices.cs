using AutoMapper;
using TMS1.DataAccess.Repositories;
using TMS1.Model.Dtos;
using TMS1.Model.Entity;
using System.Collections.Generic;
using TMS1.Business.Interfaces;
using TMS1.DataAccess.Interfaces;

namespace TMS1.Business.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountServices(IMapper mapper, IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public IEnumerable<UserDto> GetAllAccount(string username)
        {
            var users = _accountRepository.GetAllAccount(username);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public int CreateAccount(UserDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);
            return _accountRepository.CreateAccount(user);
        }

        public bool VerifyAccount(UserDto userDto)
        {
            var user = _mapper.Map<Users>(userDto);
            return _accountRepository.VerifyAccount(user);
        }

        public UserDto GetUserDetails(string username)
        {
            var user = _accountRepository.GetUserDetails(username);
            var userDto = _mapper.Map<UserDto>(user);

            // Fetch roles UserDto
            var roles = _roleRepository.GetRolesByUsername(username);
            userDto.Roles = roles;

            return userDto;
        }
    }
}
