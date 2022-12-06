using Microsoft.AspNetCore.Http;
using System;

namespace Blog.ViewModels {
    public class PostViewModel {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
