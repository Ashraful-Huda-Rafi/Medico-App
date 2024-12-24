using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PatientService
    {
        public static List<PatientDTO> Get()
        {
            var data = DataAccessFactory.PatientDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<PatientDTO>>(data);
            return mapped;

        }
        public static PatientDTO Get(int id)
        {
            var data = DataAccessFactory.PatientDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>());
            var mapper = new Mapper(config);
            var mapped = mapper.Map<PatientDTO>(data);
            return mapped;

        }
        public static bool Add(PatientDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Patient>(dto);
            var result = DataAccessFactory.PatientDataAccess().Add(mapped);
            return result;
        }
        public static bool Update(PatientDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDTO, Patient>();
                cfg.CreateMap<Patient, PatientDTO>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Patient>(dto);
            var result = DataAccessFactory.PatientDataAccess().Update(mapped);
            return result;

        }
        public static bool Delete(int id)
        {
            var result = DataAccessFactory.PatientDataAccess().Delete(id);
            return result;
        }
    }
}
