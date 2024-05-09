using poc_savills_api.Models;

namespace poc_savills_api.Services
{
    public interface ITemplateService
    {
        byte[] GetTemplateAsByteArray(string templateName);
    }
}
