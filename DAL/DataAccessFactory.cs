using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IDoctorRepo<Doctor, int, bool> DoctorDataAccess()
        {
            return new DoctorRepo();
        }
        public static IRepo<Patient, int, bool> PatientDataAccess()
        {
            return new PatientRepo();
        }
        public static IUserRepo<User, int, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<BloodDonor, int, bool> BloodDonorDataAccess()
        {
            return new BloodDonorRepo();
        }
        public static ITokenRepo<Token, int, bool> TokenDataAccess()
        {
            return new TokenRepo();
        }
    }
}
