using AutoMapper;
using EventHub.Dtos;
using EventHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHub.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}