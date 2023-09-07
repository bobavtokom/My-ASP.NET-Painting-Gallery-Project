using AutoMapper;
using BoArtPaint.Dtos;
using BoArtPaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoArtPaint.App_Start {
    public class MappingProfile : Profile {
        public MappingProfile() {
            Mapper.CreateMap<Painting, PaintingDto>();
            Mapper.CreateMap<PaintingDto, Painting>();
        }
    }
}