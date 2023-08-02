﻿using AutoMapper;
using ProfileProject.Models.Domain;
using ProfileProject.Models.DTO;

namespace ProfileProject.Mapping;

public class Mapping:Profile
{
    public Mapping()
    {
        CreateMap<RegistrationModel, ApplicationUser>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name}")
            )
            .ForMember(
                dest => dest.SecurityStamp,
                opt => opt.MapFrom(src => $"{Guid.NewGuid().ToString()}")
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => $"{src.Email}")
            )
            
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => $"{src.PhoneNumber}")
            )
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => $"{src.UserName}")
            )
            .ForMember(
                dest => dest.EmailConfirmed,
                opt => opt.MapFrom(src => true)

            );
        
    }
}
