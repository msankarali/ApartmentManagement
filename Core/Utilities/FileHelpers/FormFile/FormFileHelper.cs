using System;
using System.IO;
using System.Linq;
using Core.Utilities.Validators;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelpers.FormFile
{
    public class FormFileHelper : IFormFileHelper
    {
        public (string[] savedFileUrls, string[] notSavedFileUrls) WriteFile(
            string uploadUrl = @"wwwroot\uploads",
            params IFormFile[] files)
        {
            var savedFileUrls = Array.Empty<string>();
            var notSavedFileUrls = Array.Empty<string>();
            int savedFileIndex = 0;
            int notSavedFileIndex = 0;
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    var fileName = $"{Guid.NewGuid()}-{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}-{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}{Path.GetExtension(files[i].FileName)}";

                    var path = Path.Combine(uploadUrl, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                        files[i].CopyTo(stream);

                    Array.Resize(ref savedFileUrls, savedFileIndex + 1);
                    savedFileUrls[i] = fileName;
                    savedFileIndex++;
                }
                catch (Exception)
                {
                    Array.Resize(ref notSavedFileUrls, notSavedFileIndex + 1);
                    notSavedFileUrls[notSavedFileIndex] = files[i].FileName;
                    notSavedFileIndex++;
                }
            }

            return (savedFileUrls, notSavedFileUrls);
        }

        public (string[] deletedFileUrls, string[] notDeletedFileUrls) DeleteFile(
            string uploadUrl = @"wwwroot\uploads",
            params string[] urls)
        {
            var deletedFileUrls = Array.Empty<string>();
            var notDeletedFileUrls = Array.Empty<string>();
            int deletedFileIndex = 0;
            int notDeletedFileIndex = 0;
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    if (File.Exists(uploadUrl + urls[i]))
                    {
                        File.Delete(uploadUrl + urls[i]);
                        Array.Resize(ref deletedFileUrls, deletedFileIndex + 1);
                        deletedFileUrls[deletedFileIndex] = urls[i];
                        deletedFileIndex++;
                    }
                    else
                    {
                        Array.Resize(ref notDeletedFileUrls, notDeletedFileIndex + 1);
                        notDeletedFileUrls[notDeletedFileIndex] = urls[i];
                        notDeletedFileIndex++;
                    }
                }
                catch
                {
                    Array.Resize(ref notDeletedFileUrls, notDeletedFileIndex + 1);
                    deletedFileUrls[notDeletedFileIndex] = urls[i];
                    notDeletedFileIndex++;
                }
            }

            return (deletedFileUrls, notDeletedFileUrls);
        }
    }
}