using Dota2_Shop.Date.Base;
using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date.Services
{
    public class ArtifactsService : EntityBaseRepository<Artifact>, IArtifactsService
    {
        private readonly AppDbContext _context;
        public ArtifactsService(AppDbContext context) : base(context) { }                
    }
}
