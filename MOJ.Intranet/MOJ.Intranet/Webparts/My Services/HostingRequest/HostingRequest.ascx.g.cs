﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOJ.Intranet.Webparts.My_Services.HostingRequest {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class HostingRequest {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "16.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(HostingRequest target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "16.0.0.0")]
        private void @__BuildControlTree(global::MOJ.Intranet.Webparts.My_Services.HostingRequest.HostingRequest @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n<h4>طلب أستضافة\r\n</h4>\r\n\r\n<h4></h4>\r\n<div id=\"posts\" class=\"small-thumbs al" +
                        "t\">\r\n\r\n    <div class=\"tabs tabs-responsive clearfix fullwidthtabs\">\r\n\r\n        " +
                        "<ul class=\"tab-nav clearfix\">\r\n            <li><a href=\"#tab-responsive-1\">أستضا" +
                        "فة فندقية</a></li>\r\n            <li><a href=\"#tab-responsive-2\">حجز قاعة</a></li" +
                        ">\r\n        </ul>\r\n\r\n        <div class=\"tab-container\">\r\n\r\n            <div clas" +
                        "s=\"tab-content clearfix\" id=\"tab-responsive-1\">\r\n\r\n                <div class=\"i" +
                        "nskdnew inskdnew2\">\r\n\r\n                    <div class=\"row rt\">\r\n\r\n             " +
                        "           <div class=\"col-md-6\">\r\n\r\n                            <div class=\"row" +
                        "\">\r\n\r\n                                <div class=\"col-md-2\">\r\n                  " +
                        "                  <label>الاماره</label>\r\n                                </div>" +
                        "\r\n\r\n                                <div class=\"col-md-9\">\r\n                    " +
                        "                <select class=\"form-control\">\r\n                                 " +
                        "       <option>اختر</option>\r\n                                        <option>ال" +
                        "اماره </option>\r\n                                        <option>الاماره</option" +
                        ">\r\n                                    </select>\r\n                              " +
                        "  </div>\r\n                            </div>\r\n\r\n\r\n                        </div>" +
                        "\r\n                        <div class=\"col-md-6\">\r\n                        </div>" +
                        "\r\n                    </div>\r\n\r\n\r\n\r\n                    <div class=\"row\">\r\n     " +
                        "                   <div class=\"col-sm-12\">\r\n                            <div cla" +
                        "ss=\"table-responsive\">\r\n                                <table class=\"table tabl" +
                        "e-hover table-bordered newtableb\">\r\n                                    <thead>\r" +
                        "\n                                        <th>اسم الموظف</th>\r\n                  " +
                        "                      <th>المسمي الوظيفي</th>\r\n                                 " +
                        "       <th>الدرجة الوظيفبة</th>\r\n                                        <th>الف" +
                        "ترة من </th>\r\n                                        <th>الفترة الي</th>\r\n     " +
                        "                                   <th>المهمة</th>\r\n                            " +
                        "            <th>\r\n                                            <span class=\"fsiz " +
                        " icon-plus-sign\"></span>\r\n                                        </th>\r\n       " +
                        "                             </thead>\r\n\r\n                                    <tf" +
                        "oot>\r\n                                        <tr>\r\n                            " +
                        "                <td class=\"foot\" colspan=\"7\">\r\n\r\n\r\n                             " +
                        "                   <div class=\"pagi\">\r\n                                         " +
                        "           <ul class=\"pagination\">\r\n                                            " +
                        "            <li class=\"page-item\">\r\n                                            " +
                        "                <a class=\"page-link pageright\" href=\"#\">\r\n                      " +
                        "                                          <i class=\"icon-angle-right\"></i>\r\n    " +
                        "                                                        </a>\r\n                  " +
                        "                                      </li>\r\n                                   " +
                        "                     <li class=\"page-item\"><a class=\"page-link activepage\" href=" +
                        "\"#\">1</a></li>\r\n                                                        <li clas" +
                        "s=\"page-item\"><a class=\"page-link\" href=\"#\">2</a></li>\r\n                        " +
                        "                                <li class=\"page-item\"><a class=\"page-link\" href=" +
                        "\"#\">3</a></li>\r\n                                                        <li clas" +
                        "s=\"page-item\"><a class=\"page-link\" href=\"#\">4</a></li>\r\n                        " +
                        "                                <li class=\"page-item\"><a class=\"page-link\" href=" +
                        "\"#\">5</a></li>\r\n                                                        <li clas" +
                        "s=\"page-item\"><a class=\"page-link\" href=\"#\">6</a></li>\r\n                        " +
                        "                                <li class=\"page-item\"><a class=\"page-link\" href=" +
                        "\"#\">7</a></li>\r\n                                                        <li clas" +
                        "s=\"page-item\"><a class=\"page-link\" href=\"#\">8</a></li>\r\n                        " +
                        "                                <li class=\"page-item\"><a class=\"page-link\" href=" +
                        "\"#\">9</a></li>\r\n                                                        <li clas" +
                        "s=\"page-item\"><a class=\"page-link\" href=\"#\">10</a></li>\r\n                       " +
                        "                                 <li class=\"page-item\">\r\n                       " +
                        "                                     <a class=\"page-link pageleft\" href=\"#\">\r\n  " +
                        "                                                              <i class=\"icon-ang" +
                        "le-left\"></i>\r\n                                                            </a>\r" +
                        "\n                                                        </li>\r\n                " +
                        "                                    </ul>\r\n                                     " +
                        "           </div>\r\n                                            </td>\r\n\r\n        " +
                        "                                </tr>\r\n                                    </tfo" +
                        "ot>\r\n                                    <tr>\r\n                                 " +
                        "       <td>محمد اكمل بت</td>\r\n                                        <td>الفريق" +
                        " المتصدر</td>\r\n                                        <td>A++</td>\r\n           " +
                        "                             <td>24/12/2006</td>\r\n                              " +
                        "          <td>24/12/2009</td>\r\n                                        <td>فصل ك" +
                        "انتا شموليةً كل</td>\r\n                                        <td>\r\n\r\n          " +
                        "                                  <span class=\"icon-trash-alt\"></span>\r\n        " +
                        "                                </td>\r\n                                    </tr>" +
                        "\r\n                                    <tr>\r\n                                    " +
                        "    <td>محمد اكمل بت</td>\r\n                                        <td>الفريق ال" +
                        "متصدر</td>\r\n                                        <td>A++</td>\r\n              " +
                        "                          <td>24/12/2006</td>\r\n                                 " +
                        "       <td>24/12/2009</td>\r\n                                        <td>فصل كانت" +
                        "ا شموليةً كل</td>\r\n                                        <td>\r\n\r\n             " +
                        "                               <span class=\"icon-trash-alt\"></span>\r\n           " +
                        "                             </td>\r\n                                    </tr>\r\n " +
                        "                                   <tr>\r\n                                       " +
                        " <td>محمد اكمل بت</td>\r\n                                        <td>الفريق المتص" +
                        "در</td>\r\n                                        <td>A++</td>\r\n                 " +
                        "                       <td>24/12/2006</td>\r\n                                    " +
                        "    <td>24/12/2009</td>\r\n                                        <td>فصل كانتا ش" +
                        "موليةً كل</td>\r\n                                        <td>\r\n\r\n                " +
                        "                            <span class=\"icon-trash-alt\"></span>\r\n              " +
                        "                          </td>\r\n                                    </tr>\r\n\r\n  " +
                        "                                  <tr>\r\n                                        " +
                        "<td>محمد اكمل بت</td>\r\n                                        <td>الفريق المتصد" +
                        "ر</td>\r\n                                        <td>A++</td>\r\n                  " +
                        "                      <td>24/12/2006</td>\r\n                                     " +
                        "   <td>24/12/2009</td>\r\n                                        <td>فصل كانتا شم" +
                        "وليةً كل</td>\r\n                                        <td>\r\n\r\n                 " +
                        "                           <span class=\"icon-trash-alt\"></span>\r\n               " +
                        "                         </td>\r\n                                    </tr>\r\n     " +
                        "                               <tr>\r\n                                        <td" +
                        ">محمد اكمل بت</td>\r\n                                        <td>الفريق المتصدر</" +
                        "td>\r\n                                        <td>A++</td>\r\n                     " +
                        "                   <td>24/12/2006</td>\r\n                                        " +
                        "<td>24/12/2009</td>\r\n                                        <td>فصل كانتا شمولي" +
                        "ةً كل</td>\r\n                                        <td>\r\n\r\n                    " +
                        "                        <span class=\"icon-trash-alt\"></span>\r\n                  " +
                        "                      </td>\r\n                                    </tr>\r\n        " +
                        "                        </table>\r\n                            </div>\r\n\r\n        " +
                        "                </div>\r\n                    </div>\r\n\r\n\r\n\r\n                </div>" +
                        "\r\n\r\n\r\n            </div>\r\n            <div class=\"tab-content clearfix\" id=\"tab-" +
                        "responsive-2\">\r\n                <div class=\"inskdnew\">\r\n\r\n                    <d" +
                        "iv class=\"row rt\">\r\n\r\n                        <div class=\"col-md-6\">\r\n\r\n        " +
                        "                    <div class=\"row\">\r\n\r\n                                <div cl" +
                        "ass=\"col-md-2\">\r\n                                    <label>الاماره</label>\r\n   " +
                        "                             </div>\r\n\r\n                                <div clas" +
                        "s=\"col-md-9\">\r\n                                    <select class=\"form-control\">" +
                        "\r\n                                        <option>اختر</option>\r\n               " +
                        "                         <option>دبي</option>\r\n                                 " +
                        "       <option>3</option>\r\n                                    </select>\r\n      " +
                        "                          </div>\r\n                            </div>\r\n\r\n\r\n      " +
                        "                  </div>\r\n                        <div class=\"col-md-6\">\r\n\r\n\r\n  " +
                        "                          <div class=\"row\">\r\n                                <di" +
                        "v class=\"col-md-6\">\r\n\r\n\r\n\r\n                                    <input type=\"radi" +
                        "o\"\r\n                                        name=\"common-radio-name\"\r\n          " +
                        "                              id=\"radio-1\"\r\n                                    " +
                        "    class=\"radio-button\" />\r\n                                    <label for=\"rad" +
                        "io-1\"\r\n                                        class=\"radio-button-click-target\"" +
                        ">\r\n                                        <span class=\"radio-button-circle\"></s" +
                        "pan>ديوان عام الوزارة\r\n                                    </label>\r\n\r\n\r\n\r\n\r\n\r\n " +
                        "                               </div>\r\n\r\n                                <div cl" +
                        "ass=\"col-md-6\">\r\n                                    <input type=\"radio\"\r\n      " +
                        "                                  name=\"common-radio-name\"\r\n                    " +
                        "                    id=\"radio-2\"\r\n                                        class=" +
                        "\"radio-button\" />\r\n                                    <label for=\"radio-2\"\r\n   " +
                        "                                     class=\"radio-button-click-target\">\r\n       " +
                        "                                 <span class=\"radio-button-circle\"></span>قاعة ف" +
                        "ندقية\r\n                                    </label>\r\n\r\n\r\n                       " +
                        "         </div>\r\n                            </div>\r\n\r\n\r\n                       " +
                        " </div>\r\n                    </div>\r\n\r\n\r\n                    <div class=\"row rt\"" +
                        ">\r\n\r\n                        <div class=\"col-md-6\">\r\n\r\n                         " +
                        "   <div class=\"row\">\r\n\r\n                                <div class=\"col-md-2\">\r\n" +
                        "                                    <label>عدد الاشخاص</label>\r\n                " +
                        "                </div>\r\n\r\n                                <div class=\"col-md-9\">" +
                        "\r\n                                    <input type=\"text\" class=\"form-control\" pl" +
                        "aceholder=\"\">\r\n                                </div>\r\n                         " +
                        "   </div>\r\n\r\n\r\n                        </div>\r\n                        <div clas" +
                        "s=\"col-md-6\">\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n\r" +
                        "\n                    <div class=\"row rt\">\r\n\r\n                        <div class=" +
                        "\"col-md-6\">\r\n\r\n                            <div class=\"row\">\r\n\r\n                " +
                        "                <div class=\"col-md-2\">\r\n                                    <lab" +
                        "el>اليوم</label>\r\n                                </div>\r\n\r\n                    " +
                        "            <div class=\"col-md-9\">\r\n\r\n                                    <div c" +
                        "lass=\"input-group date\" data-provide=\"datepicker\">\r\n                            " +
                        "            <input type=\"text\" class=\"form-control\">\r\n                          " +
                        "              <div class=\"input-group-addon\">\r\n                                 " +
                        "           <span class=\"icon-calendar-alt1\"></span>\r\n                           " +
                        "             </div>\r\n                                    </div>\r\n\r\n             " +
                        "                   </div>\r\n                            </div>\r\n\r\n\r\n             " +
                        "           </div>\r\n                        <div class=\"col-md-6\">\r\n\r\n\r\n         " +
                        "                   <div class=\"row newrowtime\">\r\n\r\n                             " +
                        "   <div class=\"col-md-2\">\r\n                                    <label>الوقت</lab" +
                        "el>\r\n                                </div>\r\n\r\n                                <" +
                        "div class=\"col-md-3\">\r\n\r\n                                    <div class=\"input-g" +
                        "roup timenew\">\r\n                                        <input id=\"timepicker\" c" +
                        "lass=\"timepicker form-control\" />\r\n                                        <div " +
                        "class=\"input-group-addon\">\r\n                                            <span cl" +
                        "ass=\"icon-calendar-alt1\"></span>\r\n                                        </div>" +
                        "\r\n                                    </div>\r\n\r\n                                " +
                        "</div>\r\n\r\n                                <div class=\"col-md-3\">\r\n\r\n            " +
                        "                        <div class=\"input-group timenew\">\r\n                     " +
                        "                   <input id=\"timepicker\" class=\"timepicker form-control\" />\r\n  " +
                        "                                      <div class=\"input-group-addon\">\r\n         " +
                        "                                   <span class=\"icon-calendar-alt1\"></span>\r\n   " +
                        "                                     </div>\r\n                                   " +
                        " </div>\r\n\r\n                                </div>\r\n                             " +
                        "   <div class=\"col-md-4\">\r\n\r\n                                    <a href=\"#\" cla" +
                        "ss=\"morebutovn\">اضافة ايام\r\n                                                    " +
                        "                <span class=\"icon-plus-sign\"></span>\r\n                          " +
                        "          </a>\r\n\r\n                                </div>\r\n\r\n                    " +
                        "        </div>\r\n\r\n\r\n                        </div>\r\n                    </div>\r\n" +
                        "\r\n\r\n\r\n                    <div class=\"row rt fleb\">\r\n\r\n                        <" +
                        "div class=\"col-md-1\">\r\n\r\n                            <label>تفاصيل الحجز</label>" +
                        "\r\n\r\n\r\n                        </div>\r\n                        <div class=\"col-md" +
                        "-11\">\r\n\r\n                            <textarea class=\"form-control\" id=\"exampleF" +
                        "ormControlTextarea1\" rows=\"3\"></textarea>\r\n\r\n\r\n\r\n\r\n\r\n\r\n                        <" +
                        "/div>\r\n                    </div>\r\n\r\n\r\n\r\n                    <div class=\"row rt\"" +
                        ">\r\n\r\n\r\n                        <div class=\"col-md-12\">\r\n\r\n                      " +
                        "      <h5>المطلوب توفيره\r\n                            </h5>\r\n                   " +
                        "         <div>\r\n                                <input type=\"checkbox\"\r\n        " +
                        "                            class=\"checkbox\"\r\n                                  " +
                        "  id=\"checkbox-1\" />\r\n                                <label for=\"checkbox-1\"\r\n " +
                        "                                   class=\"checkbox-click-target\">\r\n             " +
                        "                       <span class=\"checkbox-box\"></span>عصائر\r\n                " +
                        "                </label>\r\n                                <input type=\"checkbox\"" +
                        "\r\n                                    class=\"checkbox\"\r\n                        " +
                        "            id=\"checkbox-2\" />\r\n                                <label for=\"chec" +
                        "kbox-2\"\r\n                                    class=\"checkbox-click-target\">\r\n   " +
                        "                                 <span class=\"checkbox-box\"></span>وجبات خفيفة\r\n" +
                        "                                </label>\r\n                                <input" +
                        " type=\"checkbox\"\r\n                                    class=\"checkbox\"\r\n        " +
                        "                            id=\"checkbox-3\" />\r\n                                " +
                        "<label for=\"checkbox-3\"\r\n                                    class=\"checkbox-cli" +
                        "ck-target\">\r\n                                    <span class=\"checkbox-box\"></sp" +
                        "an>وجبات رئيسية\r\n                                </label>\r\n                     " +
                        "       </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n " +
                        "                   <div class=\"row rt  botx\">\r\n\r\n                        <a href" +
                        "=\"#\" class=\"morebutovn2\">تقديم\r\n\r\n\r\n\r\n                        </a>\r\n            " +
                        "        </div>\r\n\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>" +
                        "\r\n\r\n    </div>\r\n\r\n</div>\r\n<!-- #posts end -->\r\n\r\n\r\n\r\n\r\n\r\n"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "16.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "16.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "16.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
