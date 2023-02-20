using System;
using AutoMapper;
using Repository.Data.Entities;
using Repository.Domain.Models;

namespace Repository.Domain.Mapping
{
    public partial class VCompiledStudentProfile
        : AutoMapper.Profile
    {
        public VCompiledStudentProfile()
        {
            CreateMap<Repository.Data.Entities.vCompiledStudent, Repository.Domain.Models.VCompiledStudentReadModel>();

            CreateMap<Repository.Domain.Models.VCompiledStudentCreateModel, Repository.Data.Entities.vCompiledStudent>();

            CreateMap<Repository.Data.Entities.vCompiledStudent, Repository.Domain.Models.VCompiledStudentUpdateModel>();

            CreateMap<Repository.Domain.Models.VCompiledStudentUpdateModel, Repository.Data.Entities.vCompiledStudent>();

            CreateMap<Repository.Domain.Models.VCompiledStudentReadModel, Repository.Domain.Models.VCompiledStudentUpdateModel>();

        }

    }
}
