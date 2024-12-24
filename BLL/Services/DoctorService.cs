using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DoctorService
    {
        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<DoctorDTO>>(data);
            return mapped;

        }
        public static DoctorDTO Get(int id)
        {
            var data = DataAccessFactory.DoctorDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<DoctorDTO>(data);
            return mapped;

        }
        public static bool Add(DoctorDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, Doctor>();
                cfg.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Doctor>(dto);
            var result = DataAccessFactory.DoctorDataAccess().Add(mapped);
            return result;
        }
        public static bool Update(DoctorDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, Doctor>();
                cfg.CreateMap<Doctor, DoctorDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Doctor>(dto);
            var result = DataAccessFactory.DoctorDataAccess().Update(mapped);
            return result;

        }
        public static bool Delete(int id)
        {
            var result = DataAccessFactory.DoctorDataAccess().Delete(id);
            return result;
        }
        public static List<DoctorDTO> Search(string search_value)
        {
            var result = DataAccessFactory.DoctorDataAccess().Search(search_value);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<DoctorDTO>>(result);

            return mapped;
        }
    }
}
