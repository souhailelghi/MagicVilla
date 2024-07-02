using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController] // for api to active the notations like :  [key] ,  [Required] ,   [MaxLength(30)]

    public class VillaAPIController : ControllerBase
    {
        // get all villas 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>>  GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        //GET Villa by id : 

        [HttpGet("{id:int}" )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
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


        //create a villa 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villaDto)
        {
            //validation of data model : like name is  [Required] 
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //custom validation : 
            if(VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower()==villaDto.Name.ToLower())!=null)
            {
                ModelState.AddModelError("CustomError", "Villa Already Exists");
                return BadRequest(ModelState);
            }


            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }
            if(villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);

            return  CreatedAtAction(nameof(GetVillaById), new { id = villaDto.Id }, villaDto);

        }


        //Method Delete
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }

            var Villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            VillaStore.villaList.Remove(Villa);
            return NoContent();
        }

    }
}
