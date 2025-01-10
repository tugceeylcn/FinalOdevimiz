using Odev.DAL.Models;
using Odev.Domain.ViewModels;
using AutoMapper;

namespace Odev.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAddress, CustomerAddressViewModel>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderBillingAddress, opt => opt.MapFrom(src => src.BillingAddress))
                .ForMember(dest => dest.OrderShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress));

            CreateMap<Customers, CustomersViewModel>();
        }
    }
}