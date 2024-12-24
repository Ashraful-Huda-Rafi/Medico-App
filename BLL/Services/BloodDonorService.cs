using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BloodDonorService
    {
        public static List<BloodDonorDTO> Get()
        {
            var data = DataAccessFactory.BloodDonorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BloodDonor, BloodDonorDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<BloodDonorDTO>>(data);
            return mapped;

        }
        public static BloodDonorDTO Get(int id)
        {
            var data = DataAccessFactory.BloodDonorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BloodDonor, BloodDonorDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<BloodDonorDTO>(data);
            return mapped;

        }
        public static bool Add(BloodDonorDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BloodDonorDTO, BloodDonor>();
                cfg.CreateMap<BloodDonor, BloodDonorDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<BloodDonor>(dto);
            var result = DataAccessFactory.BloodDonorDataAccess().Add(mapped);
            return result;
        }
        public static bool Update(BloodDonorDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BloodDonorDTO, BloodDonor>();
                cfg.CreateMap<BloodDonor, BloodDonorDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<BloodDonor>(dto);
            var result = DataAccessFactory.BloodDonorDataAccess().Update(mapped);
            return result;

        }
        public static bool Delete(int id)
        {
            var result = DataAccessFactory.BloodDonorDataAccess().Delete(id);
            return result;
        }
    }
}
