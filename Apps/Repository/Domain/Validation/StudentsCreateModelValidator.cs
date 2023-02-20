using System;
using FluentValidation;
using Repository.Domain.Models;

namespace Repository.Domain.Validation
{
    public partial class StudentsCreateModelValidator
        : AbstractValidator<StudentsCreateModel>
    {
        public StudentsCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
