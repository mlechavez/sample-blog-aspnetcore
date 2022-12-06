using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Repositories {
	public class PostRepository : IPostRepository {
		private readonly AppDbContext ctx;

		public PostRepository(AppDbContext ctx) {
			this.ctx = ctx;
		}

		public void Add(Post post) {
			this.ctx.Add(post);
		}

		public Task<Post> GetPostAsync(int id) {
			return this.ctx.Posts.FirstOrDefaultAsync(post => post.Id == id);
		}

		public Task<List<Post>> GetPostsAsync() {
			return this.ctx.Posts.ToListAsync();
		}

		public void Remove(int id) {
			this.ctx.Remove(this.ctx.Posts.Find(id));
		}
		public void Update(Post post) {
			this.ctx.Update(post);
		}

		public async Task<bool> SaveAsync() {
			return await this.ctx.SaveChangesAsync() > 0 ? true : false;
		}
	}
}
