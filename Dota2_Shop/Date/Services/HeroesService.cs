using Dota2_Shop.Date.Base;
using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date.Services
{
    public class HeroesService : EntityBaseRepository<Hero>, IHeroesService
    {
        public HeroesService(AppDbContext context) : base(context)
        {

        }
    }
}