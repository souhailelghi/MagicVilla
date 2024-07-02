using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        // get all villas 
        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>>  GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        //GET Villa by id : 

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDto> GetVillaById(int id)
        {
            if(id ==0)
            {
                return BadRequest("add id different 0");
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);


            if(villa == null)
            {
                return NotFound("not found");
            }


            return Ok(villa);
        }
         
        

    }
}
