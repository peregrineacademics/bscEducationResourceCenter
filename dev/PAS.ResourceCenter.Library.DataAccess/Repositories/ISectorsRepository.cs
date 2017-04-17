using PAS.ResourceCenter.Library.DataAccess.DTO;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Repositories
{
    public interface ISectorsRepository
    {
        SectorDTO Create(SectorDTO newSector);
        SectorDTO Update(SectorDTO updatedSector);
        SectorDTO Get(int Id);
        ICollection<SectorDTO> GetAll();
    }
}