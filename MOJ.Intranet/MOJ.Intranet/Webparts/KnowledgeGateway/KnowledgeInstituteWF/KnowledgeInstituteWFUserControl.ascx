<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeInstituteWFUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.KnowledgeInstituteWF.KnowledgeInstituteWFUserControl" %>

<!-- #page-title end -->
        <!-- Content
        ============================================= -->
        <section id="content">
            <div class="content-wrap">
                <div class="container-fullwidth clearfix">
                    <!-- Post Content
                    ============================================= -->
                    <div class="postcontent nobottommargin col_last clearfix">
                        <div class="boxleftbor">
                            <h4>
                               <label><asp:Literal runat="server" Text="<%$ Resources:Resource, KnowledgeInstitue%>" /></label>
                            </h4>
                            <div id="posts" class="small-thumbs alt">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="boxitemdiv">
                                            <div class="imvbo">
                                                <img src="images/picon1.png" class="img-fluid" />
                                            </div>
                                            <h6>
										 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchForAWay%>" /></label>
                                            </h6>
                                            <div class="srachbic">
                                                <div class="main">
                                                    <!-- Actual search box -->
                                                    <div class="form-group has-search">
                                                        <span class="icon-line-search smicon"></span>
                                                        <input type="text" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>
                                            <input type="button" class="bgicb" value="<%$ Resources:Resource, Search%>">
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="boxitemdiv">
                                            <div class="imvbo">

                                                <img src="images/picon2.png" class="img-fluid" />
                                            </div>
                                            <h6>
                                               <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchADepartment%>" /></label>
                                            </h6>
                                            <div class="srachbic">
                                                <div class="main">
												<!-- Actual search box -->
                                                    <div class="form-group has-search">
                                                        <span class="icon-line-search smicon"></span>
                                                        <input type="text" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>
                                            <input type="button" class="bgicb" value="<%$ Resources:Resource, Search%>">
											</div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="boxitemdiv">
                                            <div class="imvbo">
                                                <img src="images/picon3.png" class="img-fluid" />
                                            </div>
                                            <h6>
                                              <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchForWorkPlace%>" /></label>
                                            </h6>
                                            <div class="srachbic">
                                                <div class="main">
                                                    <!-- Actual search box -->
                                                    <div class="form-group has-search">
                                                        <span class="icon-line-search smicon"></span>
                                                        <input type="text" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>
                                            <input type="button" class="bgicb" value="<%$ Resources:Resource, Search%>">
                                        </div>
                                    </div>
                                </div>
                                <div class="Institution-knowledge">
                                    <div class="content">
                                        <figure class="org-chart cf">
                                            <div class="board">
                                                <ul class="columnOne ">
                                                    <li>
                                                        <span class="lvl-b NEWCL">
                                                            <strong>
                                                            <a href="#">
                                                               <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Minister%>" /></label>
                                                            </a>
                                                            </strong>
                                                        </span>
                                                    </li>
                                                </ul>
                                                <ul class="columnTwo DAHSED2">
                                                    <li>
                                                        <span>
                                                            <strong>
                                                                <a href="#">
                                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CourtsAndProsecutors%>" /></label>
                                                                </a>                                                            
                                                            </strong>
                                                        </span>
                                                    </li>
                                                    <li>
                                                        <span>
                                                            <strong>
                                                                <a href="#">
                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Consultants%>" /></label>
                                                                </a>
                                                            </strong>
                                                        </span>
                                                    </li>
                                                </ul>                                                
                                                <ul class="columnTwo ">
                                                    <li>
                                                        <span>
                                                            <strong>
                                                                <a href="#">
                                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, InternalAudit%>" /></label>
                                                                </a>
                                                            </strong>
                                                        </span>
                                                    </li>
                                                    <li>
                                                        <span>
                                                            <strong>
                                                                <a href="#">
                                                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, MinistersOffice%>" /></label>
                                                                </a>
                                                            </strong>
                                                        </span>                                           
                                                    </li>
                                                </ul>
                                                <div class="board2">
                                                    <ul class="columnTwo BOBED">
                                                        <li class="BORDRNOD">
                                                        </li>
                                                        <li class="NEFVV">
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                         <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CoordinationAndFollowUpUnit%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
															</li>
                                                    </ul>
                                                </div>                                                    
                                                    <ul class="columnTwo">
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, StrategyAndFutureManagement%>" /></label>
                                                                    </a>
                                                                </strong>                                                            
                                                            </span>
                                                        </li>
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, JudicialEvacuationDepartment%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </li>
                                                    </ul>
                                                    <ul class="columnTwo">
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                       <label><asp:Literal runat="server" Text="<%$ Resources:Resource, GovernmentCommunicationDepartment%>" /></label>
                                                                    </a>
                                                                </strong>                                                           
                                                            </span>
                                                        </li>
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ForensicMedicineDepartment%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </li>
														</ul>
                                                    <ul class="columnOne">
                                                        <li>
                                                            <span class="lvl-b">
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Undersecretary%>" /></label>
                                                                    </a>
                                                                </strong>  
                                                            </span>
                                                        </li>
                                                    </ul>
                                                    <ul class="columnTwo">
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, OfficeOfTheUndersecretary%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </li>
                                                        <li>
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, JudicialTrainingInstitute%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </li>
                                                    </ul>
                                                </div>
                                            <ul class="departments ">
                                                <li class="department "> 
                                                        <div class="NEWXCI">
                                                            <span class="lvl-b insidechrt">
                                                                <strong>
                                                                    <a href="#">
                                                                        <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AssistantUndersecretaryForTechnicalAffairsAndInternationalCooperation%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </div>
                                                    <ul class="sections">
                                                        <li class="section">
                                                            <span>
                                                                <strong>
                                                                    <a href="#">
                                                                       <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AdministrationOfWelfareOfMinorsAndAbsentees%>" /></label>
                                                                    </a>
                                                                </strong>
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, LawyersAndTranslatorsAffairsDepartment%>" /></label></strong>
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                               <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, TechnicalExpertsAffairsDepartment%>" /></label></strong>                                                              
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                               <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, NotaryAdministrationAndRatifications%>" /></label></strong>                                                                 
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, InternationalCooperationDepartment%>" /></label></strong>                                                             
                                                            </span>
                                                        </li>                                                 
                                                    </ul>
                                                </li>
                                                <li class="department central">
                                                    <div class="NEWXCI">
                                                        <span class="lvl-b insidechrt">                                                           
                                                            <strong>
                                                                <a href="#">
																<label><asp:Literal runat="server" Text="<%$ Resources:Resource, AssistantUndersecretaryForFatwaAndLegislationAffairs%>" /></label>                                                              
															  </a>
                                                            </strong>
                                                        </span>
                                                    </div>
                                                    <ul class="sections">
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, FatwaAndLegislationDepartment%>" /></label></strong>                                                                
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, DepartmentOfStateIssues%>" /></label></strong>                                                              
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, ResearchAndStudiesDepartment%>" /></label></strong>    
                                                            </span>
                                                        </li>                                                        
                                                    </ul>
                                                </li>
                                                <li class="department ">
                                                                   <div class="NEWXCI">
                                                        <span class="lvl-b insidechrt">
                                                                <strong>
                                                                    <a href="#">
                                                                       <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AssistantUndersecretaryForSupportServicesAffairs%>" /></label>   
                                                                    </a>
                                                                </strong>
                                                        </span>
                                                    </div>                                          
                                                    <ul class="sections">
                                                        <li class="section">
                                                            <span>
                                                                <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, HumanResourceManagement%>" /></label></strong>                                                                
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                 <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, FinancialResourcesAndProcurementManagement%>" /></label></strong>  
                                                            </span>
                                                        </li>
                                                        <li class="section">
                                                            <span>
                                                                  <strong><label><asp:Literal runat="server" Text="<%$ Resources:Resource, InformationTechnologyDepartment%>" /></label></strong>  
                                                            </span>
                                                        </li>
                                                        
                                                    </ul>
                                                </li>
                                            </ul>
                                        </figure>
                                    </div>
                                </div>
                            </div><!-- #posts end -->
                        </div>
                    </div><!-- .postcontent end -->
                    <!-- Sidebar
                    ============================================= -->
                    
                </div>
            </div>
          
        </section><!-- #content end -->     
