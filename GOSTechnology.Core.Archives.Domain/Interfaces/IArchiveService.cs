using GOSTechnology.Core.Archives.Domain.BindingModels;
using GOSTechnology.Core.Archives.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOSTechnology.Core.Archives.Domain.Interfaces
{
    /// <summary>
    /// IArchiveService.
    /// </summary>
    public interface IArchiveService
    { 
        public Task<Boolean> InsertArchiveBase64(ArchiveBase64BindingModel bindingModel);
        public Task<Boolean> InsertArchiveFormData(ArchiveStreamBindingModel bindingModel);
        public Task<ArchiveBase64ViewModel> GetArchiveBase64(String archiveId);
        public Task<ArchivePathViewModel> GetArchivePath(String basePath, String archiveId);
        public Task<IEnumerable<ArchiveBase64ViewModel>> ListArchiveBase64(String userToken);
        public Task<IEnumerable<ArchivePathViewModel>> ListArchivePath(String basePath, String userToken);
    }
}
