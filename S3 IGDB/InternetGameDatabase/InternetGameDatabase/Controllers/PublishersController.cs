using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.ContextModel;
using InternetGameDatabase.Repository_Interfaces;

namespace InternetGameDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        // GET: api/Publishers
        [HttpGet]
        public IEnumerable<Publisher> GetPublishers()
        {
            return _publisherRepository.GetAll();
            //return  _publisherRepository.FindAll();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public IActionResult GetPublisher(int id)
        {
            Publisher publisher = _publisherRepository.GetByIdWithGames(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutPublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            _publisherRepository.Update(publisher);

            try
            {
                _publisherRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Publisher> PostPublisher(Publisher publisher)
        {
            _publisherRepository.Create(publisher);
            _publisherRepository.Save();

            return CreatedAtAction("GetPublisher", new { id = publisher.Id }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            Publisher publisher = _publisherRepository.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _publisherRepository.Delete(publisher);
            _publisherRepository.Save();

            return Ok(publisher);
        }

        private bool PublisherExists(int id)
        {
            if (_publisherRepository.GetById(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
