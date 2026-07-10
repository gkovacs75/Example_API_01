using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.DTOs;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    // When adding this controller, be sure to choose api controoler, not mvc controller.

    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet("characters")] // another way: this is the route for the GetCharacters method, which will be api/VideoGameCharacters/characters
        public async Task<ActionResult<List<CharacterDto>>> GetCharacters() => Ok(await service.GetAllCharactersAsync());


        [HttpGet("{id}", Name = "GetCharacter")]
        //optional: [ProducesResponseType(StatusCodes.Status200OK)]
        //optional: [ProducesErrorResponseType(typeof(ProblemDetails))]  // This would be used if we were returning an IActionResult instead of ActionResult<T>.
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var c = await service.GetCharacterByIdAsync(id);

            if (c == null)
            {
                return NotFound($"Character with ID {id} was not found");
            }
            else
            {
                return Ok(c);
            }
        }

        [HttpPost(Name = "AddCharacter")]
        public async Task<ActionResult<CharacterDto>> AddCharacter(CharacterDto characterDTO)
        {
            var newCharacter = await service.AddCharacterAsync(characterDTO);

            // CreatedAtAction is an ASP.NET Core helper method that returns an HTTP 201 Created response,
            // signaling that a new resource has been successfully created.  Unlike a standard 200 OK response,
            // it automatically includes a Location header in the HTTP response, which contains the precise URL
            // to access the newly created resource. 

            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.Id }, newCharacter);
        }

        [HttpPut("{id}", Name = "UpdateCharacter")]
        public async Task<ActionResult<CharacterDto>> UpdateCharacter(int id, CharacterDto characterDTO)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid character ID");
            }

            var updatedCharacter = await service.UpdateCharacterAsync(id, characterDTO);
            if (updatedCharacter == null)
            {
                return NotFound($"Character with ID {id} was not found");
            }
            else
            {
                return Ok(updatedCharacter);
            }
        }

        [HttpDelete("{id}", Name = "DeleteCharacter")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            if (!deleted)
            {
                return NotFound($"Character with ID {id} was not found");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
