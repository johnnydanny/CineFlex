using Application.Contracts.Persistence;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CinemaRepository :  GenericRepository<Cinema>, ICinemaRepository
    {
        private readonly SocialSyncApplicationDbContext _context;
        public CinemaRepository(SocialSyncApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
      
    }
}
