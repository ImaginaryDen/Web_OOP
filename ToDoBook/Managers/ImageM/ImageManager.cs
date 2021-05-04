using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage;
using ToDoBook.Storage.Entity;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ToDoBook.Managers.ImageM
{
	public class ImageManager
	{
		WorkContext _context;
		IWebHostEnvironment _appEnvironment;

		public ImageManager(WorkContext context)
		{
			_context = context;
		}

		public async void AddImage(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/Files/" + uploadedFile.FileName;
				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}
				ImageUsers file = new ImageUsers { Name = uploadedFile.FileName, Path = path };
				_context.Images.Add(file);
				_context.SaveChanges();
			}
		}
	}
}
