using App.Users.Data.Entities;
using App.Users.Data.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Users.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMapper _mapper;
        private readonly UsersContext _context;

        public UsersRepository(UsersContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var data = await _context.Usuarios.FindAsync(id);

            if (data == null)
                return false;

            _context.Usuarios.Remove(data);

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            return _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(decimal id)
        {
            var data = await this._context.Usuarios
                .FirstOrDefaultAsync(h => h.Id == id);

            return data!;
        }

        public async Task<bool> UpdateUserAsync(Usuario usuario)
        {
            var entity = await _context.Usuarios.FirstOrDefaultAsync(t => t.Id == usuario.Id);

            if (entity == null)
            {
                return false;
            }

            if (entity.Name != usuario.Name ||
                entity.Email != usuario.Email ||
                entity.Password != usuario.Password)
            {
                entity.Name = usuario.Name;
                entity.Email = usuario.Email;
                entity.Password = usuario.Password;

                _context.Update(entity);
                
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
