using Blog.Models;
using Blog.Repositories;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers {
	[Route("posts")]
	public class PostsController : Controller {
		private readonly IPostRepository postRepository;

		public PostsController(IPostRepository postRepository) {
			this.postRepository = postRepository;
		}
		public IActionResult Index() {
			return View();
		}

		[Route("{id}")]
		public async Task<IActionResult> GetPostDetail(int id) {
			var post = await this.postRepository.GetPostAsync(id);
			var vm = new PostViewModel {
				Id = post.Id,
				Title = post.Title,
				Summary = post.Summary,
				Body = post.Body,
				ImageUrl = post.Image
			};
			return View("post", vm);
		}
	}
}
