using APIBackend.Database;
using APIBackend.Dto;
using APIBackend.Models;
using APIBackend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly EnterpriseInterface _enterpriseRepository;
        protected ResponseDto _response;

        public EnterpriseController(EnterpriseInterface enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
            _response = new ResponseDto();  
        }

        // GET: api/Enterprise

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enterprise>>> GetEnterprises()
        {
            try
             {
                 var listEnterprise = await _enterpriseRepository.GetEnterprises();
                 _response.Result = listEnterprise;
                 _response.Message = "Emterprise List";
             }
             catch (Exception e)
             {
                 _response.IsSuccess = false;
                 _response.Error = new List<string> { e.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Enterprise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(int id)
        {
            var enterprise = await _enterpriseRepository.GetEnterpriseById(id);
            if (enterprise==null)
            {
                _response.IsSuccess = false;
                _response.Message = "The enterprise does not exist";
                _response.Error = new List<string> { "The enterprise does not exist" };
                return NotFound(_response);
            }
            _response.Result = enterprise;
            _response.Message = "Enterprise information";
            return Ok(_response);
        }

        // PUT: api/Enterprise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprise(int id, EnterpriseDto enterpriseDto)
        {
            try
            {
                EnterpriseDto model = await _enterpriseRepository.CreateUpdateEnterprise(enterpriseDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch(Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = "Error updating enterprise";
                _response.Error = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        //  POST: api/enterprise
        [HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(int id, EnterpriseDto enterpriseDto)
        {
            try
            {
                EnterpriseDto model = await _enterpriseRepository.CreateUpdateEnterprise(enterpriseDto);
                _response.Result = model;
                return CreatedAtAction("GetEnterprise",new {id=model.Id},_response);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = "Error creating enterprise";
                _response.Error = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

    }
}
