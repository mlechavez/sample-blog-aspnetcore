using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Repositories {
	public interface IPostRepository {
		Task<List<Post>> GetPostsAsync();
		Task<Post> GetPostAsync(int id);
		void Add(Post post);
		void Update(Post post);
		void Remove(int id);
		Task<bool> SaveAsync();
	}
}
