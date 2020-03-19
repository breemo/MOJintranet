<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImplicitKnowledgeWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.ImplicitKnowledgeWP.ImplicitKnowledgeWPUserControl" %>
<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV1" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV1" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV2" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV2" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV3" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV3" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV4" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV4" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV5" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV5" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV6" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV6" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV7" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV7" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV8" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV8" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV9" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV9" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV10" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV10" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV11" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV11" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV12" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV12" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV13" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV13" runat="server" />
     <!-- Content
        ============================================= -->
               
			<div id="posts" runat="server" class="small-thumbs alt content-wrap">
                <div class="">
				<div class="boxsh">
                        <div class="faqhead">
                            <h3>
                              <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ImplicitKnowledge%>" /></label>
                            </h3>
                        </div>
                        <div class="">
                           
							 <!--          ==============     Edata=============================== -->
                                <div class="ndl" id="Edata">
								 <div class=" DivPID" style=" display: none;">
								 	<input type="text" name="TOPID" runat="server" id="TOPID" class="form-control" placeholder="">									
										</div>
                                    <div class="col-md-5 col-sm-12 bgdivindf bgdivindfx ">
                                        <div class="titleheadnew">
                                            <h4> <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeData%>" /></label></h4>
                                        </div>
                                        <div class="conentbgdivd">
                                            <div class="row">
                                                <div class="col-sm-12 jdivd">
                                                </div>
                                                <div class="dininfo">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <p class="rmae">
                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <span class="nnamele">
                                                                     <input type="text" name="Ename" disabled runat="server" id="Ename" class="form-control" placeholder="">
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
														<td>
                                                                <p class="rmae">
                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeNumber%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <span class="nnamele">
                                                                   <input type="text" disabled name="Enumber" runat="server" id="Enumber" class="form-control" placeholder="">     
																	</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p class="rmae">
                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Nationality%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
															<span class="nnamele">
                                                                    <span class="nnamele">
                                                                        <input type="text" name="ENationality" disabled runat="server" id="ENationality" class="form-control" placeholder="">
                                                                    </span>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p class="rmae">
                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <span class="nnamele">
                                                                   <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder=""> 
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p class="rmae">
                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, DateOfBirth%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <span class="nnamele">
                                                                   <input type="text" disabled name="EDateOfBirth" runat="server" id="EDateOfBirth" class="form-control" placeholder=""> 
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p class="rmae">
                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, MaritalStatus%>" /></label>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <span class="nnamele">
                                                                    <span class="nnamele">
                                                                        <input type="text" disabled name="EMaritalStatus" runat="server" id="EMaritalStatus" class="form-control" placeholder="">
                                                                    </span>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <section id="Implcit">
                                    <section id="faqs" class="">
                                        <div class="questions">
                                            <dl>
                                                <dt>
                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Employmenthistory%>" /></label>
                                                </dt>
                                                <dd>
                                                    <div class="questionbox">
                                                        <div class="tidtleheadbox">
                                                            <div class="widt98">
                                                                <div class="row mrcx">
                                                                    
                                                                    <div class="col-md-4">
                                                                        <label class="forlaxbe">
                                                                          <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Designation%>" /></label>
                                                                        </label>
                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <label class="forlaxbe">
                                                                           <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Organizationalunit%>" /></label>
                                                                        </label>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <label class="forlaxbe">
                                                                           <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom%>" /></label>
                                                                        </label>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <label class="forlaxbe">
                                                                          <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto%>" /></label>
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="widt2">
                                                            </div>
                                                        </div>
														<div runat="server"  id="superDIV1" class="superDIV1">
															  <div  id="FirstItemEmploymenthistoryAA" style="display:none" >
																 </div>
															   <div  id="FirstItemEmploymenthistory" class="cnrtnheadbox2" >
																	<div class="row rt">	
																		<div  class="DivSID" style=" display: none;" >
																		<input type="text"  name="SID" runat="server" id="SID0" class="form-control"  placeholder="">
																		</div>                       
																		<div class="col-md-4 DivDesignation">
																		<input type="text" name="Designation" runat="server" id="Designation0" class="form-control" placeholder="">
																		</div>
																		<div  class="col-md-3 DivOrganizationalunit">
																			<input type="text" name="Organizationalunit" runat="server" id="Organizationalunit0" class="form-control" placeholder="">
																		</div>
																		<div  class="col-md-2 ">
																			<div class="input-group date DivDatefrom" data-provide="datepicker">
																			<input autocomplete="off"  type="text" runat="server" id="Datefrom0" class="form-control">
																			<div class="input-group-addon">
																				<span class="icon-calendar-alt1"></span>
																			</div>									
																				</div>
																		</div>						
																		<div  class="col-md-2 ">
																			<div class="input-group date DivDateto" data-provide="datepicker">
																			<input autocomplete="off"  type="text" runat="server" id="Dateto0" class="form-control">
																			<div class="input-group-addon">
																				<span class="icon-calendar-alt1"></span>
																			</div>
																		</div>																				 						   
																	</div>
																	<div  class="col-md-1 DiveDelete ">																			
																		</div>	
																</div>
															</div>															                                               
                                                    </div>
                                                    </div>
													<div>
													  	<a  onclick="addEmploymenthistory();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                                                        </div>
													</dd>
                                               
													<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Qualifications%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Qualification%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Major%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Institution%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Country%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, GraduationYear%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>				
                                                          </div>
                                                    </div>
														<div runat="server"  id="superDIV2" class="superDIV2">
																			  <div  id="FirstItemAA2" style="display:none" >
																				 </div>
																			   <div  id="FirstItem2" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID2" style=" display: none;" >
																						<input type="text"  name="SID2" runat="server" id="SID02" class="form-control" placeholder="">
																						</div>                       
																						<div class="col-md-3 DivQualification">
																						<input type="text" name="Qualification" runat="server" id="Qualification0" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-2 DivMajor">
																							<input type="text" name="Major" runat="server" id="Major0" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-2 DivInstitution">
																							<input type="text" name="Institution" runat="server" id="Institution0" class="form-control" placeholder="">
																						</div>																						
																						<div class="col-md-2 DivCountry ">
																								   <label><asp:Literal runat="server" id="DDCountry"/></label>                        
																									<asp:DropDownList ID="DropDownCountry" runat="server" class="form-control">
																									</asp:DropDownList>
																								</div>					
																						<div  class="col-md-2 ">
																							<div class="input-group date DivGraduationYear" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="GraduationYear0" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>

																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>
																				
																			</div>
																			<div>
																					<a  onclick="addQualifications();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>

												<dt>
                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, LanguageSkills%>" /></label>
                                                </dt>
											<dd>
                                                    <div class="questionbox">
                                                        <div>
                                                            <div data-duplicate="langaskills" data-duplicate-min="0">
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Language %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ReadingLevel%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WritingLevel%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ConversationLevel%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>                                                                
                                                                  </div>
                                                        </div>
                                                    </div>
													<div runat="server"  id="superDIV3" class="superDIV3">
													  <div  id="FirstItemAA3" style="display:none" >
														 </div>
													   <div  id="FirstItem3" class="cnrtnheadbox2" >
															<div class="row rt">	
																<div  class="DivSID3" style=" display: none;" >
																<input type="text"  name="SID3" runat="server" id="SID03" class="form-control" placeholder="">
																</div>                       
																<div class="col-md-2 DivLanguage">
																<input type="text" name="Language" runat="server" id="Language0" class="form-control" placeholder="">
																</div>						
																<div class="col-md-3 DivReadingLevel ">
																		   <label><asp:Literal runat="server" id="DDReadingLevel"/></label>                        
																			<asp:DropDownList ID="DropDownReadingLevel" runat="server" class="form-control">
																			</asp:DropDownList>
																		</div>	
																<div class="col-md-3 DivWritingLevel ">
																	   <label><asp:Literal runat="server" id="DDWritingLevel"/></label>                        
																		<asp:DropDownList ID="DropDownWritingLevel" runat="server" class="form-control">
																		</asp:DropDownList>
																	</div>		
																	<div class="col-md-3 DivConversationLevel ">
																	   <label><asp:Literal runat="server" id="DDConversationLevel"/></label>                        
																		<asp:DropDownList ID="DropDownConversationLevel" runat="server" class="form-control">
																		</asp:DropDownList>
																	</div>	
																	<div  class="col-md-1 DiveDelete ">																			
																			</div>																	
															</div>
														</div>
													</div>
													<div>
														 <a  onclick="addLanguageSkills();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>    
													</div>
                                                </dd>

												<dt>
                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TechnicalSkills%>" /></label>
                                                </dt>

												<dd>
                                                    <div class="questionbox">
                                                        <div>
                                                            <div data-duplicate="langaskills" data-duplicate-min="0">
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">
                                                                           <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SkillType %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SkillLevel%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AreaOfApplication%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>                                                                
                                                            </div>
                                                        </div>
                                                    </div>
													
													 <div runat="server"  id="superDIV4" class="superDIV4">
												  <div  id="FirstItemAA4" style="display:none" >
													 </div>
												   <div  id="FirstItem4" class="cnrtnheadbox2" >
														<div class="row rt">	
															<div  class="DivSID4" style=" display: none;" >
															<input type="text"  name="SID4" runat="server" id="SID04" class="form-control" placeholder="">
															</div>                       
															<div class="col-md-2 DivSkillType">
															<input type="text" name="SkillType" runat="server" id="SkillType0" class="form-control" placeholder="">
															</div>						
															<div class="col-md-3 DivSkillLevel ">
																	   <label><asp:Literal runat="server" id="DDSkillLevel"/></label>                        
																		<asp:DropDownList ID="DropDownSkillLevell" runat="server" class="form-control">
																		</asp:DropDownList>
																	</div>	
															<div class="col-md-3 DivAreaOfApplication">
															<input type="text" name="AreaOfApplication" runat="server" id="AreaOfApplication0" class="form-control" placeholder="">
															</div>	
															<div class="col-md-3 DivNotes4">
															<input type="text" name="Notes4" runat="server" id="Notes04" class="form-control" placeholder="">
															</div>	
															<div  class="col-md-1 DiveDelete ">																			
																	</div>															
														</div>
													</div>
												</div>
												<div>
													<a  onclick="addTechnicalSkills();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>											
													</div>                                               
											   </dd>
											   <dt>
                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, OtherSkills%>" /></label>
                                                </dt>
												<dd>
                                                    <div class="questionbox">
                                                        <div>
                                                            <div data-duplicate="othersxkills" data-duplicate-min="0">
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">
                                                                           
                                                                            <div class="col-md-5">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, SkillTheEmployeeHave %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
													<div runat="server"  id="superDIV5" class="superDIV5">
												  <div  id="FirstItemAA5" style="display:none" >
													 </div>
												   <div  id="FirstItem5" class="cnrtnheadbox2">
														<div class="row rt">	
															<div  class="DivSID5" style=" display: none;" >
															<input type="text"  name="SID5" runat="server" id="SID05" class="form-control" placeholder="">
															</div>                       
															<div class="col-md-5 DivSkillTheEmployeeHave">
															<input type="text" name="SkillTheEmployeeHave" runat="server" id="SkillTheEmployeeHave0" class="form-control" placeholder="">
															</div><div class="col-md-6 DivNotes5">
															<input type="text" name="Notes5" runat="server" id="Notes05" class="form-control" placeholder="">
															</div>
															<div  class="col-md-1 DiveDelete ">																			
															</div>
														</div>
													</div>
												</div>
												<div>
													<a  onclick="addOtherSkills();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
												</div>
                                                </dd>
                                                <dt>
                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TrainingCourses%>" /></label>
                                                </dt>
                                                <dd>
                                                    <div class="questionbox">
                                                        <div>
                                                            <div data-duplicate="Courses" data-duplicate-min="0">
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CourseName %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WithinThePlan %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TrainingHours %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CourseLocation %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>                                                               
                                                            </div>
                                                        </div>
                                                    </div>
													<div runat="server"  id="superDIV6" class="superDIV6">
												  <div  id="FirstItemAA6" style="display:none" >
													 </div>
												   <div  id="FirstItem6" class="cnrtnheadbox2">
														<div class="row rt">	
															<div  class="DivSID6" style=" display: none;" >
															<input type="text"  name="SID6" runat="server" id="SID06" class="form-control" placeholder="">
															</div>                       
															<div class="col-md-2 DivCourseName">
															<input type="text" name="CourseName" runat="server" id="CourseName0" class="form-control" placeholder="">
															</div>
															
															<div class="col-md-2 DivWithinThePlan RadiB">
												   <asp:RadioButtonList ID="WithinThePlan0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
														</asp:RadioButtonList>
														</div>
															
															<div class="col-md-2 DivTrainingHours">
															<input type="text" name="TrainingHours" runat="server" id="TrainingHours0" class="form-control" placeholder="">
															</div>
															<div  class="col-md-2 ">
																<div class="input-group date DivDatefrom6" data-provide="datepicker">
																<input autocomplete="off"  type="text" runat="server" id="Datefrom06" class="form-control">
																<div class="input-group-addon">
																	<span class="icon-calendar-alt1"></span>
																</div>									
																	</div>
															</div>	
															<div  class="col-md-2 ">
																<div class="input-group date DivDateto6" data-provide="datepicker">
																<input autocomplete="off"  type="text" runat="server" id="Dateto06" class="form-control">
																<div class="input-group-addon">
																	<span class="icon-calendar-alt1"></span>
																</div>									
																	</div>
															</div>	
															<div class="col-md-1 DivCourseLocation">
															<input type="text" name="CourseLocation" runat="server" id="CourseLocation0" class="form-control" placeholder="">
															</div>
															<div  class="col-md-1 DiveDelete ">																			
															</div>
														</div>
													</div>												
													</div>												
												<div>
													<a  onclick="addTrainingCourses();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
												</div>								
													
                                                </dd>
												<dt>
                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Expertise%>" /></label>
                                                </dt>
                                                <dd>
                                                    <div class="questionbox">
                                                        <div>
                                                            <div data-duplicate="Courses" data-duplicate-min="0">
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, OrganizationName %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, NatureOfTheJob %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Country %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, YearsOfExperience %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                           
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>                                                               
                                                            </div>
                                                        </div>
                                                    </div>
													<div runat="server"  id="superDIV7" class="superDIV7">
												  <div  id="FirstItemAA7" style="display:none" >
													 </div>
												   <div  id="FirstItem7" class="cnrtnheadbox2">
														<div class="row rt">	
															<div  class="DivSID7" style=" display: none;" >
															<input type="text"  name="SID7" runat="server" id="SID07" class="form-control" placeholder="">
															</div>                       
															<div class="col-md-3 DivOrganizationName">
															<input type="text" name="OrganizationName" runat="server" id="OrganizationName0" class="form-control" placeholder="">
															</div>				
															<div class="col-md-2 DivNatureOfTheJob">
															<input type="text" name="NatureOfTheJob" runat="server" id="NatureOfTheJob0" class="form-control" placeholder="">
															</div>	
															<div class="col-md-2 DivCountry ">
															   <label><asp:Literal runat="server" id="DDCountry7"/></label>                        
																<asp:DropDownList ID="DropDownCountry7" runat="server" class="form-control">
																</asp:DropDownList>
															</div>																
															<div class="col-md-2 DivYearsOfExperience">
															<input type="text" name="YearsOfExperience" runat="server" id="YearsOfExperience0" class="form-control" placeholder="">
															</div>
															
															<div class="col-md-2 DivNotes">
															<input type="text" name="Notes7" runat="server" id="Notes07" class="form-control" placeholder="">
															</div>
															<div  class="col-md-1 DiveDelete ">																			
															</div>
														</div>
													</div>												
													</div>												
												<div>
													<a  onclick="addExpertise();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
												</div>								
													
                                                </dd>
													<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Publications%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, BookPublicationTitle%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Topic%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, PublishDate%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>								
                                                         
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV8" class="superDIV8">
																			  <div  id="FirstItemAA8" style="display:none" >
																				 </div>
																			   <div  id="FirstItem8" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID8" style=" display: none;" >
																						<input type="text"  name="SID8" runat="server" id="SID08" class="form-control" placeholder="">
																						</div>                       
																						<div class="col-md-3 DivBookPublicationTitle">
																						<input type="text" name="BookPublicationTitle" runat="server" id="BookPublicationTitle0" class="form-control" placeholder="">
																						</div>	
																						<div class="col-md-3 DivTopic">
																						<input type="text" name="Topic" runat="server" id="Topic0" class="form-control" placeholder="">
																						</div>	
																						<div  class="col-md-2 ">
																							<div class="input-group date DivPublishDate" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="PublishDate0" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>
																						<div  class="col-md-3 DivNotes">
																							<input type="text" name="Notes8" runat="server" id="Notes08" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-1 DiveDelete ">																			
																							</div>																							
																					</div>
																				</div>																				
																			</div>
																			<div>
																					<a  onclick="addPublications();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>
														 
													<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TravelInformations%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CountryResidentForMoreThan3Months%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TimePeriodFrom%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TimeperiodTo%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, VisitReasons%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>								
                                                         
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV9" class="superDIV9">
																			  <div  id="FirstItemAA9" style="display:none" >
																				 </div>
																			   <div  id="FirstItem9" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID9" style=" display: none;" >
																						<input type="text"  name="SID9" runat="server" id="SID09" class="form-control" placeholder="">
																						</div>															
																						<div class="col-md-3 DivCountryResidentForMoreThan3Months ">
																								   <label><asp:Literal runat="server" id="DDCountryResidentForMoreThan3Months"/></label>                        
																									<asp:DropDownList ID="DropDownCountryResidentForMoreThan3Months" runat="server" class="form-control">
																									</asp:DropDownList>
																								</div>	
																						<div  class="col-md-2 ">
																							<div class="input-group date DivTimePeriodFrom" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="TimePeriodFrom0" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>
																						<div  class="col-md-2 ">
																							<div class="input-group date DivTimeperiodTo" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="TimeperiodTo0" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>	
																						<div  class="col-md-4 DivVisitReasons">
																							<input type="text" name="VisitReasons" runat="server" id="VisitReasons0" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>
																				
																			</div>
																			<div>
																					<a  onclick="addTravelInformations();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>
														 
														 
														 	<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Participations%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ActivityName%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Sponsor%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Country%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, NatureOfTheParticipation%>" /></label>
                                                                                </label>
                                                                            </div>                                                                           
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>                                                     
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV10" class="superDIV10">
																			  <div  id="FirstItemAA10" style="display:none" >
																				 </div>
																			   <div  id="FirstItem10" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID10" style=" display: none;" >
																						<input type="text"  name="SID10" runat="server" id="SID010" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-3 DivActivityName">
																							<input type="text" name="ActivityName" runat="server" id="ActivityName0" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-3 DivSponsor">
																							<input type="text" name="Sponsor" runat="server" id="Sponsor0" class="form-control" placeholder="">
																						</div>																				
																						<div class="col-md-2 DivCountry ">
																								   <label><asp:Literal runat="server" id="DDCountry10"/></label>                        
																									<asp:DropDownList ID="DropDownCountry10" runat="server" class="form-control">
																									</asp:DropDownList>
																								</div>	
																							
																						<div  class="col-md-3 DivNatureOfTheParticipation">
																							<input type="text" name="NatureOfTheParticipation" runat="server" id="NatureOfTheParticipation0" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>																				
																			</div>
																			<div>
																					<a  onclick="addParticipations();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>

                                               <dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Membership%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Membership%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Location%>" /></label>
                                                                                </label>
                                                                            </div>
																			 <div class="col-md-1">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Field%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto%>" /></label>
                                                                                </label>
                                                                            </div>
																			 <div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV11" class="superDIV11">
																			  <div  id="FirstItemAA11" style="display:none" >
																				 </div>
																			   <div  id="FirstItem11" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID11" style=" display: none;" >
																						<input type="text"  name="SID11" runat="server" id="SID011" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-2 DivMembership">
																							<input type="text" name="Membership" runat="server" id="Membership0" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-2 DivLocation">
																							<input type="text" name="Location" runat="server" id="Location0" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-1 DivField">
																							<input type="text" name="Field11" runat="server" id="Field011" class="form-control" placeholder="">
																						</div>
																						
																						<div  class="col-md-2 ">
																							<div class="input-group date DivFromDate" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="FromDate011" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>
																						<div  class="col-md-2 ">
																							<div class="input-group date DivToDate" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="ToDate011" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>	
																						<div  class="col-md-2 DivNotes">
																							<input type="text" name="Notes11" runat="server" id="Notes011" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>
																				
																			</div>
																			<div>
																					<a  onclick="addMembership();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>

												<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Hopis%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-5">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Hoppy %>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV12" class="superDIV12">
																			  <div  id="FirstItemAA12" style="display:none" >
																				 </div>
																			   <div  id="FirstItem12" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID12" style=" display: none;" >
																						<input type="text"  name="SID12" runat="server" id="SID012" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-5 DivHoppy">
																							<input type="text" name="Hoppy" runat="server" id="Hoppy0" class="form-control" placeholder="">
																						</div>																				
																						<div  class="col-md-6 DivNotes">
																							<input type="text" name="Notes12" runat="server" id="Notes012" class="form-control" placeholder="">
																						</div>
																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>
																				
																			</div>
																			<div>
																					<a  onclick="addHopis();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd>
														 
													
													<dt>
                                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, VoluntaryWork%>" /></label>
                                                </dt>
														<dd>
                                                    <div class="questionbox" id="q22">
                                                        <div>
                                                                <div class="tidtleheadbox">
                                                                    <div class="widt98">
                                                                        <div class="row mrcx">                                                                            
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ActivityName%>" /></label>
                                                                                </label>
                                                                            </div>
																			<div class="col-md-2">
                                                                                <label class="forlaxbe">
                                                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Location%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom%>" /></label>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="forlaxbe">
                                                                                   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto%>" /></label>
                                                                                </label>
                                                                            </div>  
                                                                        </div>
                                                                    </div>
                                                                    <div class="widt2">
                                                                    </div>
                                                                </div>	
                                                        </div>
                                                    </div>
														<div runat="server"  id="superDIV13" class="superDIV13">
																			  <div  id="FirstItemAA13" style="display:none" >
																				 </div>
																			   <div  id="FirstItem13" class="cnrtnheadbox2" >
																					<div class="row rt">	
																						<div  class="DivSID13" style=" display: none;" >
																						<input type="text"  name="SID13" runat="server" id="SID013" class="form-control" placeholder="">
																						</div>
																						<div  class="col-md-3 DivActivityName">
																							<input type="text" name="ActivityName" runat="server" id="ActivityName013" class="form-control" placeholder="">
																						</div>																						
																						<div class="col-md-2 DivLocation ">
																								   <label><asp:Literal runat="server" id="DDLocation13"/></label>                        
																									<asp:DropDownList ID="DropDownLocation13" runat="server" class="form-control">
																									</asp:DropDownList>
																								</div>	
																						<div  class="col-md-3 ">
																							<div class="input-group date DivDatefrom" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="Datefrom013" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>
																						<div  class="col-md-3 ">
																							<div class="input-group date DivDateto" data-provide="datepicker">
																							<input autocomplete="off"  type="text" runat="server" id="Dateto013" class="form-control">
																							<div class="input-group-addon">
																								<span class="icon-calendar-alt1"></span>
																							</div>									
																								</div>
																						</div>																				
																							<div  class="col-md-1 DiveDelete ">																			
																									</div>																							
																					</div>
																				</div>
																				
																			</div>
																			<div>
																					<a  onclick="addVoluntaryWork();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
																						</div>
														 </dd> 
										 </dl>
                                           
                                            <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:CheckBox ID="cbConfirm" runat="server" Text="<%$ Resources:Resource, ImplicitknowledgeConfirm%>" CssClass="AcceptedAgreement"
                                                            />
                                                    </div>
                                                </div>
                                                 <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
                                                            OnServerValidate="CheckBoxRequired_ServerValidate"
                                                            ClientValidationFunction="CheckBoxRequired_ClientValidate" 
                                                            ErrorMessage="<%$ Resources:Resource, SouqMustConfirm%>"
                                                            ForeColor="Red"
                                                            validationgroup="impGroup"></asp:CustomValidator>

                                                    </div>
                                                </div>


                                            <div class="row cf">
                                               
						 <asp:Button  validationgroup="impGroup" style="margin-top: 15px;" Text="<%$ Resources:Resource, Save%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
           						 <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Back%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnBack" OnClick="btnBack_Click" />
           
                                             
                                            </div>

                                        </div>
                                    </section>
                                </section>
                            </div>
					</div>
                    </div>
                </div>
				
	
