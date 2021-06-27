using AutoMapper;
using ServiceNamespace.Application.Models;
using ServiceNamespace.Domain.Entities;
using ServiceNamespace.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceNamespace.Application.Mapping
{
    public class UsuarioMap : Profile
    {
        public UsuarioMap()
        {
            CreateMap<UsuarioPostModel, Usuario>()
                .ForMember(dest => dest.Senha, m => m.Ignore())
                .ConstructUsing(src =>
                    new Usuario(
                        new Senha(src.Senha)));
        }
    }
}
