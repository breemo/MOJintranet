<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTaskUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.ViewTask.ViewTaskUserControl" %>
<style>
.evenRow{
background-color: #f5e9b6;

}
.rt {
    margin-bottom: 5px;
    
}
.RequestTitle {
    background-color: #bd995d;
    color: white;
    font-size: 19px;
    padding-right: 3px;
}

</style>
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, WorkflowTask%>" />
</h4>

<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">
      <div class="tab-container">        
                <div class="inskdnew">
                    <asp:Label id="TitleData" runat="server"></asp:Label>
                    </div>
          </div>
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
                 
           <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Nationality%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="ENationality" disabled runat="server" id="ENationality" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>                  
                    </div>
               
           <div class="row rt">
                        <div class="col-md-6">
                           <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, MaritalStatus%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EMaritalStatus" runat="server" id="EMaritalStatus" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Email%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EEmail" runat="server" id="EEmail" class="form-control" placeholder="">
                                </div>                       
                            </div>
					    </div>                  
                    </div>
               </div>

                   <hr />  
        <div class="tab-container">        
                <div class="inskdnew">
                    <asp:Label id="AllData" runat="server"></asp:Label>
                   <hr />
                    &nbsp;<div class="row rt">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-3">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AssignTo%>" /></label>
                                </div>
                                <div class="col-md-9">
                                     <asp:Label id="ValTaskName" runat="server"></asp:Label>                       
                                </div>
                              </div>
                            </div>
                     </div>                   
                     <div class="row rt">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-3">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                </div>
                                <div class="col-md-9">
                                    <textarea class="form-control" runat="server" id="txtMission" rows="3"></textarea>
                                </div>
                             </div>
                            </div>
                         </div>
                   
                    <div class="row rt  botx">
                       <asp:Label id="LabelAnswer" runat="server"></asp:Label>
                    </div>
                    <div class="row rt  botx">
                        <asp:Button Text="<%$ Resources:Resource, Approve%>" CssClass="morebutovn2" runat="server" ID="btnapprove" OnClick="btnapprove_Click" />
                       <asp:Button Text="<%$ Resources:Resource, Reject%>" CssClass="morebutovn2" runat="server" ID="btReject" OnClick="btnReject_Click" />
                       
                    </div>
                </div>
            </div>      

    </div>


<!-- #posts end -->
<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>