<div id="SuccessMsgDiv" runat="server" style="display:none">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>	
	 <div class="row cf">
                                               
												     <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Reload%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnReload" OnClick="btnReload_Click" />
           												     <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Back%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnBack2" OnClick="btnBack_Click" />
           
                                             
                                            </div>
	
</div>
<div id="Div1" runat="server" >
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>
<style>
    .AcceptedAgreement input{
        border: 1px solid #ccc;
    height: 22px;
    cursor: pointer;
    width: 22px !important;
    margin: 10px;
    }
.nwckss {
    margin-top: 20px;
    margin-left: 5px;
}

.btnclass {
    background: #fff !important;
    color: #be9136 !important;
    border-radius: 18px !important;
    padding: 0px 27px 0px 27px !important;
    font-weight: bold!important;
    font-size: 0.69rem !important;
    line-height: 14px !important;
    -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    border: 1px solid #be9136 !important;
    text-align: center !important;
    height: 30px !important;
    margin-top: 0px !important;
}
.bgicb {
    background: #be9136 !important;
    color: #fff !important;
    border-radius: 18px; !important
    padding: 0px 40px 0px 40px !important;
    font-weight: bold !important;
    font-size: 0.69rem !important;
    line-height: 14px !important;
    -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    border: 1px solid #be9136 !important;
    text-align: center !important;
    height: 30px !important;
    margin-top: 8px !important;
    margin-bottom: 30px !important;
}

