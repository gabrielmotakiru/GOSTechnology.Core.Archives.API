using System;
using System.ComponentModel.DataAnnotations;

namespace GOSTechnology.Core.Archives.Domain.BindingModels
{
    public class ArchiveBase64BindingModel
    {
        [Required(ErrorMessage = "O campo Base64 é obrigatório.")]
        public String Base64 { get; set; }

        [Required(ErrorMessage = "O campo ArchiveName é obrigatório.")]
        public String ArchiveName { get; set; }

        [Required(ErrorMessage = "O campo ArchiveType é obrigatório.")]
        public MimeTypeEnum ArchiveType { get; set; }

        [Required(ErrorMessage = "O campo UserToken é obrigatório.")]
        public String UserToken { get; set; }
    }
}
