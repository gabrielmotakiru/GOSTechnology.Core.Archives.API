using System;
using System.Collections.Generic;
using System.Text;

namespace GOSTechnology.Core.Archives.Domain.Configurations
{
    /// <summary>
    /// ConstantsConfiguration.
    /// </summary>
    public class ConstantsConfiguration
    {
        public const String API_CONTROLLER = "api/[controller]";
        public const String SWAGGER_ROUTE = "/swagger";
        public const String APP_SETTINGS = "appsettings.json";
        public const String GROUP_NAME_FORMAT = "VVV";
        public const String DOCUMENT_NAME = "v1";
        public const String API_NAME = "GOSTechnology.Core.Archives.Api";
        public const String API_VERSION = "v1.0.0";
        public const String KEY_HANDLER = "KeyHandler:key";
        public const String KEY_VALUE = "KeyHandler:value";
        public const String STATUS_CODE_200 = "O arquivo foi enviado com sucesso.";
        public const String STATUS_CODE_503 = "O arquivo não pôde ser salvo.";
        public const String STATUS_CODE_400 = "Informe todos os dados do arquivo.";
        public const String PATH_IMAGES = "wwwroot/images/{0}{1}";
        public const String PATH_IMAGES_SHOW = "/images/{0}{1}";
        public const String PATH_PDFS = "wwwroot/pdfs/{0}{1}";
        public const String PATH_PDFS_SHOW = "/pdfs/{0}{1}";
    }
}
