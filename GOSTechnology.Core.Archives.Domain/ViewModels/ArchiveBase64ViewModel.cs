using System;
using System.IO;

namespace GOSTechnology.Core.Archives.Domain.ViewModels
{
    public class ArchiveBase64ViewModel
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public String Base64 { get; set; }

        public ArchiveBase64ViewModel(String archiveName, String archiveType, String archivePath)
        {
            this.Name = archiveName;
            this.Type = archiveType;
            this.Base64 = Convert.ToBase64String(File.ReadAllBytes(archivePath));
        }
    }
}
