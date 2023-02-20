using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Queries
{
    public static partial class BioExtensions
    {
        #region Generated Extensions
        public static Repository.Data.Entities.Bio? GetByKey(this IQueryable<Repository.Data.Entities.Bio> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Bio> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Repository.Data.Entities.Bio?> GetByKeyAsync(this IQueryable<Repository.Data.Entities.Bio> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Bio> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Repository.Data.Entities.Bio?>(task);
        }

        #endregion

    }
}
