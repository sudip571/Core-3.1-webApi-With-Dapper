using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FD.BLL.Models.Reference;
using FD.BLL.Models.Response;
using FD.BLL.Services.Reference;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Serilog;



namespace FD.API.Controllers
{
    [Route("api/reference")]
    [Authorize]
    [ApiController]
    public class Reference : ControllerBase
    {
        private readonly IReferenceService _referenceService;
        public Reference(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }
        // GET: api/reference        
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = _referenceService.GetAll();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);
            }   
            
        }

        // GET api/reference/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var result = _referenceService.GetById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);
            }
        }

        // POST api/reference
        [HttpPost]
        public ActionResult Post([FromBody] CovidTestModel model)
        {
            try
            {
                _referenceService.Add(model);
                var successModel = new Status()
                {
                    StatusCode=200,
                    Message = "Added Successfully"
                };
                return Ok(successModel);
            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);
            }
        }

        // PUT api/reference/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CovidTestModel model)
        {
            
            try
            {
                _referenceService.Update(model);
                var successModel = new Status()
                {
                    StatusCode = 200,
                    Message = "Updated Successfully"
                };
                return Ok(successModel);
            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);
            }
        }

        // DELETE api/reference/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _referenceService.Delete(id);
                var successModel = new Status()
                {
                    StatusCode = 200,
                    Message = "Deleted Successfully"
                };
                return Ok(successModel);

            }
            catch (Exception ex)
            {
                var errorModel = new Status()
                {
                    Message = ex.Message
                };
                Log.Error(ex, ex.Message);
                return StatusCode(500, errorModel);

            }
        }
    }
}
