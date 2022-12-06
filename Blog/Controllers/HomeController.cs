using Blog.Data;
using Blog.Repositories;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers {
	public class HomeController : Controller {
		private readonly IPostRepository postRepository;
		private readonly IFileManager fileManager;

		public HomeController(
			IPostRepository postRepository,
			IFileManager fileManager
		) {
			this.postRepository = postRepository;
			this.fileManager = fileManager;
		}

		public async Task<IActionResult> Index() {
			var vm = new HomeViewModel {
				Posts = await this.postRepository.GetPostsAsync()
			};
			return View(vm);
		}

		[HttpGet("/image/{image}")]
		public IActionResult Image(string image) {
			var mimeType = image.Substring(image.LastIndexOf('.') + 1);

			return new FileStreamResult(this.fileManager.ImageStream(image), $"image/{mimeType}");
		}
	}
}
