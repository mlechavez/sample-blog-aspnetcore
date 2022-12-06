using Blog.Models;
using System.Collections;
using System.Collections.Generic;

namespace Blog.ViewModels {
	public class HomeViewModel {
		public IEnumerable<Post> Posts { get; set; }
	}
}
