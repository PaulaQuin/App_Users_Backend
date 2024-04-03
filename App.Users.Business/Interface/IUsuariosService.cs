using App.Users.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Business.Interface
{
    public interface IUsuariosService
    {
        Task<List<UsuariosDto>> GetAllAsync();
        Task<bool> CreateAsync(UsuariosDto usuariosDto);
        Task<bool> UpdateAsync(UsuariosDto usuariosDto);
        Task<bool> DeleteAsync(DeleteDto id);
        Task<UsuariosDto> GetByIdAsync(decimal id);
    }
}
