using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;


        }
        public static UserDTO Get(string userName, string password, string userType)
        {
            var data = DataAccessFactory.UserDataAccess().Get(userName, password, userType);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;

        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }
        public static bool Add(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<User>(dto);
            var result = DataAccessFactory.UserDataAccess().Add(mapped);
            return result;
        }
        public static bool Update(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<User>(dto);
            var result = DataAccessFactory.UserDataAccess().Update(mapped);
            return result;

        }
        public static bool Delete(int id)
        {
            var result = DataAccessFactory.UserDataAccess().Delete(id);
            return result;
        }

        public static bool GetByUserIdType(int userId, string type)
        {
            var data = Get(userId);
            if (data == null)
            {
                return false;
            }

            if (data.UserType.Equals(type))
            {
                return true;
            }

            return false;
        }
    }
}
