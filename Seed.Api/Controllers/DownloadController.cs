using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Seed.Api.Controllers;

namespace Seed.Api.Controllers
{
    [Route("api/document/download")]
    public class DownloadController : Controller
    {

        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;
        private readonly string _uploadRoot;

        public DownloadController(ILoggerFactory logger, IHostingEnvironment env)
        {
            this._logger = logger.CreateLogger<DownloadController>();
            this._env = env;
            this._uploadRoot = "upload";
        }

      
        [HttpGet("{folder}/{fileName}")]
        public async Task<IActionResult> Get(string folder, string fileName)
        {
            var uploads = Path.Combine(this._env.ContentRootPath, this._uploadRoot, folder);
            var filePath = $"{uploads}\\{fileName}";
            byte[] bytes;

            if (System.IO.File.Exists(filePath))
            {
                using (FileStream SourceStream = System.IO.File.Open(filePath, FileMode.Open))
                {
                    bytes = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(bytes, 0, (int)SourceStream.Length);
                }
                return File(bytes, "image/png");
            }

            var fileVazio = $"{uploads}\\vazio.png";

            using (FileStream SourceStream = System.IO.File.Open(fileVazio, FileMode.Open))
            {
                bytes = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(bytes, 0, (int)SourceStream.Length);
            }

            return File(bytes, "image/png");
        }
    }
}
