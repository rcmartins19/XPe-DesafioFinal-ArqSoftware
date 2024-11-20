using DesafioFinalRodrigoMartins.Models.Domains;

namespace DesafioFinalRodrigoMartins.Models.Repositories
{
    public interface IHeroRepository
    {
        Task Add(Hero hero);
        Task<IEnumerable<Hero>> GetAll();
        Task<Hero> GetById(int id);
        Task<IEnumerable<Hero>> GetByName(string name);
        Task Update(Hero hero);
        Task Delete(Hero hero);
        Task<int> Count();
    }

}
