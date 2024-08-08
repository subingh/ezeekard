using EzeeKards.Common.Services.Interface;
using EzeeKards.Data.Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EzeeKards.Common.Helpers
{
    public static class FileConverter
    {
        private const string Separator = "[{()}]";

        public static async Task<string> Base64Image(IEnumerable<IFormFile> files)
        {
            var base64Strings = new List<string>();
            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var base64String = Convert.ToBase64String(memoryStream.ToArray());
                base64Strings.Add(base64String);
            }
            return string.Join(Separator, base64Strings);
        }
    }
}

