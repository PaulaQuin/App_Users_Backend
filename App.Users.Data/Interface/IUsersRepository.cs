using App.Users.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Data.Interface
{
    public interface IUsersRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<bool> CreateUserAsync(Usuario usuario);
        Task<bool> UpdateUserAsync(Usuario usuario);
        Task<bool> DeleteUserAsync(int id);
        Task<Usuario> GetByIdAsync(decimal id);
    }
}
