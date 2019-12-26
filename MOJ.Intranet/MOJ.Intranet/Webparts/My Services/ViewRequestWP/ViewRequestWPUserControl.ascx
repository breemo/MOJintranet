<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRequestWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.ViewRequestWP.ViewRequestWPUserControl" %>

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
    <asp:Literal ID="title" runat="server" Text="" />
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
                        <div class="col-md-5">
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
                        <div class="col-md-5">
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
                        <div class="col-md-5">
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
                        <div class="col-md-5">
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
                                     
                      
                   
                    <div class="row rt  botx">
                       <asp:Label id="LabelAnswer" runat="server"></asp:Label>
                    </div>
                    
                </div>
            </div>  
     <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, MyRequests%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnGoToMyRequests_Click" />
          <asp:Button OnClientClick="return confirmcancel();" Text="<%$ Resources:Resource, cancel%>" CssClass="morebutovn2" runat="server" ID="btnCanceled" OnClick="btnCanceledworkflow_Click" />
                  
     </div>

    </div>

<asp:Label id="MSGcancelID" class="MSGcancel" style="display: none"  Text="<%$ Resources:Resource, MSGcancel%>" runat="server"></asp:Label>
<!-- #posts end -->
<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script type="text/javascript">
    function confirmcancel() {
       var msg= $(".MSGcancel").html()
        return confirm(msg);
   }
</script>