using CandidateApi.Data;
using CandidateApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var candidates = _context.Candidates.ToList();
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var candidate = _context.Candidates.FirstOrDefault(c => c.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidate candidate)
        {
            var candidateToUpdate = _context.Candidates.FirstOrDefault(c => c.Id == id);
            if (candidateToUpdate == null)
            {
                return NotFound();
            }
            candidateToUpdate.FullName = candidate.FullName;
            candidateToUpdate.Email = candidate.Email;
            candidateToUpdate.Address = candidate.Address;
            candidateToUpdate.BloodGroup = candidate.BloodGroup;
            candidateToUpdate.Age = candidate.Age;
            _context.SaveChanges();
            return Ok(candidateToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var candidateToDelete = _context.Candidates.FirstOrDefault(c => c.Id == id);
            if (candidateToDelete == null)
            {
                return NotFound();
            }
            _context.Candidates.Remove(candidateToDelete);
            _context.SaveChanges();
            return Ok(candidateToDelete);
        }

    }
}