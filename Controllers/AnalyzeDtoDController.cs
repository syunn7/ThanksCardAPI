using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzeDtoDController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AnalyzeDtoDController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalyzeDtoD>>> GetAnalyzeDtoDs()
        {
            // ThanksCard を受け取った回数をカウントしてリストで返す
            return await _context.ThanksCards
                                             .Include(ThanksCard => ThanksCard.To)
                                             .Include(ThanksCard => ThanksCard.To.Organization)
                                             .Include(ThanksCard => ThanksCard.From)
                                             .Include(ThanksCard => ThanksCard.From.Organization)
                                             .GroupBy(x => new { ToId = x.To.Organization.OrganizationName, FromID = x.From.Organization.OrganizationName })
                                             .Select(x => new AnalyzeDtoD
                                             {
                                                 ToOrganizationName = x.Select(y => y.To.Organization.OrganizationName).ToList()[0]
                                                 ,
                                                 FromOrganizationName = x.Select(y => y.From.Organization.OrganizationName).ToList()[0]
                                                 ,
                                                 ThanksCount = x.Count()
                                             }
                                                 ).ToListAsync();
        }
    }
}