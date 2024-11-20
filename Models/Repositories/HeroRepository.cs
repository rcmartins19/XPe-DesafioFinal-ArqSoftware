using System;
using DesafioFinalRodrigoMartins.Data;
using DesafioFinalRodrigoMartins.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinalRodrigoMartins.Models.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly AppDbContext _context;

        public HeroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Hero hero)
        {
            await _context.Heroes.AddAsync(hero);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await _context.Heroes.ToListAsync();
        }

        public async Task<Hero> GetById(int id)
        {
            return await _context.Heroes.FindAsync(id);
        }

        public async Task<IEnumerable<Hero>> GetByName(string name)
        {
            return await _context.Heroes.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task Update(Hero hero)
        {
            _context.Heroes.Update(hero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Hero hero)
        {
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await _context.Heroes.CountAsync();
        }
    }

}
