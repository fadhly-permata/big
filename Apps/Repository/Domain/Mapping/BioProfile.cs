using System;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Domain.Models;

namespace Repository.Domain.Mapping
{
    public partial class BioProfile
        : AutoMapper.Profile
    {
        public BioProfile()
        {
            CreateMap<Repository.Data.Entities.Bio, Repository.Domain.Models.BioReadModel>();

            CreateMap<Repository.Domain.Models.BioCreateModel, Repository.Data.Entities.Bio>();

            CreateMap<Repository.Data.Entities.Bio, Repository.Domain.Models.BioUpdateModel>();

            CreateMap<Repository.Domain.Models.BioUpdateModel, Repository.Data.Entities.Bio>();

            CreateMap<Repository.Domain.Models.BioReadModel, Repository.Domain.Models.BioUpdateModel>();

        }

    }
}
