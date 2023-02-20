using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class GradeUpdateModelValidator
        : AbstractValidator<GradeUpdateModel>
    {
        public GradeUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            #endregion
        }

    }
}
