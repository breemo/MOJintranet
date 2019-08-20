<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FazaaCardRequestWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.FazaaCardRequestWP.FazaaCardRequestWPUserControl" %>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, FazaaCardRequest%>" />
</h4>
  		
   <div id="posts" runat="server" class="small-thumbs alt">


    	 <div id="Edata">
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, FullNameArabic%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="EFullNameArabic" disabled runat="server" id="EFullNameArabic" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, FullNameEnglish%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="EFullNameEnglish" disabled runat="server" id="EFullNameEnglish" class="form-control" placeholder="">
                                </div> 
                              </div>
					    </div>                  
                    </div>
               <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeNumber%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="Enumber" runat="server" id="Enumber" class="form-control" placeholder="">
                                
									    </div>
                                                      
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                  <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="EDepartment" disabled runat="server" id="EDepartment" class="form-control" placeholder="">
                                </div> 
                              </div>
					    </div>                  
                    </div>
                     
               
               </div>

                   <hr />                    
         
              <div class="row rt">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-2">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Comment%>" /></label>
                        </div>
                        <div class="col-md-9">                        

                         <textarea class="form-control" runat="server" id="Comment" rows="4"></textarea>
                                
                        </div>
                    </div>
                </div>              
            </div>   
            <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>
        </div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div id="SuccessMsgDiv" runat="server" style="display:none">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<style>
.RadioButto table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;

}
</style>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>






