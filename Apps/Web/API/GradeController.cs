using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Data.Queries;
using Helpers.BSTable;

namespace Web.API;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly Repository.Context.BigContext _ctx;

    public GradeController()
    {
        _ctx = new BigContext(new DbContextOptions<BigContext>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var result = await _ctx.Grades.GetByKeyAsync(id);
            return result is not null ? Ok(result) : throw new Exception("Grade is not registered.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Request param)
    {
        try
        {
            var query = _ctx.Grades.AsQueryable();
            var result = new Response<Repository.Data.Entities.Grade>
            {
                TotalNotFiltered = await query.CountAsync()
            };

            if (!string.IsNullOrWhiteSpace(param.Search) && !string.IsNullOrEmpty(param.Search))
            {
                query = query.Where(x => x.Name.Contains(param.SearchUpper()));
            }

            if (!string.IsNullOrWhiteSpace(param.Sort))
            {
                switch (param.Sort)
                {
                    case "id":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id); break;

                    case "name":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name); break;

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

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _ctx.Grades.GetByKeyAsync(id);
            if (result is null) throw new Exception("Grade is not registered.");

            _ctx.Grades.Remove(result);
            await _ctx.SaveChangesAsync();

            return Ok("Deleted successfully.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Repository.Domain.Models.GradeCreateModel gradeInfo)
    {
        try
        {
            if (gradeInfo is null) throw new ArgumentNullException(nameof(gradeInfo));
            var checkExistResult = await _ctx.Grades.CheckExistingForNew(gradeInfo);
            if (!string.IsNullOrEmpty(checkExistResult)) throw new Exception(checkExistResult);

            var nGrade = new Repository.Data.Entities.Grade
            {
                Name = gradeInfo.Name.ToUpper()
            };

            await _ctx.Grades.AddAsync(nGrade);
            await _ctx.SaveChangesAsync();

            return Ok(nGrade);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Repository.Domain.Models.GradeUpdateModel gradeInfo)
    {
        try
        {
            if (gradeInfo is null) throw new ArgumentNullException(nameof(gradeInfo));

            var cData = await _ctx.Grades.GetByKeyAsync(gradeInfo.Id);
            if (cData is null) throw new Exception("Can not update unregistered grade.");

            var checkExistResult = await _ctx.Grades.CheckExistingForUpdate(gradeInfo);
            if (!string.IsNullOrEmpty(checkExistResult)) throw new Exception(checkExistResult);

            cData.Name = gradeInfo.Name.ToUpper();
            await _ctx.SaveChangesAsync();

            return Ok(cData);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
