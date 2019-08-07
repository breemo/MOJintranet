<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTaskUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.ViewTask.ViewTaskUserControl" %>




<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, headHostingRequest%>" />
</h4>

<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">
        <div class="tab-container">        
                <div class="inskdnew">
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, AttendeesNumber%>" /></label>
                                </div>
                                <div class="col-md-9">                                    
                               
                                    <asp:Label id="valAttendeesNumber" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, fromDate%>" /></label>
                                </div>
                                <div class="col-md-9">
                                  
                                     <asp:Label id="valBookingDateFrom" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        
                    </div>

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, toDate%>" /></label>
                                </div>
                                <div class="col-md-9">
                                    <asp:Label id="valBookingDateTo" runat="server"></asp:Label>
                                                                    
                                </div>
                            </div>
                        </div>
                      
                    </div>
                    <div class="row rt fleb">
                        <div class="col-md-1">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, mission%>" /></label>
                        </div>
                        <div class="col-md-11">
                             <asp:Label id="valMission" runat="server"></asp:Label>
                            
                            
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-12">
                            <h5><asp:Literal runat="server" Text="<%$ Resources:Resource, resources%>" />
                            </h5>
                            <div>
                                
                                <%--<asp:CheckBoxList ID="cbResources" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                </asp:CheckBoxList>--%>
                            </div>
                        </div>
                    </div>


                    <div class="row rt fleb">
                        <div class="col-md-3">
                            <label><asp:Literal runat="server" Text="اسم المهمة" /></label>
                        </div>
                        <div class="col-md-11">
                             <asp:Label id="ValTaskName" runat="server"></asp:Label>
                            
                            
                        </div>
                    </div>
                    <div class="row rt fleb">
                        <div class="col-md-3">
                            <label><asp:Literal runat="server" Text="اسم المهمة" /></label>
                        </div>
                        <div class="col-md-11">
                             <asp:Label id="Label1" runat="server"></asp:Label>
                            
                            
                        </div>
                    </div>
                    <div class="row rt fleb">
                        <div class="col-md-1">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, mission%>" /></label>
                        </div>
                        <div class="col-md-11">
                            <textarea class="form-control" runat="server" id="txtMission" rows="3"></textarea>
                        </div>
                    </div>

                    <div class="row rt  botx">
                        <asp:Button Text="approve" CssClass="morebutovn2" runat="server" ID="btnapprove" OnClick="btnapprove_Click" />
                       
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