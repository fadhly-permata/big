using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class StudentsUpdateModelValidator
        : AbstractValidator<StudentsUpdateModel>
    {
        public StudentsUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
