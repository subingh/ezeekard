using EzeeKard.Models;
using EzeeKards.Data;
using EzeeKards.Dtos.Client;
using EzeeKards.Dtos;
using EzeeKards.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EzeeKards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var client = await _context.Client
                .Include(c => c.Companies)
                .Include(c => c.ExtraInfos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var clientDto = new ClientDto
            {
                Id = client.Id,
                ClientName = client.ClientName,
                ImageUrl = client.ImageUrl,
                Companies = client.Companies.Select(c => new CompanyDto
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    CompanyName = c.CompanyName,
                    CompanyLogo = c.CompanyLogo,
                    ExtraInfos = c.ExtraInfos.Select(e => new ExtraInfoDto
                    {
                        Id = e.Id,
                        ClientId = e.ClientId,
                        CompanyId = e.CompanyId,
                        Designation = e.Designation,
                        Country = e.Country,
                        State = e.State,
                        City = e.City,
                        Street = e.Street,
                        MapUrl = e.MapUrl,
                        PhoneNumber = e.PhoneNumber,
                        Email = e.Email,
                        Website = e.Website,
                        Description = e.Description,
                        SocialMedias = e.SocialMedias
                    }).ToList()
                }).ToList(),
                ExtraInfos = client.ExtraInfos.Select(e => new ExtraInfoDto
                {
                    Id = e.Id,
                    ClientId = e.ClientId,
                    CompanyId = e.CompanyId,
                    Designation = e.Designation,
                    Country = e.Country,
                    State = e.State,
                    City = e.City,
                    Street = e.Street,
                    MapUrl = e.MapUrl,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    Website = e.Website,
                    Description = e.Description,
                    SocialMedias = e.SocialMedias
                }).ToList()
            };

            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientDto clientDto)
        {
            var client = new Client
            {
                Id = clientDto.Id,
                ClientName = clientDto.ClientName,
                ImageUrl = clientDto.ImageUrl,
                Companies = clientDto.Companies.Select(c => new Company
                {
                    Id = c.Id,
                    ClientId = c.ClientId,
                    CompanyName = c.CompanyName,
                    CompanyLogo = c.CompanyLogo,
                    ExtraInfos = c.ExtraInfos.Select(e => new ExtraInfo
                    {
                        Id = e.Id,
                        ClientId = e.ClientId,
                        CompanyId = e.CompanyId,
                        Designation = e.Designation,
                        Country = e.Country,
                        State = e.State,
                        City = e.City,
                        Street = e.Street,
                        MapUrl = e.MapUrl,
                        PhoneNumber = e.PhoneNumber,
                        Email = e.Email,
                        Website = e.Website,
                        Description = e.Description,
                        SocialMedias = e.SocialMedias
                    }).ToList()
                }).ToList(),
 
            };

            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, clientDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientDto clientDto)
        {
            if (id != clientDto.Id)
            {
                return BadRequest();
            }

            var client = await _context.Client
                .Include(c => c.Companies)
                .Include(c => c.ExtraInfos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            client.ClientName = clientDto.ClientName;
            client.ImageUrl = clientDto.ImageUrl;

            // Update related companies
            foreach (var companyDto in clientDto.Companies)
            {
                var company = client.Companies.FirstOrDefault(c => c.Id == companyDto.Id);
                if (company != null)
                {
                    company.CompanyName = companyDto.CompanyName;
                    company.CompanyLogo = companyDto.CompanyLogo;

                    // Update related extra infos
                    foreach (var extraInfoDto in companyDto.ExtraInfos)
                    {
                        var extraInfo = company.ExtraInfos.FirstOrDefault(e => e.Id == extraInfoDto.Id);
                        if (extraInfo != null)
                        {
                            extraInfo.Designation = extraInfoDto.Designation;
                            extraInfo.Country = extraInfoDto.Country;
                            extraInfo.State = extraInfoDto.State;
                            extraInfo.City = extraInfoDto.City;
                            extraInfo.Street = extraInfoDto.Street;
                            extraInfo.MapUrl = extraInfoDto.MapUrl;
                            extraInfo.PhoneNumber = extraInfoDto.PhoneNumber;
                            extraInfo.Email = extraInfoDto.Email;
                            extraInfo.Website = extraInfoDto.Website;
                            extraInfo.Description = extraInfoDto.Description;
                            extraInfo.SocialMedias = extraInfoDto.SocialMedias;
                        }
                    }
                }
            }

            // Update related extra infos not connected to companies
            foreach (var extraInfoDto in clientDto.ExtraInfos.Where(e => e.CompanyId == Guid.Empty))
            {
                var extraInfo = client.ExtraInfos.FirstOrDefault(e => e.Id == extraInfoDto.Id);
                if (extraInfo != null)
                {
                    extraInfo.Designation = extraInfoDto.Designation;
                    extraInfo.Country = extraInfoDto.Country;
                    extraInfo.State = extraInfoDto.State;
                    extraInfo.City = extraInfoDto.City;
                    extraInfo.Street = extraInfoDto.Street;
                    extraInfo.MapUrl = extraInfoDto.MapUrl;
                    extraInfo.PhoneNumber = extraInfoDto.PhoneNumber;
                    extraInfo.Email = extraInfoDto.Email;
                    extraInfo.Website = extraInfoDto.Website;
                    extraInfo.Description = extraInfoDto.Description;
                    extraInfo.SocialMedias = extraInfoDto.SocialMedias;
                }
            }

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _context.Client
                .Include(c => c.Companies)
                .Include(c => c.ExtraInfos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
