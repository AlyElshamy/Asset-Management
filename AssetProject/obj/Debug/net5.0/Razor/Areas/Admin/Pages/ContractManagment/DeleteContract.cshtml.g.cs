#pragma checksum "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9836e84bfd2af6cb060ef4eb5b7c74cabd5438f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AssetProject.Pages.Pages.ContractManagment.Areas_Admin_Pages_ContractManagment_DeleteContract), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/ContractManagment/DeleteContract.cshtml")]
namespace AssetProject.Pages.Pages.ContractManagment
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
#line 1 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\_ViewImports.cshtml"
using AssetProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\_ViewImports.cshtml"
using AssetProject.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9836e84bfd2af6cb060ef4eb5b7c74cabd5438f8", @"/Areas/Admin/Pages/ContractManagment/DeleteContract.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4af81190dfd656b48e72eab5a501053736df4aa8", @"/Areas/Admin/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_ContractManagment_DeleteContract : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ContractManagment/ContractList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""slim-mainpanel"">
      <div class=""container"">
        <div class=""slim-pageheader"">
          <ol class=""breadcrumb slim-breadcrumb"">
            <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
            <li class=""breadcrumb-item""><a href=""#"">Forms</a></li>
            <li class=""breadcrumb-item active"" aria-current=""page"">Form Layouts</li>
          </ol>
          <h6 class=""slim-pagetitle"">Contract Information</h6>
        </div><!-- slim-pageheader -->

 <div class=""section-wrapper"">
");
            WriteLiteral(@"
          <div class=""form-layout"">  
            <div class=""row mg-b-25"">
              <div class=""col-lg-4"">
                  <label class=""form-control-label"">Contact Title: <span class=""tx-danger"">*</span></label>
                  <div style=""font-size:xx-large"">");
#nullable restore
#line 26 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div><!-- col-4 -->\r\n\r\n              <div class=\"col-lg-4\">\r\n                  <label class=\"form-control-label\">Description: <span class=\"tx-danger\">*</span></label>\r\n                  <div style=\"font-size:xx-large\">");
#nullable restore
#line 31 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              </div><!-- col-4 -->

            
                 <div class=""col-lg-4"">
                  <label class=""form-control-label"">Contract No: <span class=""tx-danger"">*</span></label>
                  <div style=""font-size:xx-large"">");
#nullable restore
#line 37 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.ContractNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div><!-- col-4 -->\r\n             \r\n\r\n                 <div class=\"col-lg-4\">\r\n                  <label class=\"form-control-label\">Cost: <span class=\"tx-danger\">*</span></label>\r\n                  <div style=\"font-size:xx-large\">");
#nullable restore
#line 43 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div><!-- col-4 -->\r\n\r\n                 <div class=\"col-lg-4\">\r\n                  <label class=\"form-control-label\">Start Date: <span class=\"tx-danger\">*</span></label>\r\n                  <div style=\"font-size:xx-large\">");
#nullable restore
#line 48 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.StartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              </div><!-- col-4 -->

               
                 <div class=""col-lg-4"">
                  <label class=""form-control-label"">End Date: <span class=""tx-danger"">*</span></label>
                  <div style=""font-size:xx-large"">");
#nullable restore
#line 54 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.Contract.EndDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div><!-- col-4 -->\r\n   \r\n                 <div class=\"col-lg-4\">\r\n                  <label class=\"form-control-label\">Vendor: <span class=\"tx-danger\">*</span></label>\r\n                  <div style=\"font-size:xx-large\">");
#nullable restore
#line 59 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                             Write(Model.VendorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div><!-- col-4 -->\r\n\r\n         \r\n            </div><!-- row -->\r\n\r\n            <div class=\"form-layout-footer\">\r\n                 ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9836e84bfd2af6cb060ef4eb5b7c74cabd5438f89817", async() => {
                WriteLiteral("\r\n                   <input type=\"submit\" value=\'Delete\' class=\"btn btn-primary bd-0\"  >\r\n                        \r\n               ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9836e84bfd2af6cb060ef4eb5b7c74cabd5438f810214", async() => {
                    WriteLiteral("\r\n                 <input type=\'button\' class=\"btn btn-secondary bd-0\" value=\'Cancel\' />\r\n              ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                  ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\NoteBook\Desktop\cmder\Asset\AssetTracking\AssetProject\Areas\Admin\Pages\ContractManagment\DeleteContract.cshtml"
                                       WriteLiteral(Model.Contract.ContractId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n             \r\n            </div><!-- form-layout-footer -->\r\n       \r\n          </div><!-- form-layout -->\r\n        </div><!-- section-wrapper -->\r\n        \r\n      </div><!-- container -->\r\n    </div>\r\n\r\n    \r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n <script>\r\n\r\n \r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AssetProject.Areas.Admin.Pages.ContractManagment.DeleteContractModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AssetProject.Areas.Admin.Pages.ContractManagment.DeleteContractModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AssetProject.Areas.Admin.Pages.ContractManagment.DeleteContractModel>)PageContext?.ViewData;
        public AssetProject.Areas.Admin.Pages.ContractManagment.DeleteContractModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
