#pragma checksum "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43201bf8ef148298f530469bcfb48bc5c00080a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(IceSync.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace IceSync.Pages
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
#line 1 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\_ViewImports.cshtml"
using IceSync;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43201bf8ef148298f530469bcfb48bc5c00080a4", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1710e02ab686eb82951f3c7f220d13fbbe0db869", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43201bf8ef148298f530469bcfb48bc5c00080a43434", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Workflow Name
            </th>
            <th>
                Is Active
            </th>
            <th>
                Is Running
            </th>
            <th>
                MultiExec Behaviour
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 31 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
         foreach (var item in Model.Workflows)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.WorkflowName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsRunning));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MultiExecBehaviour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
               Write(Html.ActionLink("Delete", "DeleteWorkflow", "Workflows", new { id = item.WorkflowId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n\r\n                    <button");
            BeginWriteAttribute("id", " id=\"", 1229, "\"", 1250, 1);
#nullable restore
#line 49 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
WriteAttributeValue("", 1234, item.WorkflowId, 1234, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1251, "\"", 1290, 3);
            WriteAttributeValue("", 1261, "runWorkFlow(", 1261, 12, true);
#nullable restore
#line 49 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
WriteAttributeValue("", 1273, item.WorkflowId, 1273, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1289, ")", 1289, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Run</button> |\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 52 "C:\Users\lorik\Downloads\TestLeadConsult\IceSync\IceSync\Pages\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
<script>

    function runWorkFlow(id)
    {
        $.ajax({
            url: ""api/Workflows/RunWorkFlow"",
            type: ""POST"",
            data: { id: id },
            async: false,
            success: function (data) {
                if(data===""True"")
                {
                    alert(""Successfuly ran workflow."");
                }
                else
                {
                    alert(""Workflow run failed!"");
                }
        }
    });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
