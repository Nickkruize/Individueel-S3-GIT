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
using InternetGameDatabase.ViewModel;

namespace InternetGameDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.FindAll();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            Review review = _reviewRepository.GetByIdWithUserAndGame(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(ModelConverter.ReviewEntityToReadViewModel(review));
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _reviewRepository.Update(review);

            try
            {
                _reviewRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostReview(Review review)
        {
            _reviewRepository.Create(review);
            _reviewRepository.Save();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public ActionResult<Review> DeleteReview(int id)
        {
            Review review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            _reviewRepository.Delete(review);
            _reviewRepository.Save();

            return review;
        }

        private bool ReviewExists(int id)
        {
            if (_reviewRepository.GetById(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
