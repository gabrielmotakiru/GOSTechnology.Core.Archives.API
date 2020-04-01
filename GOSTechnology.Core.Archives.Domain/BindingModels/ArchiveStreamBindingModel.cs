using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GOSTechnology.Core.Archives.Domain.BindingModels
{
    public class ArchiveStreamBindingModel
    {
        [Required(ErrorMessage = "O campo Archive é obrigatório.")]
        public IFormFile Archive { get; set; }

        [Required(ErrorMessage = "O campo UserToken é obrigatório.")]
        public String UserToken { get; set; }
    }
}
