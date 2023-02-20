using System;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Domain.Models;

namespace Repository.Domain.Mapping
{
    public partial class StudentsProfile
        : AutoMapper.Profile
    {
        public StudentsProfile()
        {
            CreateMap<Repository.Data.Entities.Students, Repository.Domain.Models.StudentsReadModel>();

            CreateMap<Repository.Domain.Models.StudentsCreateModel, Repository.Data.Entities.Students>();

            CreateMap<Repository.Data.Entities.Students, Repository.Domain.Models.StudentsUpdateModel>();

            CreateMap<Repository.Domain.Models.StudentsUpdateModel, Repository.Data.Entities.Students>();

            CreateMap<Repository.Domain.Models.StudentsReadModel, Repository.Domain.Models.StudentsUpdateModel>();

        }

    }
}
