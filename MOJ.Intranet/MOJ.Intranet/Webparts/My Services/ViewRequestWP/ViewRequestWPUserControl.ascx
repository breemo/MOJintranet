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
                    <asp:Label id="AllData" runat="server"></asp:Label>
                   <hr />
                                     
                      
                   
                    <div class="row rt  botx">
                       <asp:Label id="LabelAnswer" runat="server"></asp:Label>
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