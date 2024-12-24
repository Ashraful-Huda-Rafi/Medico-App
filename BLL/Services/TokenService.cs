using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService
    {
        private static readonly Random random = new Random();
        public static List<TokenDTO> Get()
        {
            throw new NotImplementedException();
        }
        public static TokenDTO Get(int id)
        {
            throw new NotImplementedException();
        }
        public static TokenDTO Add(TokenDTO dto)
        {
            dto.TKey = RandomString(64);
            dto.CreatedAt = DateTime.Now;
            dto.DelatedAt = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Token>(dto);

            return DataAccessFactory.TokenDataAccess().Add(mapped) ? dto : null ;
        }
        public static bool Update(TokenDTO dto)
        {
            throw new NotImplementedException();
        }
        public static bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public static TokenDTO GetByTokenKeyUserIdExpiredNull(int user_id, string key)
        {
            var data = DataAccessFactory.TokenDataAccess().GetByTokenKeyUserIdExpiredNull(user_id, key);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<TokenDTO>(data);

            return mapped;

            throw new NotImplementedException();
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
