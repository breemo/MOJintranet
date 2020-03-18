<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpInnovationGateUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpInnovationGate.wpInnovationGateUserControl" %>

<style>
    .boxleftbor {
        min-height: 360px;
    }
</style>

<%--<style>
#content p {
text-align:center;

}
.filesinsde.row {
min-height:200px !important;
}
</style>

<div class="boxsh">
    <div class="insidebox">
        <h4 class="ta3m"><asp:Literal runat="server" Text="<%$ Resources:Resource, FilesTitle%>" /></h4>
        <div class="boxscroll demo-rtl" style="height: 100% !important;" data-simplebar="init" data-simplebar-auto-hide="false">
            <div class="filesinsde row" style="height: 100%">

                 <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
                <!-- <div class="col-md-2 col-sm-4">

                    <div class="filuo">
                        <div class="wfnew">
                            <p>
                                اسم الملف
                            </p>
                        </div>

                    </div>

                </div> -->
            </div>
        </div>
    </div>
</div>--%>

<div id="posts" runat="server" class="small-thumbs alt">

                <div class="row rt">
                <div class="col-md-12 ">
                    <div class="row">
						<div class="col-md-2">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, InnovationGate%>" /></label>
                        </div>
                        <div class="col-md-4">  				
                            <asp:DropDownList ID="ddlInnovationTypes" AutoPostBack="true" runat="server" class="form-control">
                                 <asp:listitem text="<%$ Resources:Resource, ddlSelect%>" value="1"></asp:listitem>
                                 <asp:listitem text="<%$ Resources:Resource, InnovationPlatform%>" value="2"></asp:listitem>
                                 <asp:listitem text="<%$ Resources:Resource, InnovationTools%>" value="3"></asp:listitem>
                                 <asp:listitem text="<%$ Resources:Resource, MinistryInnovationStrategy%>" value="4"></asp:listitem>
                                 <asp:listitem text="<%$ Resources:Resource, GovernmentInnovationFramework%>" value="5"></asp:listitem>
							</asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" InitialValue="1"
							    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ddlInnovationTypes" Display="Dynamic">
							</asp:RequiredFieldValidator>   
                        </div>
                    </div>
                </div>
				</div>       
			
			
            <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" OnClientClick="isGreaterThanDateTime()"  CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>
        </div>