.boxleftbor {
    padding: 0;
    box-shadow: none;
    background: none;
}
.row.rt {
    margin-bottom: 1px;
    margin-top: 1px;
    padding: 1px;
}
#dynamicInput .row table {
    margin-bottom: 1px;
}
.superDIV1 .row table {
    margin-bottom: 1px;
}
.HusbandORWife .row table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;
}
.rowI {
    padding-bottom: 10px;
}
.DivCountry label ,.DivReadingLevel label ,.DivWritingLevel label ,.DivConversationLevel label ,.DivSkillLevel  label,.DivLocation label ,.DivCountryResidentForMoreThan3Months  label{
    display: none;
}
.cnrtnheadbox2 {
    width: 100%;
    overflow: hidden;
    border: 1px solid #cdcfd2;
    justify-content: space-between;
    padding: 8px 10px;
    align-items: center;
    align-items: center;
}
.bgdivindfx {
    background-color: whitesmoke;
}
.conentbgdivd {
    border-right: 1px solid #e1e1e1;
    border-left: 1px solid #e1e1e1;
}
.faqhead label {
    font-size: inherit !important;
    font-weight: 700 !important;
}
</style>
<script>

  

    function CheckBoxRequired_ClientValidate(sender, e) {
        e.IsValid = jQuery(".AcceptedAgreement input:checkbox").is(':checked');
    }

