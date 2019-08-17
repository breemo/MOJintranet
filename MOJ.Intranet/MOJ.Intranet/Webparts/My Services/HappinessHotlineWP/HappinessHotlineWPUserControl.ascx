<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HappinessHotlineWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.HappinessHotlineWP.HappinessHotlineWPUserControl" %>


<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HappinessHotline%>" />
</h4>
  		
   <div id="posts" runat="server" class="small-thumbs alt">


    	 <div id="Edata">
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="Ename" disabled runat="server" id="Ename" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
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
                    </div>
                     
               
               </div>

                   <hr />

                <div class="row rt">
                <div class="col-md-12 ">
                    <div class="row">
                        <div class="col-md-2">
                            <label> <asp:Literal runat="server" Text="<%$ Resources:Resource, ContactReason%>" /></label>
                        </div>
                        <div class="col-md-9 RadioButto">
                       <asp:RadioButtonList ID="RBContactReason" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRBContactReason" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="RBContactReason" Display="Dynamic" >
            </asp:RequiredFieldValidator> 

                        </div>
                    </div>
                </div>
				</div>       
         
              <div class="row rt">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-2">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Message%>" /></label>
                        </div>
                        <div class="col-md-9">                        

                         <textarea class="form-control" runat="server" id="Message" rows="4"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="Message" Display="Dynamic" >
            </asp:RequiredFieldValidator>     
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






