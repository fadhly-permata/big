using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Queries
{
    public static partial class StudentsExtensions
    {
        #region Generated Extensions
        public static Repository.Data.Entities.Students? GetByKey(this IQueryable<Repository.Data.Entities.Students> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Students> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Repository.Data.Entities.Students?> GetByKeyAsync(this IQueryable<Repository.Data.Entities.Students> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Students> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Repository.Data.Entities.Students?>(task);
        }

        #endregion

    }
}
