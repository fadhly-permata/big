using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Data.Queries;
using Helpers.BSTable;

namespace Web.API;

[ApiController]
[Route("api/[controller]")]
public class BioController : ControllerBase
{
    private readonly Repository.Context.BigContext _ctx;

    public BioController()
    {
        _ctx = new BigContext(new DbContextOptions<BigContext>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var result = await _ctx.Bios.GetByKeyAsync(id);
            return result is not null ? Ok(result) : throw new Exception("Bio is not registered.");
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
            var query = _ctx.Bios.AsQueryable();
            var result = new Response<Repository.Data.Entities.Bio>
            {
                TotalNotFiltered = await query.CountAsync()
            };

            if (!string.IsNullOrWhiteSpace(param.Search) && !string.IsNullOrEmpty(param.Search))
            {
                query = query.Where(
                    x => 
                        x.Name.Contains(param.SearchUpper())
                        ||
                        x.BirthDate.Contains(param.SearchUpper())
                        ||
                        x.Height.Equals(param.Search)
                        ||
                        x.Weight.Equals(param.Search)
                );
            }

            if (!string.IsNullOrWhiteSpace(param.Sort))
            {
                switch (param.Sort)
                {
                    case "id":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id); break;

                    case "name":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name); break;

                    case "birthDate":
                        query = param.Order != "asc" ? query.OrderByDescending(x => x.BirthDate) : query.OrderBy(x => x.BirthDate); break;

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

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _ctx.Bios.GetByKeyAsync(id);
            if (result is null) throw new Exception("Bio is not registered.");

            _ctx.Bios.Remove(result);
            await _ctx.SaveChangesAsync();

            return Ok("Deleted successfully.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Repository.Domain.Models.BioCreateModel bioInfo)
    {
        try
        {
            if (bioInfo is null) throw new ArgumentNullException(nameof(bioInfo));
            
            var nBio = new Repository.Data.Entities.Bio
            {
                Name = bioInfo.Name.ToUpper(),
                BirthDate = bioInfo.BirthDate,
                Height = bioInfo.Height,
                Weight = bioInfo.Weight
            };

            await _ctx.Bios.AddAsync(nBio);
            await _ctx.SaveChangesAsync();

            return Ok(nBio);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Repository.Domain.Models.BioUpdateModel bioInfo)
    {
        try
        {
            if (bioInfo is null) throw new ArgumentNullException(nameof(bioInfo));

            var cData = await _ctx.Bios.GetByKeyAsync(bioInfo.Id);
            if (cData is null) throw new Exception("Can not update unregistered Bio.");

            cData.Name = bioInfo.Name.ToUpper();
            cData.BirthDate = bioInfo.BirthDate;
            cData.Height = bioInfo.Height;
            cData.Weight = bioInfo.Weight;

            await _ctx.SaveChangesAsync();

            return Ok(cData);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
