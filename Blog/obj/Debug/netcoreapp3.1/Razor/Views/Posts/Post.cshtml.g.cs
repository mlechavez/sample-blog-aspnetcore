#pragma checksum "C:\Projects\tutorials\dotnet core\Blog\Blog\Views\Posts\Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62abbd76bbbebfd55ad0752e702b55a8c4f21c20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts_Post), @"mvc.1.0.view", @"/Views/Posts/Post.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Projects\tutorials\dotnet core\Blog\Blog\Views\_ViewImports.cshtml"
using Blog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\tutorials\dotnet core\Blog\Blog\Views\_ViewImports.cshtml"
using Blog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62abbd76bbbebfd55ad0752e702b55a8c4f21c20", @"/Views/Posts/Post.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60de8826b8954e9153bb5ddebbd8520bddd0a921", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Posts_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 3 "C:\Projects\tutorials\dotnet core\Blog\Blog\Views\Posts\Post.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<p>");
#nullable restore
#line 4 "C:\Projects\tutorials\dotnet core\Blog\Blog\Views\Posts\Post.cshtml"
Write(Model.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591