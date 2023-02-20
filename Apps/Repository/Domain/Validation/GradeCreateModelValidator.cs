using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class GradeCreateModelValidator
        : AbstractValidator<GradeCreateModel>
    {
        public GradeCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            #endregion
        }

    }
}
