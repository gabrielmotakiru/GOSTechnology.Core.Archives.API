using GOSTechnology.Core.Archives.Domain.BindingModels;
using GOSTechnology.Core.Archives.Domain.Configurations;
using GOSTechnology.Core.Archives.Domain.Interfaces;
using GOSTechnology.Core.Archives.Domain.Models;
using GOSTechnology.Core.Archives.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MimeTypes.Core;

namespace GOSTechnology.Core.Archives.Domain.Services
{
    /// <summary>
    /// ArchiveService.
    /// </summary>
    public class ArchiveService : IArchiveService
    {
        /// <summary>
        /// _archiveRepository.
        /// </summary>
        private readonly IArchiveRepository _archiveRepository;

        /// <summary>
        /// ArchiveService.
        /// </summary>
        public ArchiveService(IArchiveRepository archiveRepository)
        {
            this._archiveRepository = archiveRepository;
        }

        /// <summary>
        /// InsertArchiveFormData.
        /// </summary>
        /// <param name="bindingModel"></param>
        /// <returns></returns>
        public async Task<Boolean> InsertArchiveFormData(ArchiveStreamBindingModel bindingModel)
        {
            Boolean result = false;
            ArchiveModel model = null;
            Guid archiveId = Guid.NewGuid();
            String extension = MimeTypeMap.GetExtension(bindingModel?.Archive?.ContentType);
            String archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archiveId, extension);
            FileStream archiveStream = new FileStream(archivePath, FileMode.Create, FileAccess.Write);

            try
            {
                bindingModel?.Archive?.OpenReadStream()?.CopyTo(archiveStream);
                archiveStream.Dispose();

                if (!(File.ReadAllBytes(archivePath) is null))
                {
                    model = new ArchiveModel(archiveId, bindingModel?.Archive?.ContentType, bindingModel);
                    
                    result = await this._archiveRepository.InsertArchive(model);

                    if (!result)
                    {
                        File.Delete(archivePath);
                    }
                }
            }
            catch(Exception exception)
            {
                if (!(File.ReadAllBytes(archivePath) is null))
                {
                    File.Delete(archivePath);
                }

                throw exception;
            }

            return result;
        }

        /// <summary>
        /// InsertArchiveBase64.
        /// </summary>
        /// <param name="bindingModel"></param>
        /// <returns></returns>
        public async Task<Boolean> InsertArchiveBase64(ArchiveBase64BindingModel bindingModel)
        {
            Boolean result = false;
            ArchiveModel model = null;
            Guid archiveId = Guid.NewGuid();
            String archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archiveId);

            try
            {
                File.WriteAllBytes(archivePath, Convert.FromBase64String(bindingModel.Base64));

                if (!(File.ReadAllBytes(archivePath) is null))
                {
                    model = new ArchiveModel(archiveId, bindingModel.ArchiveType, bindingModel);
                    
                    result = await this._archiveRepository.InsertArchive(model);

                    if (!result)
                    {
                        File.Delete(archivePath);
                    }
                }
            }
            catch (Exception exception)
            {
                if (!(File.ReadAllBytes(archivePath) is null))
                {
                    File.Delete(archivePath);
                }

                throw exception;
            }

            return result;
        }

        /// <summary>
        /// GetArchiveBase64.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        public async Task<ArchiveBase64ViewModel> GetArchiveBase64(String archiveId)
        {
            ArchiveBase64ViewModel result = null;
            ArchiveModel archive = (await _archiveRepository.FindOneArchive(archiveId));
            String extension = MimeTypeMap.GetExtension(archive?.ContentType);
            String archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archiveId, extension);

            if (!(File.ReadAllBytes(archivePath) is null) && (!(archive is null)))
            {
                result = new ArchiveBase64ViewModel(archive.ArchiveName, archive.ContentType, archivePath);
            }

            return result;
        }

        /// <summary>
        /// GetArchivePath.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        public async Task<ArchivePathViewModel> GetArchivePath(String basePath, String archiveId)
        {
            ArchivePathViewModel result = null;
            ArchiveModel archive = (await _archiveRepository.FindOneArchive(archiveId));
            String extension = MimeTypeMap.GetExtension(archive?.ContentType);
            String archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archiveId, extension);
            String archiveName = (await _archiveRepository.FindOneArchive(archiveId))?.ArchiveName;

            if (!(File.ReadAllBytes(archivePath) is null) && !String.IsNullOrWhiteSpace(archiveName))
            {
                result = new ArchivePathViewModel(archiveName, archive.ContentType, basePath, archiveId);
            }

            return result;
        }

        /// <summary>
        /// ListArchiveBase64.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ArchiveBase64ViewModel>> ListArchiveBase64(String userToken)
        {
            List<ArchiveBase64ViewModel> result = null;
            IEnumerable<ArchiveModel> listArchives = await _archiveRepository.ListArchives(userToken);
            String archivePath = String.Empty;
            String extension = String.Empty;

            if (!(listArchives is null) && listArchives.Any())
            {
                result = new List<ArchiveBase64ViewModel>();

                listArchives?.ToList()?.ForEach(archive =>
                {
                    extension = MimeTypeMap.GetExtension(archive?.ContentType);
                    archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archive?.ArchiveId, extension);
                    result.Add(new ArchiveBase64ViewModel(archive?.ArchiveName, archive?.ContentType, archivePath));
                });
            }

            return result;
        }

        /// <summary>
        /// ListArchivePath.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ArchivePathViewModel>> ListArchivePath(String basePath, String userToken)
        {
            List<ArchivePathViewModel> result = null;
            IEnumerable<ArchiveModel> listArchives = await _archiveRepository.ListArchives(userToken);
            String archivePath = String.Empty;
            String extension = String.Empty;

            if (!(listArchives is null) && listArchives.Any())
            {
                result = new List<ArchivePathViewModel>();

                listArchives?.ToList()?.ForEach(archive =>
                {
                    extension = MimeTypeMap.GetExtension(archive?.ContentType);
                    archivePath = String.Format(ConstantsConfiguration.PATH_IMAGES, archive?.ArchiveId, extension);
                    result.Add(new ArchivePathViewModel(archive?.ArchiveName, archive?.ContentType, basePath, archive.ArchiveId));
                });
            }

            return result;
        }
    }
}
