using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class BioCreateModelValidator
        : AbstractValidator<BioCreateModel>
    {
        public BioCreateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.BirthDate).NotEmpty();
            #endregion
        }

    }
}
