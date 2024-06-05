using AutoMapper;
using conifs.rms.data.entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using conifs.rms.dto;
using conifs.rms.data.repositories.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace conifs.rms.@base.api.Profiles
    
{

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserTable, GetUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
                .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
               .ForMember(dest => dest.ValidTill, opt => opt.MapFrom(src => src.ValidTill))
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Userid))
               .ForMember(dest => dest.Companies, opt => opt.Ignore())
               .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<UserTable, GetUserDtoList>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
                .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
               .ForMember(dest => dest.ValidTill, opt => opt.MapFrom(src => src.ValidTill))
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Userid));
               


            CreateMap<CreateUserDto,UserTable>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
               .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
               .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
               .ForMember(dest => dest.ValidTill, opt => opt.MapFrom(src => src.ValidTill))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.ImageData, opt => opt.Ignore());

            CreateMap<PutUserDto, UserTable>()
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
              .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
              .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
              .ForMember(dest => dest.ValidTill, opt => opt.MapFrom(src => src.ValidTill))
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
              .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.Userid))
              .ForMember(dest => dest.ImageData, opt => opt.Ignore());
           
            CreateMap<CreateUserCompanyDto, UserCompany>()
              .ForMember(dest => dest.UserCompanyID, opt => opt.MapFrom(src => Guid.NewGuid()))
              .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.id))
              .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
             .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore());

            CreateMap<CreateUserRoleDto, UserRoles>()
            .ForMember(dest => dest.UserRoleID, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.Role, opt => opt.Ignore())
             .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }


    //public class UserResolver
    //{
    //    private readonly IUserRepository _userService;

    //    public UserResolver(IUserRepository userService)
    //    {
    //        _userService = userService;
    //    }

    //    public GetUserDto Resolve(CreateUserCompanyDto source)
    //    {
    //        var userID = source.Userid.ToString();
    //        return _userService.GetUserById(userID);
    //    }
    //}


}

