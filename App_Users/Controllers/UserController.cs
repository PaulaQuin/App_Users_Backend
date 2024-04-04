using App.Users.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using Microsoft.Extensions.Logging;
using App.Users.Commons.Dto;
using System.Security.Claims;

namespace App_Users.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuariosService service;

        public UserController(IUsuariosService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<UsuariosDto>?> Get()
        {
            List<UsuariosDto>? response = null;
            try
            {
                response = await service.GetAllAsync();

            }
            catch (Exception ex)
            {
                response = null;
                this.Response.StatusCode = 500;
            }

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> CreateUsers(UsuariosDto request)
        {
            try
            {
                return await service.CreateAsync(request);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<UsuariosDto?>> GetEdit(int request)
        {
            UsuariosDto? response = null;

            try
            {
                response = await this.service.GetByIdAsync(request);
            }
            catch (Exception ex)
            {
                response = null;
                this.Response.StatusCode = 500;
            }

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Update(UsuariosDto request)
        {
            try
            {
                return await this.service.UpdateAsync(request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Delete(DeleteDto id)
        {
            try
            {
                return await this.service.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
