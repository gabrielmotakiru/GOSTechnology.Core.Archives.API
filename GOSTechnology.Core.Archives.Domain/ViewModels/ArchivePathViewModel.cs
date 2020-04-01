using GOSTechnology.Core.Archives.Domain.Configurations;
using MimeTypes.Core;
using System;

namespace GOSTechnology.Core.Archives.Domain.ViewModels
{
    public class ArchivePathViewModel
    {
        public String Name { get; set; }
        public String Path { get; set; }

        public ArchivePathViewModel(String archiveName, String contentType, String basePath, String archiveId)
        {
            this.Name = $"{archiveName}";
            this.Path = $"{basePath}{String.Format(ConstantsConfiguration.PATH_IMAGES_SHOW, archiveId, MimeTypeMap.GetExtension(contentType))}";
        }
    }
}
