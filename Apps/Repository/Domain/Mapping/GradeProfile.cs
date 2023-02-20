using System;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Domain.Models;

namespace Repository.Domain.Mapping
{
    public partial class GradeProfile
        : AutoMapper.Profile
    {
        public GradeProfile()
        {
            CreateMap<Repository.Data.Entities.Grade, Repository.Domain.Models.GradeReadModel>();

            CreateMap<Repository.Domain.Models.GradeCreateModel, Repository.Data.Entities.Grade>();

            CreateMap<Repository.Data.Entities.Grade, Repository.Domain.Models.GradeUpdateModel>();

            CreateMap<Repository.Domain.Models.GradeUpdateModel, Repository.Data.Entities.Grade>();

            CreateMap<Repository.Domain.Models.GradeReadModel, Repository.Domain.Models.GradeUpdateModel>();

        }

    }
}
