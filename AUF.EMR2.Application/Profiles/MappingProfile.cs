using AUF.EMR2.Application.DTOs.Barangay;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.DTOs.Masterlist;
using AUF.EMR2.Application.DTOs.OralHealth;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using AUF.EMR2.Application.Extensions;
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
            CreateMap<Barangay, BarangayDto>().ReverseMap();
            CreateMap<Barangay, UpdateBarangayDto>().ReverseMap();

            CreateMap<Household, HouseholdDto>().ReverseMap();
            CreateMap<Household, CreateHouseholdDto>().ReverseMap();
            CreateMap<Household, UpdateHouseholdDto>().ReverseMap();
            CreateMap<Household, HouseholdOnlyDto>().ReverseMap();

            CreateMap<HouseholdMember, HouseholdMemberDto>().ReverseMap();
            CreateMap<HouseholdMember, HouseholdMemberOnlyDto>().ReverseMap();
            CreateMap<HouseholdMember, CreateHouseholdMemberDto>().ReverseMap();
            CreateMap<HouseholdMember, UpdateHouseholdMemberDto>().ReverseMap();

            CreateMap<HouseholdMember, MasterlistAdultDto>().ReverseMap();
            CreateMap<HouseholdMember, MasterlistAdultOnlyDto>().ReverseMap();
            CreateMap<HouseholdMember, MasterlistChildDto>().ReverseMap();
            CreateMap<HouseholdMember, MasterlistChildOnlyDto>().ReverseMap();
            CreateMap<HouseholdMember, UpdateMasterlistAdultDto>().ReverseMap();
            CreateMap<HouseholdMember, UpdateMasterlistChildDto>().ReverseMap();

            CreateMap<HouseholdMember, OralHealthDto>().ReverseMap();
            CreateMap<HouseholdMember, OralHealthOnlyDto>().ReverseMap();
            CreateMap<HouseholdMember, UpdateOralHealthDto>().ReverseMap();

            CreateMap<WomanOfReproductiveAge, WraDto>().ReverseMap();
            CreateMap<WomanOfReproductiveAge, WraOnlyDto>().ReverseMap();
            CreateMap<WomanOfReproductiveAge, CreateWraDto>().ReverseMap();
            CreateMap<WomanOfReproductiveAge, UpdateWraDto>().ReverseMap();

            CreateMap<PregnancyTracking, CreatePregnancyTrackingDto>().ReverseMap();
            CreateMap<PregnancyTracking, UpdatePregnancyTrackingDto>().ReverseMap();
            CreateMap<PregnancyTracking, PregnancyTrackingDto>()
                .ForMember(dest => dest.PregnancyOutcome, opt => opt.MapFrom(src => src.PregnancyOutcome.GetDisplayName()))
                .ReverseMap();

            CreateMap<PregnancyTrackingHh, PregnancyTrackingHhDto>().ReverseMap();
            CreateMap<PregnancyTrackingHh, PregnancyTrackingHhOnlyDto>().ReverseMap();
            CreateMap<PregnancyTrackingHh, UpdatePregnancyTrackingHhDto>().ReverseMap();
        }
    }
}
