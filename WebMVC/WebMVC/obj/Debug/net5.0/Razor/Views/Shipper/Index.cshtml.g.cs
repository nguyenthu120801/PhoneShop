#pragma checksum "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0ac141b37b6fa658318c8cdb3e71c69cf3c2534"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shipper_Index), @"mvc.1.0.view", @"/Views/Shipper/Index.cshtml")]
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
#line 2 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0ac141b37b6fa658318c8cdb3e71c69cf3c2534", @"/Views/Shipper/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shipper_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""user-dashboard page-wrapper"" style=""height: 100vh"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""dashboard-wrapper user-dashboard"">
                            <div class=""table-responsive"" >
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>Order ID</th>
                                            <th>Customer Name</th>
                                            <th>Customer Phone</th>
                                            <th>Address</th>
                                            <th>Total Price</th>
                                            <th class=""col-md-2 col-sm-3"">Detail</th>
                                        </tr>
                                    </thead>
");
#nullable restore
#line 19 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                              
                                string username = ViewData["username"].ToString();
                                int ID = new DAOShipper().getID(username);
                                string sql = "select o.OrderID, c.FullName as CustomerName,c.phone,o.address,o.TotalPrice from [Order] o join Customer c on o.CustomerID = c.ID "
                                 + "where o.ShipID=" + ID;
                                DataTable data = new DAOShipper().getData(sql);
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                               <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                 foreach(DataRow dr in data.Rows)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 30 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                       Write(dr["OrderID"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 31 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                       Write(dr["CustomerName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 32 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                       Write(dr["phone"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 33 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                       Write(dr["address"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 34 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                       Write(dr["TotalPrice"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 2097, "\"", 2137, 2);
            WriteAttributeValue("", 2104, "/Shipper/Detail?ID=", 2104, 19, true);
#nullable restore
#line 35 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
WriteAttributeValue("", 2123, dr["OrderID"], 2123, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Detail</a></td>\r\n                                    </tr>\r\n");
#nullable restore
#line 37 "C:\Users\PC\Downloads\WebMVC\WebMVC\Views\Shipper\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                               </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n");
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
