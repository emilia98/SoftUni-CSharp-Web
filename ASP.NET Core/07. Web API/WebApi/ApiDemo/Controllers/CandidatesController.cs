using ApiDemo.Data;
using ApiDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CandidatesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            return dbContext.Candidates.ToList();
        }

        [HttpGet("{id}")] // /api/candidates/123
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = dbContext.Candidates.FirstOrDefault(x => x.Id == id);

            if(candidate == null)
            {
                return this.NotFound();
                // return this.NotFound("not found..."); // DO NOT do this, it does not return the standard error response
            }

            return candidate;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> Post(Candidate candidate)
        {
            await this.dbContext.AddAsync(candidate);
            await this.dbContext.SaveChangesAsync();
            return this.Created($"/api/candidates/{candidate.Id}", candidate);
            // return this.CreatedAtAction("Get", new { id = candidate.Id }, candidate);
        }

        // PATCH
        // PUT /api/candidates/4
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Candidate candidate)
        {
            var dbCandidate = this.dbContext.Candidates.FirstOrDefault(x => x.Id == id);

            if(dbCandidate == null)
            {
                return this.NotFound();
            }

            // Parameter tampering
            dbCandidate.Names = candidate.Names;
            dbCandidate.YearsOfExperience = candidate.YearsOfExperience;

            await this.dbContext.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> Delete(int id)
        {
            var dbCandidate = this.dbContext.Candidates.FirstOrDefault(x => x.Id == id);

            if(dbCandidate == null)
            {
                return this.NotFound();
            }

            this.dbContext.Remove(dbCandidate);
            await this.dbContext.SaveChangesAsync();

            return dbCandidate;
        }
    }
}
