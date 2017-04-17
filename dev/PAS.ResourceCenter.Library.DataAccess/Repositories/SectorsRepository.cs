using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace PAS.ResourceCenter.Library.DataAccess.Repositories
{
    public class SectorsRepository : ISectorsRepository
    {
        private bbwContext db;

        public SectorsRepository(bbwContext dbContext)
        {
            db = dbContext;
        }

        public SectorDTO Create(SectorDTO newSector)
        {
            db.Sector.Add(newSector);
            db.SaveChanges();

            return newSector;
        }
        public SectorDTO Update(SectorDTO updatedSector)
        {
            var sector = db.Sector.FirstOrDefault(x => x.Id.Equals(updatedSector.Id));
            sector.Name = updatedSector.Name;
            db.SaveChanges();

            return updatedSector;
        }

        public SectorDTO Get(int Id)
        {
            return db.Sector.Select(x =>
                new SectorDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefault(x => x.Id.Equals(Id));
        }

        public ICollection<SectorDTO> GetAll()
        {
            return db.Sector.Select(x =>
                new SectorDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
    }
}
