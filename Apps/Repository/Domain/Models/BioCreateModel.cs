using System;
using System.Collections.Generic;

namespace Repository.Domain.Models
{
    public partial class BioCreateModel
    {
        #region Generated Properties
        // public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public long Height { get; set; }

        public long Weight { get; set; }

        #endregion

    }
}
