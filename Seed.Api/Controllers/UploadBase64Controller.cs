using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Seed.Api.Controllers
{
    [Authorize]
    [Route("api/document/upload")]
    public class UplaodController : Controller
    {

        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;
        private readonly string _uploadRoot;

        public UplaodController(ILoggerFactory logger, IHostingEnvironment env)
        {
            this._logger = logger.CreateLogger<UplaodController>();
            this._env = env;
            this._uploadRoot = "upload";
        }

        [HttpPost]
        public async Task<IActionResult> Post(ICollection<IFormFile> files, string folder, bool rename = true)
        {
            var result = new HttpResult<List<string>>(this._logger);
            try
            {
                var uploads = Path.Combine(this._env.ContentRootPath, this._uploadRoot, folder);
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var fileSuccess = new List<string>();

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        if (rename)
                            fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        fileSuccess.Add(fileName);
                    }
                }

                return result.ReturnCustomResponse(fileSuccess);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - Upload");
            }
        }

        [HttpDelete("{folder}/{fileName}")]
        public async Task<IActionResult> Delete(string folder, string fileName)
        {
            var result = new HttpResult<List<string>>(this._logger);
            try
            {
                var uploads = Path.Combine(this._env.ContentRootPath, this._uploadRoot, folder);
                await Task.Run(() =>
                {
                    new FileInfo(Path.Combine(uploads, fileName)).Delete();
                });
                return result.ReturnCustomResponse();

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Seed - upload");
            }
        }
    }
}