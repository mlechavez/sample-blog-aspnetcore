using Blog.ViewModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.Controllers {

    [Route("admin")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller {
        private readonly IPostRepository postRepository;
        private readonly IFileManager fileManager;

        public AdminController(
            IPostRepository postRepository,
            IFileManager fileManager) {
            this.postRepository = postRepository;
            this.fileManager = fileManager;
        }

        [HttpGet]
        [Route("posts/")]
        public async Task<IActionResult> GetPosts() {
            var posts = await this.postRepository.GetPostsAsync();
            return View("postlist", posts);
        }

        [HttpGet]
        [Route("posts/{id}")]
        public async Task<IActionResult> CreateOrUpdatePost(string id) {
            PostViewModel vm;
            if (id == "new")
                vm = new PostViewModel();
            else {
                var post = await this.postRepository.GetPostAsync(Convert.ToInt32(id));

                vm = new PostViewModel {
                    Id = post.Id,
                    Title = post.Title,
                    Summary = post.Summary,
                    Body = post.Body,
                    ImageUrl = post.Image
                };
            }

            return View("updatepost", vm);
        }

        [HttpPost]
        [Route("posts/{id}")]
        public async Task<IActionResult> CreateOrUpdatePost(PostViewModel vm) {

            if (vm.Id == 0) {
				var post = new Post {
					Title = vm.Title,
					Body = vm.Body,
					Image = await this.fileManager.SaveImage(vm.Image)
				};
				this.postRepository.Add(post);
            } else {
                var post = await this.postRepository.GetPostAsync(vm.Id);
                post.Title = vm.Title;
                post.Summary = vm.Summary;
                post.Body = vm.Body;

                if (vm.Image != null)
                    post.Image = await this.fileManager.SaveImage(vm.Image);
                else
                    post.Image = vm.ImageUrl;

				this.postRepository.Update(post);
            }

            if (await postRepository.SaveAsync())
                return RedirectToAction("getposts");

            return View(vm);
        }

        [HttpDelete]
        [Route("posts/deletepost/{id}")]
        public async Task<IActionResult> DeletePost(int id) {
            this.postRepository.Remove(id);
            var result = await this.postRepository.SaveAsync();
            return Json(result);
        }
    }
}
