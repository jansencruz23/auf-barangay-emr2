using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Household, HouseholdDto>().ReverseMap();
            CreateMap<Household, CreateHouseholdDto>().ReverseMap();
            CreateMap<Household, UpdateHouseholdDto>().ReverseMap();

            CreateMap<HouseholdMember, HouseholdMemberDto>().ReverseMap();
            CreateMap<HouseholdMember, CreateHouseholdMemberDto>().ReverseMap();
            CreateMap<HouseholdMember, UpdateHouseholdMemberDto>().ReverseMap();
        }
    }
}
