using AutoMapper;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Configuration
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<UsersDetail, UserRegistration>(); // Define mapping from Source to Destination
            CreateMap<UsersDetail, FormM>();// Add other mappings as needed
            CreateMap<UsersDetail, FormN>();
            CreateMap<UsersDetail, FormO>();
        }
        //public static void RegisterMappings()
        //{
        //    Mapper.Register<UsersDetail, UserRegistration>();
        //    Mapper.Register<UsersDetail, FormM>();
        //    Mapper.Register<UsersDetail, FormN>();
        //    Mapper.Register<UsersDetail, FormO>();
        //    //Mapper.Register<UserRegistration, FormD>()
        //    //.Member(dest => dest.UserDetailID, src => src.ID); // Custom mapping for UserDetailID
        //    //Mapper.Register<UserRegistration, FormM>()
        //    //    .Member(dest => dest.UserID, src => src.UserID)
        //    //    .Member(dest => dest.RegistrationID, src => src.ID);

        //    Mapper.Compile();
        //}
    }
}
