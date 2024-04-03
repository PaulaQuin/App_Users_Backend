using App.Users.Business.Interface;
using App.Users.Commons.Dto;
using App.Users.Data.Entities;
using App.Users.Data.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Users.Business.Services
{
    public class UsuarioServices : IUsuariosService
    {

        private readonly IUsersRepository repository;
        private readonly IMapper mapper;

        public UsuarioServices(IUsersRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateAsync(UsuariosDto usuariosDto)
        {
            try
            {
                var entity = this.mapper.Map<Usuario>(usuariosDto);
                return await this.repository.CreateUserAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario", ex);
            }
        }


        public async Task<bool> DeleteAsync(DeleteDto id)
        {
            try
            {
                return await this.repository.DeleteUserAsync(id.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al eliminar", ex);
            }
        }

        public async Task<List<UsuariosDto>> GetAllAsync()
        {
            try
            {
                var data = await this.repository.GetAllAsync();

                if (data != null)
                {
                    return this.mapper.Map<List<UsuariosDto>>(data);
                }
                else
                {
                    throw new Exception("No se encontraron datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener todos los usuarios", ex);
            }
        }

        public async Task<UsuariosDto> GetByIdAsync(decimal id)
        {
            try
            {
                var data = await this.repository.GetByIdAsync(id);

                if (data != null)
                {
                    return this.mapper.Map<UsuariosDto>(data);
                }
                else
                {
                    throw new Exception("No se encontraron datos para el ID especificado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el usuario por su ID", ex);
            }
        }

        public async Task<bool> UpdateAsync(UsuariosDto usuariosDto)
        {
            try
            {
                var entity = this.mapper.Map<Usuario>(usuariosDto);
                var result = await this.repository.UpdateUserAsync(entity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el usuario", ex);
            }
        }
    }
}
