using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class BioUpdateModelValidator
        : AbstractValidator<BioUpdateModel>
    {
        public BioUpdateModelValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.BirthDate).NotEmpty();
            #endregion
        }

    }
}
