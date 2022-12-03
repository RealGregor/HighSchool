using AutoMapper;
using LMA.Data.UI.ViewModels.ViewModels;
using LMA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMA.Data.UI.ViewModels.ViewModels.Employee;
using LMA.Data.UI.ViewModels.ViewModels.Order;

namespace LMAServer
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile() {
            CreateMap<UserModel, UserViewModel>().ForMember(u => u.ProfilePicture, m => m.MapFrom(u => Convert.ToBase64String(u.ProfilePicture)));
            CreateMap<UserViewModel, UserModel>().ForMember(u => u.ProfilePicture, m => m.MapFrom(u => Convert.FromBase64String(u.ProfilePicture)));
            CreateMap<CreateUserViewModel, UserModel>();
            CreateMap<UserModel, CreateUserViewModel>();
            CreateMap<AutoPartViewModel, AutoPartModel>().ForMember(ap => ap.Picture, m => m.MapFrom(ap => Convert.FromBase64String(ap.Picture)));
            CreateMap<AutoPartModel, AutoPartViewModel>().ForMember(ap => ap.Picture, m => m.MapFrom(ap => Convert.ToBase64String(ap.Picture)));
            CreateMap<AdminModel, AdminViewModel>();
            CreateMap<AdminViewModel, AdminModel>();
            CreateMap<EmployeeModel, EmployeeViewModel>().ForMember(e => e.ProfilePicture, m => m.MapFrom(e => Convert.ToBase64String(e.ProfilePicture)));
            CreateMap<EmployeeViewModel, EmployeeModel>().ForMember(e => e.ProfilePicture, m => m.MapFrom(e => Convert.FromBase64String(e.ProfilePicture)));
            CreateMap<EmployeeModel, ChangeEmployeeViewModel>().ForMember(e => e.ProfilePicture, m => m.MapFrom(e => Convert.ToBase64String(e.ProfilePicture)));
            CreateMap<AutoPartModel, ChangeAutoPartViewModel>().ForMember(ap => ap.Picture, m => m.MapFrom(ap => Convert.ToBase64String(ap.Picture)));
            CreateMap<CartItemViewModel, CartItemModel>();
            CreateMap<CartItemModel, CartItemViewModel>();
            CreateMap<OrderModel, OrderViewModel>();
        }
    }
}
