<%@ Assembly Name="MOJ.Intranet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f6919f05ce3f6f90" %>
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
        //alert('Sticky Notes Updated');
        window.location.reload();
    }

</script>

<!-- <script language="javascript" type="text/javascript">  
    function AddSticky() {
        //Set options for Modal PopUp  
        var NewPollsURL = "/Lists/Sticky%20Notes/NewItem.aspx";
        var options = {
            url: NewPollsURL + '?IsDlg=1', //Set the url of the page  
            allowMaximize: false,
            showClose: true,
            width: 600,
            height: 400,
            dialogReturnValueCallback: function (result) {
                if (result == SP.UI.DialogResult.OK) {
                    window.location.reload();
                }
                if (result == SP.UI.DialogResult.cancel) {
                    window.location.reload();
                }
            }
        };
        //Invoke the modal dialog by passing in the options array variable  
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;

    } 
</script> -->

<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">




<div class="headlineflex">
    <h4 class="TitleHead">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, reminder%>" /></h4>
    <!-- <a href="#"  data-toggle="modal" data-target=".bs-example-modal-lg">
                <img src="/Style%20Library/MOJTheme/images/add-Note.png" alt="AddStickyNote" />
            </a> -->
    <!-- <a class="AddStickyNoteIcon" onclick="javascript:AddSticky()">
        <img src="/Style%20Library/MOJTheme/images/add-Note.png" alt="AddStickyNote" /></a> -->

    <a class="AddStickyNoteIcon" onclick="document.getElementById('id01').style.display='block'" ><img src="/Style%20Library/MOJTheme/images/add-Note.png" alt="AddStickyNote" /></a>

    <a href="/Lists/Sticky%20Notes/My%20Stiky%20Notes.aspx" class="slide morebuttoncss arrow">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, more%>" /></a>

</div>

<div id="id01" class="w3-modal">
    <div class="w3-modal-content">
        <div class="w3-container">
            <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-display-topright">&times;</span>
            <br>
            <h4 class="modal-title" id="myModalLabel">
                <asp:Literal runat="server" Text="<%$ Resources:Resource, AddStickyNote%>" /></h4>

            <div class="row">
                <div class="inskdnew modalpordc">
                    <div class="row rt">

                        <div class="col-md-12">

                            <div class="row">

                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Title%>" /></label>
                                </div>

                                <div class="col-md-7">
                                    <input runat="server" id="txtTitleAr" type="text" class="form-control" placeholder="">
                                </div>
                            </div>


                        </div>

                    </div>

                    <div class="row rt">

                        <div class="col-md-12">

                            <div class="row">

                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Date%>" /></label>
                                </div>

                                <div class="col-md-7">
                                    <!-- <input runat="server" id="Text1" type="text" class="form-control" placeholder=""> -->
                                    <div class="input-group date" id="toFrom" data-provide="datepicker">
                                        <input autocomplete="off" required type="text" runat="server" id="txtDate" class="form-control">
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>



                    <div class="row rt mt-5 botx">

                        <%--<a href="#" class="wicnewdiv">تقديم</a>--%>
                        <asp:Button ID="btnSubmitNewItem" runat="server" CssClass="wicnewdiv" Text="<%$ Resources:Resource, Submit%>" OnClick="btnSubmitNewItem_Click" />




                        <%--  <a href="#" data-dismiss="modal"
                                                aria-hidden="true" class="wicnewdiv">الغاء

                                            </a>--%>
                        <!-- <asp:Button ID="btnCancel" runat="server" data-dismiss="modal" aria-hidden="true" CssClass="wicnewdiv" Text="<%$ Resources:Resource, cancel%>" /> -->
                    </div>

                </div>
            </div>
        </div>
    </div>
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





<script>

    $('.datepicker').datepicker({
        language: 'ar',
        rtl: true,
    });

    $('.timepicker').timepicker({
        timeFormat: 'h:mm p',
        interval: 60,
        minTime: '10',
        maxTime: '6:00pm',
        defaultTime: '11',
        startTime: '10:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });
    function isGreaterThanCurrentDate() {
        if (new Date($("#toFrom input").val() + " " + $("#toFromT input").val()) > new Date()) {
            $('#isGreaterThanCurrentDate input').val("Done");
        } else {
            $('#isGreaterThanCurrentDate input').val("dateerror");
        }

    }
</script>
<style>
    #Edata .rt {
        margin-bottom: 1px;
    }

    .w3-modal-content {
        width: 100%;
    }
</style>
