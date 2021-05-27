using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieRentalWebApp.Models;
using MovieRentalWebApp.Data_Transfer_Objects;

namespace MovieRentalWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain Model to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            //Dto to Domain Model
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(customer => customer.Id, optional => optional.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(movie => movie.Id, optional => optional.Ignore());
        }
    }
}