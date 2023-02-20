using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Helpers.BSTable;
using System.Globalization;

namespace Web.API;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly Repository.Context.BigContext _ctx;

    public StudentsController()
    {
        _ctx = new BigContext(new DbContextOptions<BigContext>());
    }


    /// <summary>
    /// Contoh dengan menggunakan kombinasi LinQ dan Lambda Expression
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpGet("GetFromLinQ")]
    public async Task<IActionResult> GetWithLinQ()
    {
        try
        {
            var query =
                from s in _ctx.Students
                join b in _ctx.Bios
                    on s.BioId equals b.Id
                join g in _ctx.Grades
                    on s.GradeId equals g.Id
                let dtBirthDate = DateTime.ParseExact(b.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                let iAge = DateTime.Now.Year - dtBirthDate.Year
                select new
                {
                    StudentName = b.Name,
                    Grade = g.Name,
                    Age = iAge,
                    b.Height,
                    b.Weight
                };

            var result = await query.ToListAsync();
            return result is not null && result.Any() ? Ok(result) : throw new Exception("There are no registered student.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("GetFrowView")]
    public async Task<IActionResult> Get([FromQuery] Request param)
    {
        try
        {
            var query = _ctx.VCompiledStudents.AsQueryable();
            var result = new Response<Repository.Data.Entities.vCompiledStudent>
            {
                TotalNotFiltered = await query.CountAsync()
            };

            if (!string.IsNullOrWhiteSpace(param.Search) && !string.IsNullOrEmpty(param.Search))
            {
                #pragma warning disable CS8618 
                query = query.Where(
                    x => 
                        x.Name.Contains(param.SearchUpper())
                        ||
                        x.Grade.Contains(param.SearchUpper())
                        ||
                        x.Age.Equals(param.Search)
                        ||
                        x.Height.Equals(param.Search)
                        ||
                        x.Weight.Equals(param.Search)
                );
                #pragma warning restore CS8618
            }

            if (!string.IsNullOrWhiteSpace(param.Sort))
            {
                switch (param.Sort)
                {
                    case "name":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name); break;

                    case "grade":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Grade) : query.OrderBy(x => x.Grade); break;

                    case "age":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Age) : query.OrderBy(x => x.Age); break;

                    case "height":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Height) : query.OrderBy(x => x.Height); break;

                    case "weight":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Weight) : query.OrderBy(x => x.Weight); break;

                    default: break;
                }
            }

            result.Total = await query.CountAsync();
            result.Rows = await query.Skip(param.Offset).Take(param.Limit).ToListAsync();

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
