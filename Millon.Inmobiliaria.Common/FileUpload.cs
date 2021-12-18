using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Common
{
    /// <summary>
    /// Utilidad para cargar archivos 
    /// </summary>
    public class FileUpload
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileToUpload">PathFile</param>
        /// <returns>string</returns>
        public string SenFile(IFormFile FileToUpload, string PathFile, ref string Message)
        {
            var pathFileSave = Path.Combine(Directory.GetCurrentDirectory(), PathFile, FileToUpload.FileName);
            try
            {
                using var stream = new FileStream(pathFileSave, FileMode.Create);
                FileToUpload.CopyTo(stream);
            }
            catch (Exception)
            {
                Message = Messages.Registro_Sin_Imagen;
            }
            return pathFileSave;
        }
    }
}
