using AutoMapper;
using Insurance.Application.DTO;
using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<Customer_addressDTO, Customer_Address>().ReverseMap();
        }
    }
}
