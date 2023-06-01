using MagicVilla_VIllaAPI.Data;
using MagicVilla_VIllaAPI.Models;
using MagicVilla_VIllaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VIllaAPI.Controllers
{ 
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        //[HttpGet("id")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        //[ProducesResponseType(200 , Type = typeof(VillaDTO))]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if(villa==null) 
            {
                return NotFound();
            }
            return Ok(villa);
        }
    }
}
