using System;
using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
  public AutoMapperProfiles()
  {
    CreateMap<AppUser, MemberDto>()
      .ForMember(d => d.PhotoUrl,
      o => o.MapFrom(s => s.Photos.FirstOrDefault(p => p.IsMain)!.Url));
    CreateMap<Photo, PhotoDto>();
  }

}
