using GOSTechnology.Core.Archives.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOSTechnology.Core.Archives.Domain.Interfaces
{
    public interface IArchiveRepository
    {
        public Task<Boolean> InsertArchive(ArchiveModel model);
        public Task<ArchiveModel> FindOneArchive(String archiveId);
        public Task<IEnumerable<ArchiveModel>> ListArchives(String userToken);
    }
}
