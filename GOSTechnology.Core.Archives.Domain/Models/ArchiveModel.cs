using GOSTechnology.Core.Archives.Domain.BindingModels;
using System;

namespace GOSTechnology.Core.Archives.Domain.Models
{
    public class ArchiveModel
    {
        public String ArchiveId { get; set; }
        public String ArchiveName { get; set; }
        public String UserToken { get; set; }
        public String ContentType { get; set; }

        public ArchiveModel()
        {

        }

        public ArchiveModel(Guid? archiveId, String contentType, ArchiveStreamBindingModel bindingModel)
        {
            this.ArchiveId = archiveId?.ToString();
            this.ArchiveName = bindingModel?.Archive?.FileName;
            this.UserToken = bindingModel?.UserToken;
            this.ContentType = contentType;
        }

        public ArchiveModel(Guid? archiveId, MimeTypeEnum mimeType, ArchiveBase64BindingModel bindingModel)
        {
            this.ArchiveId = archiveId?.ToString();
            this.ArchiveName = bindingModel?.ArchiveName;
            this.UserToken = bindingModel?.UserToken;

            switch (mimeType)
            {
                case MimeTypeEnum.IMAGE: this.ContentType = "image/png"; break;
                case MimeTypeEnum.PDF: this.ContentType = "application/pdf"; break;
                case MimeTypeEnum.DOCX: this.ContentType = "application/msword"; break;
                case MimeTypeEnum.PPT: this.ContentType = "application/vnd.ms-powerpoint"; break;
            }            
        }
    }
}
