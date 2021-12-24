#pragma checksum "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79d85afbaf3e7f941ca64636b3a4a74332504270"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Animal_Index), @"mvc.1.0.view", @"/Views/Animal/Index.cshtml")]
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
#line 1 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\_ViewImports.cshtml"
using AnimalShelter.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\_ViewImports.cshtml"
using AnimalShelter.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79d85afbaf3e7f941ca64636b3a4a74332504270", @"/Views/Animal/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f9c945f4b0e3d29bd3703f8478a7d15ae1005a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Animal_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AnimalShelter.WebApp.Models.AnimalVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
  
    ViewData["Title"] = "Animals in shelter";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\" style=\"display: flex\">\r\n    <h1 style=\"width: 50%\">Animals in shelter</h1>\r\n    <p style=\"width: 50%\" align=\"right\">\r\n        <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 286, "\"", 343, 3);
            WriteAttributeValue("", 296, "location.href=\'", 296, 15, true);
#nullable restore
#line 10 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
WriteAttributeValue("", 311, Url.Action("Create", "Animal"), 311, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 342, "\'", 342, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" style=""padding: 10px; background-color: #008CBA; color: white; border: 0px; border-radius: 5px"">Register new animal</button>
    </p>
</div>


<table class=""table"">
    <thead>
        <tr>
            <th>
                ID
            </th>
            <th>
                Shelter box ID
            </th>
            <th>
                Main doctor ID
            </th>
            <th>
                Name
            </th>
            <th>
                Ready for adoption
            </th>
            <th>
                Actions
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 39 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.BoxId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MainDoctorId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
                Write(item.IsReadyForAdoption? "YES" : "NO");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 59 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 62 "C:\Users\kamil\Documents\GitHub\animal-shelter-app\AnimalShelter.WebApp\Views\Animal\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AnimalShelter.WebApp.Models.AnimalVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
