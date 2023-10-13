using Application.DTOs.MovieDtos;
using Application.Features.Commands.MovieCommands;
using Application.Features.Queries.MovieQueries;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {

        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<ActionResult<Movie>> Get()
        {
            var posts = await _mediator.Send(new GetMovieListQuery());
            return Ok(posts);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(Guid id)
        {
            var post = await _mediator.Send(new GetMovieByIdQuery{ Id = id });
            return Ok(post);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMovieDto Post)
        {
            var command = new CreateMovieCommand { CreateMovieDto = Post };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<MoviesController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDto movie)
        {
            var command = new UpdateMovieCommand { updateMovieDto = movie };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { Id= id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
