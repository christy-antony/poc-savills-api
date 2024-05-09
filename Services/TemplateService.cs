using poc_savills_api.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace poc_savills_api.Services
{
    public class TemplateService : ITemplateService
    {
        public byte[] GetTemplateAsByteArray(string templateName) => ConvertFilesToByteArray(templateName);

        private byte[] ConvertFilesToByteArray(string templateName) 
        {
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "Public", templateName);
            return File.ReadAllBytes(path);
        }
    }
}
