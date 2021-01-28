using JOB_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailController : ControllerBase
    {
        private readonly JobDetailContext _context;

        public JobDetailController(JobDetailContext context)
        {
            _context = context;
        }

        // GET: api/JobDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetail>>> GetJobDetails()
        {
            return await _context.JobDetails.ToListAsync();
        }

        // GET: api/JobDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetail>> GetJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);

            if (jobDetail == null)
            {
                return NotFound();
            }

            return jobDetail;
        }

        // PUT: api/JobDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDetail(int id, JobDetail jobDetail)
        {
            if (id != jobDetail.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDetail>> PostJobDetail(JobDetail jobDetail)
        {
            _context.JobDetails.Add(jobDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDetail", new { id = jobDetail.JobId }, jobDetail);
        }

        // DELETE: api/JobDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetail(int id)
        {
            var jobDetail = await _context.JobDetails.FindAsync(id);
            if (jobDetail == null)
            {
                return NotFound();
            }

            _context.JobDetails.Remove(jobDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDetailExists(int id)
        {
            return _context.JobDetails.Any(e => e.JobId == id);
        }

    }
}