</script>
<script>
    $(document).ready(function () {
        $(".RadiB label").addClass("radio-button-click-target");
        $(".RadiB input").addClass("radio-button");        
    });
    $('.datepicker').datepicker({
        dateFormat: 'dd/mm/yyyy',
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
</script>
  <script>
      $("#faqs dt:first-child").addClass("active");
      $("#faqs dt:first-child").next().slideDown().siblings('dd').slideUp();

      $('#faqs dt').click(function () {


          if ($(this).hasClass('active')) {
              $(this).removeClass('active');
              $(this).next().slideUp();
          } else {

              $(this).siblings('dt').removeClass('active');
              $(this).addClass('active');
              $(this).next().slideDown().siblings('dd').slideUp();
          }
      });

  </script>
<script>
    var counter1 = 0;
    if (document.getElementById('hdnsuperDIV1').value != "") {
        counter1 = Number(document.getElementById('hdnsuperDIV1').value);
    }
    function addEmploymenthistory() {
        counter1++;
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = $("#FirstItemEmploymenthistory")[0].innerHTML;
        var Itemhtml = $("#FirstItemEmploymenthistoryAA");
        Itemhtml.find(".DivSID")[0].innerHTML = "<input name='SID' type=text' id='SID" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDesignation")[0].innerHTML = "<input name='Designation' type=text' id='Designation" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivOrganizationalunit")[0].innerHTML = "<input name='Organizationalunit' type=text' id='Organizationalunit" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDatefrom")[0].innerHTML = "<input autocomplete='off' name='Datefrom' type='text' id='Datefrom" + counter1 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivDateto")[0].innerHTML = "<input autocomplete='off' name='Dateto' type='text' id='Dateto" + counter1 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowEmploymenthistory(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV1")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV1').value = counter1;
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = "";
    }
    function removerowEmploymenthistory(thi) {
        counter1--;
        document.getElementById('hdnsuperDIV1').value = counter1;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////2----------------------------------------------------
    var counter2 = 0;
    if (document.getElementById('hdnsuperDIV2').value != "") {
        counter2 = Number(document.getElementById('hdnsuperDIV2').value);
    }
    function addQualifications() {
        counter2++;
        $("#FirstItemAA2")[0].innerHTML = $("#FirstItem2")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA2");
        Itemhtml.find(".DivSID2")[0].innerHTML = "<input name='SID2' type=text' id='SID2" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivQualification")[0].innerHTML = "<input name='Qualification' type=text' id='Qualification" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivMajor")[0].innerHTML = "<input name='Major' type=text' id='Major" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivInstitution")[0].innerHTML = "<input name='Institution' type=text' id='Institution" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivCountry select")[0].setAttribute("name", "DropDownCountry");
        Itemhtml.find(".DivCountry select")[0].setAttribute("id", "DropDownCountry" + counter2 + "");
        Itemhtml.find(".DivGraduationYear")[0].innerHTML = "<input autocomplete='off' name='GraduationYear' type='text' id='GraduationYear" + counter2 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowQualifications(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV2")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV2').value = counter2;
        $("#FirstItemAA2")[0].innerHTML = "";
    }
    function removerowQualifications(thi) {
        counter2--;
        document.getElementById('hdnsuperDIV2').value = counter2;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////3----------------------------------------------------
    var counter3 = 0;
    if (document.getElementById('hdnsuperDIV3').value != "") {
        counter3 = Number(document.getElementById('hdnsuperDIV3').value);
    }
    function addLanguageSkills() {
        counter3++;
        $("#FirstItemAA3")[0].innerHTML = $("#FirstItem3")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA3");
        Itemhtml.find(".DivSID3")[0].innerHTML = "<input name='SID3' type=text' id='SID3" + counter3 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLanguage")[0].innerHTML = "<input name='Language' type=text' id='Language" + counter3 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivReadingLevel select")[0].setAttribute("name", "DropDownReadingLevel");
        Itemhtml.find(".DivReadingLevel select")[0].setAttribute("id", "DropDownReadingLevel" + counter3 + "");
        Itemhtml.find(".DivWritingLevel select")[0].setAttribute("name", "DropDownWritingLevel");
        Itemhtml.find(".DivWritingLevel select")[0].setAttribute("id", "DropDownWritingLevel" + counter3 + "");
        Itemhtml.find(".DivConversationLevel select")[0].setAttribute("name", "DropDownConversationLevel");
        Itemhtml.find(".DivConversationLevel select")[0].setAttribute("id", "DropDownConversationLevel" + counter3 + "");
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowLanguageSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV3")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV3').value = counter3;
        $("#FirstItemAA3")[0].innerHTML = "";
    }
    function removerowLanguageSkills(thi) {
        counter3--;
        document.getElementById('hdnsuperDIV3').value = counter3;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////4----------------------------------------------------
    var counter4 = 0;
    if (document.getElementById('hdnsuperDIV4').value != "") {
        counter4 = Number(document.getElementById('hdnsuperDIV4').value);
    }
    function addTechnicalSkills() {
        counter4++;
        $("#FirstItemAA4")[0].innerHTML = $("#FirstItem4")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA4");
        Itemhtml.find(".DivSID4")[0].innerHTML = "<input name='SID4' type=text' id='SID4" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSkillType")[0].innerHTML = "<input name='SkillType' type=text' id='SkillType" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSkillLevel select")[0].setAttribute("name", "DropDownSkillLevel");
        Itemhtml.find(".DivSkillLevel select")[0].setAttribute("id", "DropDownSkillLevel" + counter4 + "");
        Itemhtml.find(".DivAreaOfApplication")[0].innerHTML = "<input name='AreaOfApplication' type=text' id='AreaOfApplication" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivNotes4")[0].innerHTML = "<input name='Notes4' type=text' id='Notes4" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTechnicalSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV4")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV4').value = counter4;
        $("#FirstItemAA4")[0].innerHTML = "";
    }
    function removerowTechnicalSkills(thi) {
        counter4--;
        document.getElementById('hdnsuperDIV4').value = counter4;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////5----------------------------------------------------
    var counter5 = 0;
    if (document.getElementById('hdnsuperDIV5').value != "") {
        counter5 = Number(document.getElementById('hdnsuperDIV5').value);
    }
    function addOtherSkills() {
        counter5++;
        $("#FirstItemAA5")[0].innerHTML = $("#FirstItem5")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA5");
        Itemhtml.find(".DivSID5")[0].innerHTML = "<input name='SID5' type=text' id='SID5" + counter5 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSkillTheEmployeeHave")[0].innerHTML = "<input name='SkillTheEmployeeHave' type=text' id='SkillTheEmployeeHave" + counter5 + "' class='form-control' placeholder=''>";

        Itemhtml.find(".DivNotes5")[0].innerHTML = "<input name='Notes5' type=text' id='Notes5" + counter5 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowOtherSkills(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV5")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV5').value = counter5;
        $("#FirstItemAA5")[0].innerHTML = "";
    }
    function removerowOtherSkills(thi) {
        counter5--;
        document.getElementById('hdnsuperDIV5').value = counter5;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////6----------------------------------------------------
    var counter6 = 0;
    if (document.getElementById('hdnsuperDIV6').value != "") {
        counter6 = Number(document.getElementById('hdnsuperDIV6').value);
    }
    function addTrainingCourses() {
        counter6++;
        $("#FirstItemAA6")[0].innerHTML = $("#FirstItem6")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA6");
        Itemhtml.find(".DivSID6")[0].innerHTML = "<input name='SID6' type=text' id='SID6" + counter6 + "' class='form-control' placeholder=''>";
        var radio1 = Itemhtml.find(".DivWithinThePlan label")[0].innerText;
        var radiovalue1 = Itemhtml.find(".DivWithinThePlan input")[0].value;
        var radio2 = Itemhtml.find(".DivWithinThePlan label")[1].innerText;
        var radiovalue2 = Itemhtml.find(".DivWithinThePlan input")[1].value;
        var vaWithinThePlan = "<input name='WithinThePlan' type='text' id='WithinThePlanvalue" + counter6 + "' style='display:none' placeholder=''>";
        vaWithinThePlan += "<table id='WithinThePlan" + counter6 + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td>";
        vaWithinThePlan += "<input class='radio-button'  onchange=\"handleChange('WithinThePlanvalue" + counter6 + "','" + radiovalue1 + "');\"  id='WithinThePlan" + counter6 + "_0' type='radio' name='WithinThePlanR" + counter6 + "' value='" + radiovalue1 + "'><label for='WithinThePlan" + counter6 + "_0' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + radio1 + "</label></td><td>"
        vaWithinThePlan += "<input  class='radio-button' onchange=\"handleChange('WithinThePlanvalue" + counter6 + "','" + radiovalue2 + "');\" id='WithinThePlan" + counter6 + "_1' type='radio' name='WithinThePlanR" + counter6 + "' value='" + radiovalue2 + "'><label for='WithinThePlan" + counter6 + "_1'  class='radio-button-click-target'><span class='radio-button-circle'></span>" + radio2 + "</label></td>";
        vaWithinThePlan += "</tr></tbody></table>";
        Itemhtml.find(".DivWithinThePlan")[0].innerHTML = vaWithinThePlan;
        Itemhtml.find(".DivCourseName")[0].innerHTML = "<input name='CourseName' type=text' id='CourseName" + counter6 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivTrainingHours")[0].innerHTML = "<input name='TrainingHours' type=text' id='TrainingHours" + counter6 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDatefrom6")[0].innerHTML = "<input autocomplete='off' name='Datefrom6' type='text' id='Datefrom6" + counter6 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivDateto6")[0].innerHTML = "<input autocomplete='off' name='Dateto6' type='text' id='Dateto6" + counter1 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivCourseLocation")[0].innerHTML = "<input name='CourseLocation' type=text' id='CourseLocation" + counter6 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTrainingCourses(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV6")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV6').value = counter6;
        $("#FirstItemAA6")[0].innerHTML = "";
    }
    function removerowTrainingCourses(thi) {
        counter6--;
        document.getElementById('hdnsuperDIV6').value = counter6;
        thi.closest('.new').remove();
    }
    function handleChange(ID, radio1) {
        $("#" + ID).val(radio1)
    }
    ///////////////////////////////////////7----------------------------------------------------	
    var counter7 = 0;
    if (document.getElementById('hdnsuperDIV7').value != "") {
        counter7 = Number(document.getElementById('hdnsuperDIV7').value);
    }
    function addExpertise() {
        counter7++;
        $("#FirstItemAA7")[0].innerHTML = $("#FirstItem7")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA7");
        Itemhtml.find(".DivSID7")[0].innerHTML = "<input name='SID7' type=text' id='SID7" + counter7 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivOrganizationName")[0].innerHTML = "<input name='OrganizationName' type=text' id='OrganizationName" + counter7 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivNatureOfTheJob")[0].innerHTML = "<input name='NatureOfTheJob' type=text' id='NatureOfTheJob" + counter7 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivYearsOfExperience")[0].innerHTML = "<input name='YearsOfExperience' type=text' id='YearsOfExperience" + counter7 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivNotes")[0].innerHTML = "<input name='Notes7' type=text' id='Notes7" + counter7 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivCountry select")[0].setAttribute("name", "DropDownCountry7");
        Itemhtml.find(".DivCountry select")[0].setAttribute("id", "DropDownCountry7" + counter7 + "");
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowExpertise(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV7")[0].appendChild(newdiv);

        document.getElementById('hdnsuperDIV7').value = counter7;
        $("#FirstItemAA7")[0].innerHTML = "";
    }
    function removerowExpertise(thi) {
        counter7--;
        document.getElementById('hdnsuperDIV7').value = counter7;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////8----------------------------------------------------
    var counter8 = 0;
    if (document.getElementById('hdnsuperDIV8').value != "") {
        counter8 = Number(document.getElementById('hdnsuperDIV8').value);
    }
    function addPublications() {
        counter8++;
        $("#FirstItemAA8")[0].innerHTML = $("#FirstItem8")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA8");
        Itemhtml.find(".DivSID8")[0].innerHTML = "<input name='SID8' type=text' id='SID8" + counter8 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivBookPublicationTitle")[0].innerHTML = "<input name='BookPublicationTitle' type=text' id='BookPublicationTitle" + counter8 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivTopic")[0].innerHTML = "<input name='Topic' type=text' id='Topic" + counter8 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivNotes")[0].innerHTML = "<input name='Notes8' type=text' id='Notes8" + counter8 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivPublishDate")[0].innerHTML = "<input autocomplete='off' name='PublishDate' type='text' id='PublishDate" + counter8 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowPublications(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV8")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV8').value = counter8;
        $("#FirstItemAA8")[0].innerHTML = "";
    }
    function removerowPublications(thi) {
        counter8--;
        document.getElementById('hdnsuperDIV8').value = counter8;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////9----------------------------------------------------
    var counter9 = 0;
    if (document.getElementById('hdnsuperDIV9').value != "") {
        counter9 = Number(document.getElementById('hdnsuperDIV9').value);
    }
    function addTravelInformations() {
        counter9++;
        $("#FirstItemAA9")[0].innerHTML = $("#FirstItem9")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA9");
        Itemhtml.find(".DivSID9")[0].innerHTML = "<input name='SID9' type=text' id='SID9" + counter9 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivCountryResidentForMoreThan3Months select")[0].setAttribute("name", "DropDownCountryResidentForMoreThan3Months");
        Itemhtml.find(".DivCountryResidentForMoreThan3Months select")[0].setAttribute("id", "DropDownCountryResidentForMoreThan3Months" + counter9 + "");
        Itemhtml.find(".DivTimePeriodFrom")[0].innerHTML = "<input autocomplete='off' name='TimePeriodFrom' type='text' id='TimePeriodFrom" + counter9 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivTimeperiodTo")[0].innerHTML = "<input autocomplete='off' name='TimeperiodTo' type='text' id='TimeperiodTo" + counter9 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivVisitReasons")[0].innerHTML = "<input name='VisitReasons' type=text' id='VisitReasons" + counter9 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTravelInformations(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV9")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV9').value = counter9;
        $("#FirstItemAA9")[0].innerHTML = "";
    }
    function removerowTravelInformations(thi) {
        counter9--;
        document.getElementById('hdnsuperDIV9').value = counter9;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////10----------------------------------------------------
    var counter10 = 0;
    if (document.getElementById('hdnsuperDIV10').value != "") {
        counter10 = Number(document.getElementById('hdnsuperDIV10').value);
    }
    function addParticipations() {
        counter10++;
        $("#FirstItemAA10")[0].innerHTML = $("#FirstItem10")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA10");
        Itemhtml.find(".DivSID10")[0].innerHTML = "<input name='SID10' type=text' id='SID10" + counter10 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivActivityName")[0].innerHTML = "<input name='ActivityName' type=text' id='ActivityName" + counter10 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSponsor")[0].innerHTML = "<input name='Sponsor' type=text' id='Sponsor" + counter10 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivCountry select")[0].setAttribute("name", "DropDownCountry10");
        Itemhtml.find(".DivCountry select")[0].setAttribute("id", "DropDownCountry10" + counter10 + "");
        Itemhtml.find(".DivNatureOfTheParticipation")[0].innerHTML = "<input name='NatureOfTheParticipation' type=text' id='NatureOfTheParticipation" + counter10 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowParticipations(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV10")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV10').value = counter10;
        $("#FirstItemAA10")[0].innerHTML = "";
    }
    function removerowParticipations(thi) {
        counter10--;
        document.getElementById('hdnsuperDIV10').value = counter10;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////11----------------------------------------------------
    var counter11 = 0;
    if (document.getElementById('hdnsuperDIV11').value != "") {
        counter11 = Number(document.getElementById('hdnsuperDIV11').value);
    }
    function addMembership() {
        counter11++;
        $("#FirstItemAA11")[0].innerHTML = $("#FirstItem11")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA11");
        Itemhtml.find(".DivSID11")[0].innerHTML = "<input name='SID11' type=text' id='SID11" + counter11 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivMembership")[0].innerHTML = "<input name='Membership' type=text' id='Membership" + counter11 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLocation")[0].innerHTML = "<input name='Location' type=text' id='Location" + counter11 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivField")[0].innerHTML = "<input name='Field11' type=text' id='Field11" + counter11 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivFromDate")[0].innerHTML = "<input autocomplete='off' name='FromDate11' type='text' id='FromDate11" + counter11 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivToDate")[0].innerHTML = "<input autocomplete='off' name='ToDate11' type='text' id='ToDate11" + counter11 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivNotes")[0].innerHTML = "<input name='Notes11' type=text' id='Notes11" + counter11 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowMembership(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV11")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV11').value = counter11;
        $("#FirstItemAA11")[0].innerHTML = "";
    }
    function removerowMembership(thi) {
        counter11--;
        document.getElementById('hdnsuperDIV11').value = counter11;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////12----------------------------------------------------
    var counter12 = 0;
    if (document.getElementById('hdnsuperDIV12').value != "") {
        counter12 = Number(document.getElementById('hdnsuperDIV12').value);
    }
    function addHopis() {
        counter12++;
        $("#FirstItemAA12")[0].innerHTML = $("#FirstItem12")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA12");
        Itemhtml.find(".DivSID12")[0].innerHTML = "<input name='SID12' type=text' id='SID12" + counter12 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivHoppy")[0].innerHTML = "<input name='Hoppy' type=text' id='Hoppy" + counter12 + "' class='form-control' placeholder=''>";

        Itemhtml.find(".DivNotes")[0].innerHTML = "<input name='Notes12' type=text' id='Notes12" + counter12 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowHopis(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV12")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV12').value = counter12;
        $("#FirstItemAA12")[0].innerHTML = "";
    }
    function removerowHopis(thi) {
        counter12--;
        document.getElementById('hdnsuperDIV12').value = counter12;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////13----------------------------------------------------
    var counter13 = 0;
    if (document.getElementById('hdnsuperDIV13').value != "") {
        counter13 = Number(document.getElementById('hdnsuperDIV13').value);
    }
    function addVoluntaryWork() {
        counter13++;
        $("#FirstItemAA13")[0].innerHTML = $("#FirstItem13")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA13");
        Itemhtml.find(".DivSID13")[0].innerHTML = "<input name='SID13' type=text' id='SID13" + counter13 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivActivityName")[0].innerHTML = "<input name='ActivityName13' type=text' id='ActivityName13" + counter13 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLocation select")[0].setAttribute("name", "Location13");
        Itemhtml.find(".DivLocation select")[0].setAttribute("id", "Location13" + counter13 + "");
        Itemhtml.find(".DivDatefrom")[0].innerHTML = "<input autocomplete='off' name='Datefrom13' type='text' id='Datefrom13" + counter13 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivDateto")[0].innerHTML = "<input autocomplete='off' name='Dateto13' type='text' id='Dateto13" + counter13 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removerowVoluntaryWork(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI cnrtnheadbox2'>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV13")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV13').value = counter13;
        $("#FirstItemAA13")[0].innerHTML = "";
    }
    function removerowVoluntaryWork(thi) {
        counter13--;
        document.getElementById('hdnsuperDIV13').value = counter13;
        thi.closest('.new').remove();
    }
</script>