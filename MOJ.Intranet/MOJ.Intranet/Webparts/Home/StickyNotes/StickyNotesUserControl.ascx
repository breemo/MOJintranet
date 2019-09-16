<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StickyNotesUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.StickyNotes.StickyNotesUserControl" %>

<SharePoint:ScriptLink ID="ScriptLink1" Name="SP.js" runat="server" OnDemand="true" Localizable="false" />
<SharePoint:FormDigest ID="FormDigest1" runat="server" />

<script type="text/javascript">
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', updateListItem);
    function updateListItem(listItemID) {
        //alert(listItemID);
        //var clientContext = SP.ClientContext.get_current();
        var context = SP.ClientContext.get_current();
        var site = context.get_site();
        var rootWeb = site.get_rootWeb();
        var oList = rootWeb.get_lists().getByTitle('Sticky Notes');
        var oListItem = oList.getItemById(listItemID);
        //set column values
        oListItem.set_item('IsDeleted', 1);
        oListItem.update();
        context.executeQueryAsync(Function.createDelegate(this, onQuerySucceeded), Function.createDelegate(this, onQueryFailed));
    }
    function onQueryFailed(sender, args) {
        alert('Request failed. ' + args.get_message() +
            '\n' + args.get_stackTrace());
    }
    function onQuerySucceeded(sender, args) {
        alert('Sticky Notes Updated');
    }

</script>

<div class="headlineflex">
    <h4 class="TitleHead"><asp:Literal runat="server" Text="<%$ Resources:Resource, reminder%>" /></h4>

    <a href="/Lists/Sticky%20Notes/My%20Stiky%20Notes.aspx" class="slide morebuttoncss arrow"><asp:Literal runat="server" Text="<%$ Resources:Resource, moreStickyNote%>" /></a>
</div>

<div class="blockbox minhe newhri">



    <div class="d-flex ordercontainer">

        <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>

        <%--      <div class="col-sm-4 ">
            <div class="STICKB STCIKEY_C1 alert  fade show" role="alert">
                <p>
                    تذكير: متابعة طلب التوريد يوم الاحد 20-01
                </p>

                <button type="button" class="close xClose" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
            </div>

        </div>--%>
    </div>



</div>






