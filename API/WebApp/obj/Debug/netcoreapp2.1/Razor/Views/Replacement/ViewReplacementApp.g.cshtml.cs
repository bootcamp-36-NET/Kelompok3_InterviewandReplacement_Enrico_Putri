#pragma checksum "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\Replacement\ViewReplacementApp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "928acee29d1f72fb0574550223ffa2a90f33538d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Replacement_ViewReplacementApp), @"mvc.1.0.view", @"/Views/Replacement/ViewReplacementApp.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Replacement/ViewReplacementApp.cshtml", typeof(AspNetCore.Views_Replacement_ViewReplacementApp))]
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
#line 1 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#line 1 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\Replacement\ViewReplacementApp.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"928acee29d1f72fb0574550223ffa2a90f33538d", @"/Views/Replacement/ViewReplacementApp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dec085bf195b01abb92852e860e2ca042d6a2857", @"/Views/_ViewImports.cshtml")]
    public class Views_Replacement_ViewReplacementApp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Script/ReplacementStatus.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/sweetalert2@9.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\Replacement\ViewReplacementApp.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
            BeginContext(122, 705, true);
            WriteLiteral(@"
<div class=""content-wrapper"">
    <!-- START PAGE CONTENT-->
    <!-- Modal -->
    <div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header no-bd"">
                    <h5 class=""modal-title""><span class=""fw-mediumbold"">Request Replacement</span></h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""modal-body"">
                    ");
            EndContext();
            BeginContext(827, 1535, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "28e6f0bcdca642be9fd961862db96b56", async() => {
                BeginContext(833, 331, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <input type=""text"" id=""Id"" name=""Id"" class=""form-control"" hidden>
                            <div class=""col-sm-12"">
                                <div class=""form-group form-group-default"">
                                    <label>Employee</label>
");
                EndContext();
                BeginContext(1286, 105, true);
                WriteLiteral("                                    <input type=\"text\" id=\"Employee\" name=\"Employee\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1391, "\"", 1431, 1);
#line 28 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\Replacement\ViewReplacementApp.cshtml"
WriteAttributeValue("", 1399, Context.Session.GetString("id"), 1399, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1432, "\"", 1481, 1);
#line 28 "C:\Users\Cornelia Putri\Downloads\baru dari rico 29 sep\3 abis testing\API\WebApp\Views\Replacement\ViewReplacementApp.cshtml"
WriteAttributeValue("", 1446, Context.Session.GetString("uname"), 1446, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1482, 873, true);
                WriteLiteral(@" disabled />
                                </div>
                                <div class=""form-group form-group-default"">
                                    <label>Site</label>
                                    <select class=""form-control"" id=""SiteOption"" name=""SiteOption""></select>
                                </div>
                                <div class="""">
                                    <div class=""form-group form-group-default"">
                                        <label>Replacement Reason</label>
                                        <input type=""text"" id=""replacement_reason"" name=""replacement_reason"" class=""form-control"" placeholder=""Input Reason"">
                                    </div>
                                </div>
                            </div>
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2362, 893, true);
            WriteLiteral(@"
                </div>
                <div class=""modal-footer no-bd"">
                    <button type=""button"" id=""add"" class=""btn btn-outline-success"" data-dismiss=""modal"" onclick=""Save();"">Insert</button>
                    <button type=""button"" id=""update"" class=""btn btn-outline-warning"" data-dismiss=""modal"" onclick=""Update();"">Update</button>
                    <button type=""button"" class=""btn btn-outline-danger"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class=""page-heading"">
        <h1 class=""page-title"">Status Replacement</h1>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item"">
                <a href=""/""><i class=""la la-home font-20""></i></a>
            </li>
        </ol>
        <div data-toggle=""modal"" data-target=""#myModal"" onclick=""ClearScreen();"">
");
            EndContext();
            BeginContext(3471, 99, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"page-content fade-in-up\">\r\n        <div class=\"ibox\">\r\n");
            EndContext();
            BeginContext(3693, 633, true);
            WriteLiteral(@"            <div class=""ibox-body"">

                <table class=""table table-striped table-bordered table-hover"" id=""Replacements"" cellspacing=""0"" width=""100%"">
                    <thead>
                        <tr>
                            <th>No</th>
                            <th>Employee</th>
                            <th>Site</th>
                            <th>Replacement Reason</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <!-- END PAGE CONTENT-->
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4343, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4349, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5856d2834e8247f88fab0ec630b43cf5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4405, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4411, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5bf1c845e13423cbf20ce62cd3f6fc2", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4456, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(4461, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591