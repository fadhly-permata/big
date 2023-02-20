using System;
using System.Collections.Generic;

namespace Repository.Data.Entities
{
    public partial class Bio
    {
        public Bio()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public long Height { get; set; }

        public long Weight { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
