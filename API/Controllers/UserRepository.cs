using System;
using API.Data;
using API.DTO;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
  public async Task<MemberDto?> GetMemberAsync(string username)
  {
    return await context.Users
    .Where(x => x.Username == username)
    .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
    .SingleOrDefaultAsync();
  }

  public async Task<IEnumerable<MemberDto>> GetMembersAsync()
  {
    return await context.Users
    .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
    .ToListAsync();
  }

  public async Task<AppUser?> GetUserByIdAsync(int id)
  {
    return await context.Users.FindAsync(id);
  }

  public async Task<AppUser?> GetUserByUsernameAsync(string username)
  {
    return await context.Users
    .Include(p => p.Photos)
    .SingleOrDefaultAsync(x => x.Username == username);
  }

  public async Task<IEnumerable<AppUser>> GetUsersAsync()
  {
    return await context.Users
    .Include(p => p.Photos)
    .ToListAsync(); ;
  }


  public async Task<bool> SaveAllAsync()
  {
    return await context.SaveChangesAsync() > 0;
  }

  public void Update(AppUser user)
  {
    context.Entry(user).State = EntityState.Modified;
  }
}
