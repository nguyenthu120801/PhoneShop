#pragma checksum "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "216565067bace9a663977644014768c995fcdd4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
using WebMVC.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"216565067bace9a663977644014768c995fcdd4e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""products section bg-gray"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-lg-3 title text-center"">
                 <h2>Category</h2>
                 <ul class=""list-group"">
                      <li class=""list-group-item list-group-item-action list-group-item-warning"" ><a href=""/Home/Index"">ALL</a></li>
");
#nullable restore
#line 11 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                      
                        List<Category> listCategory = new DAOCategory().GetAllCategory();
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                     foreach(Category category in listCategory)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item list-group-item-action list-group-item-warning\"><a");
            BeginWriteAttribute("href", " href=\"", 765, "\"", 799, 2);
            WriteAttributeValue("", 772, "/Home/Index?ID=", 772, 15, true);
#nullable restore
#line 16 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 787, category.ID, 787, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                                                                                                                                    Write(category.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 17 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n            <div class=\"col-lg-9 title text-center\">\r\n                <h2>Product</h2>\r\n                <div class=\"row\" style=\"margin-left: 3%\">\r\n");
#nullable restore
#line 23 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                     foreach(Product product in Model)
                    {
                        if (product.isSell)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-lg-3 text-center\" style=\"border: 1px solid black; border-radius: 10px ; margin: 2%;margin-left: 3%; width: 20vw; height: 45vh\">\r\n                                <h5>");
#nullable restore
#line 28 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                               Write(product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1462, "\"", 1482, 1);
#nullable restore
#line 29 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1468, product.Image, 1468, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"alt\" width=\"100\" height=\"100\"><br>\r\n                                <p>Price: ");
#nullable restore
#line 30 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                                      Write(product.Price + "??");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <button class=\"posision-fixed\" style=\"radius: 10px\" ><a href=\"#\">Add to Cart</a></button>\r\n                            </div>\r\n");
#nullable restore
#line 33 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Home\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
