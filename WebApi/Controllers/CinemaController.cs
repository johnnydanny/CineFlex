using Application.DTOs.CinemaDtos;
using Application.DTOs.MovieDtos;
using Application.Features.Commands.CinemaCommands;
using Application.Features.Commands.MovieCommands;
using Application.Features.Queries.CinemaQueries;
using Application.Features.Queries.MovieQueries;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly IMediator _mediator;
        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        } 
        
        // GET: api/<CinemasController>
        [HttpGet]
        public async Task<ActionResult<Cinema>> Get()
        {
            var posts = await _mediator.Send(new GetCinemaListQuery());
            return Ok(posts);
        }


         // GET api/<CinemaController>/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Cinema>> Get(Guid id)
         {
             var post = await _mediator.Send(new GetCinemaByIdQuery { Id = id });
             return Ok(post);
         }

         // POST api/<CinemaController>
         [HttpPost]
         public async Task<ActionResult> Post([FromBody] CreateCinemaDto Post)
         {
             var command = new CreateCinemaCommand { CreateCinemaDto = Post };
             var response = await _mediator.Send(command);
             return Ok(response);
         }

         // PUT api/<CinemaController>
         [HttpPut]
         public async Task<ActionResult> Put([FromBody] UpdateCinemaDto cinema)
         {
             var command = new UpdateCinemaCommand { updateCinemaDto = cinema };
             await _mediator.Send(command);
             return NoContent();
         }

         // DELETE api/<CinemaController>/5
         [HttpDelete("{id}")]
         public async Task<ActionResult> Delete(Guid id)
         {
             var command = new DeleteCinemaCommand { Id = id };
             await _mediator.Send(command);
             return NoContent();
         }
    }
}
