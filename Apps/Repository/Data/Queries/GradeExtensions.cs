using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Queries
{
    public static partial class GradeExtensions
    {
        #region Generated Extensions
        public static Repository.Data.Entities.Grade? GetByKey(this IQueryable<Repository.Data.Entities.Grade> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Grade> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<Repository.Data.Entities.Grade?> GetByKeyAsync(this IQueryable<Repository.Data.Entities.Grade> queryable, long id)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            if (queryable is DbSet<Repository.Data.Entities.Grade> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<Repository.Data.Entities.Grade?>(task);
        }

        #endregion
        public static async ValueTask<string> CheckExistingForNew(this IQueryable<Repository.Data.Entities.Grade> queryable, Repository.Domain.Models.GradeCreateModel gradeInfo)
        {
            if (queryable is null) throw new ArgumentNullException(nameof(queryable));
            if (gradeInfo is null) throw new ArgumentNullException(nameof(gradeInfo));

            if (queryable is DbSet<Repository.Data.Entities.Grade> dbSet)
            {
                if (await dbSet.AsNoTracking().AnyAsync(x => string.Equals(x.Name, gradeInfo.Name))) return $"Grade with name \"{gradeInfo.Name}\" is already used.";
            }
            else
            {
                if (await queryable.AsNoTracking().AnyAsync(x => string.Equals(x.Name, gradeInfo.Name))) return $"Grade with name \"{gradeInfo.Name}\" is already used.";
            }

            return "";
        }

        public static async ValueTask<string> CheckExistingForUpdate(this IQueryable<Repository.Data.Entities.Grade> queryable, Repository.Domain.Models.GradeUpdateModel gradeInfo)
        {
            if (queryable is null) throw new ArgumentNullException(nameof(queryable));
            if (gradeInfo is null) throw new ArgumentNullException(nameof(gradeInfo));

            if (queryable is DbSet<Repository.Data.Entities.Grade> dbSet)
            {
                if (await dbSet.AsNoTracking().Where(x => !x.Id.Equals(gradeInfo.Id)).AnyAsync(x => string.Equals(x.Name, gradeInfo.Name))) return $"Grade with name \"{gradeInfo.Name}\" is already used.";
            }
            else
            {
                if (await queryable.AsNoTracking().Where(x => !x.Id.Equals(gradeInfo.Id)).AnyAsync(x => string.Equals(x.Name, gradeInfo.Name))) return $"Grade with name \"{gradeInfo.Name}\" is already used.";
            }

            return "";
        }
    }
}
