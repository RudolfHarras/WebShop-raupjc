using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace WebShop_raupjc.Controllers
{
	public class UploadController : Controller
	{
		private readonly IHostingEnvironment _environment;


		public UploadController(IHostingEnvironment hostingEnvironment)
		{
			_environment = hostingEnvironment;
		}

		[HttpGet]
		public IActionResult UploadFile()
		{
			return View();
		}

		[HttpPost]
		public IActionResult UploadFile(string name)
		{
			if (HttpContext.Request.Form.Files != null)
			{
				var files = HttpContext.Request.Form.Files;

				foreach (var file in files)
				{
					if (file.Length > 0)
					{
						var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

						fileName = Path.Combine(_environment.WebRootPath, "Photos") + $@"\{fileName}";

						using (FileStream fs = System.IO.File.Create(fileName))
						{
							file.CopyTo(fs);
							fs.Flush();
						}
					}
				}


			}
			return View();
		}
	}
}