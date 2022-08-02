#pragma checksum "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a07fa8c61c56db5207c20dfb123b676c02dd45d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManagerCustomer_Index), @"mvc.1.0.view", @"/Views/ManagerCustomer/Index.cshtml")]
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
#line 1 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
using WebMVC.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a07fa8c61c56db5207c20dfb123b676c02dd45d", @"/Views/ManagerCustomer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ManagerCustomer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""products section bg-gray"" style=""height: 100vh"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-lg-2 title text-center"">
                        <h2>Manager</h2>
                        <ul class=""list-group"">
                            <li class=""list-group-item"" style=""margin-left: 5%""><a href=""/ManagerAccount/Index"">Account Manager</a></li>
                            <li class=""list-group-item"" style=""margin-left: 5%;background-color: #1bbb1b""><a href=""/ManagerCustomer/Index"">View Customer</a></li>
                            <li class=""list-group-item"" style=""margin-left: 5%""><a href=""/ManagerShipper/Index"">Shipper Manager</a></li>
                            <li class=""list-group-item"" style=""margin-left: 5%""><a href=""/ManagerProduct/Index"">Product Manager</a></li>
                            <li class=""list-group-item"" style=""margin-left: 5%""><a href=""/ManagerOrder/Index"">Order Manager</a></li>
                ");
            WriteLiteral(@"        </ul>
                    </div >
                    <div class=""col-lg-9 title text-center"" style=""margin-left: 3%"">
                        <h2>Detail</h2> 
                          <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>FullName</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Gender</th>
                                    <th>Username</th>
                                </tr>                            
                            </thead>
                            <tbody>
");
#nullable restore
#line 30 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                          
                           List<Customer> list = new DAOCustomer().GetAllCustomer();
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                         foreach(Customer customer in list)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                           <tr>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                   Write(customer.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 37 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                   Write(customer.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                   Write(customer.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                   Write(customer.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 40 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                    Write(customer.Gender ? "Male" : "Female");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                                   Write(customer.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                                 \r\n                                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\ManagerCustomer\Index.cshtml"
                        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n               \r\n            </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591