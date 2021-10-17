using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelpers.FormFile
{
    public interface IFormFileHelper
    {
        (string[] savedFileUrls, string[] notSavedFileUrls) WriteFile(
            string uploadUrl = @"wwwroot\uploads",
            params IFormFile[] files);
        (string[] deletedFileUrls, string[] notDeletedFileUrls) DeleteFile(
            string uploadUrl = @"wwwroot\uploads",
            params string[] urls);
    }
}