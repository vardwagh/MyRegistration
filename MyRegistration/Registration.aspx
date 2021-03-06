<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Registration.aspx.cs" Inherits="MyRegistration.Registration" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>My Registration</title>
    <link href="Css/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Registration.css" rel="stylesheet" />
    <script src="Scripts/Registration.js"></script>
    <script>
        function PrintGridData() {

            var prtGrid = document.getElementById('<%=GridView1.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }

    </script>
    </head>
<body>
    
    <form id="form5" runat="server">
       <div class="city1">
        <div style="border:2px solid black" >
            <div style=" margin-left:auto;margin-right:auto; margin-bottom:10px; align-content:center; margin-top:30px">
            <asp:Label ID="lblmobile" style='margin-left:100px' Text="" runat="server" /><asp:LinkButton ID="lbtnLogout" style='margin-left:800px' class="btn btn-default" runat="server" CausesValidation="False" OnClick="lbtnLogout_Click">Logout</asp:LinkButton> 
            </div>
             
            <div >
                
                <table style=" margin-left:auto;margin-right:auto; margin-bottom:10px;  margin-top:30px">
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Label ID="Label30" runat="server" Visible="false"  Text="Registration ID :"></asp:Label><asp:Label ID="LblRegistrationID" runat="server"  Text=""></asp:Label>
                        </td>
                    </tr>
                        <tr >
                            <td>
                                <asp:Button ID="btnMyInfo" style="margin-right:20px; margin-left:20px" class="btn btn-default" runat="server"  Text="Step 1 :  My Information" OnClick="btnMyInfo_Click" CausesValidation="False" />
                            </td>
                            <td>
                                <asp:Button ID="btnDepInfo" style='margin-right:20px' class="btn btn-default" runat="server" Text="Step 2 :  Dependent Information" OnClick="btnDepInfo_Click" CausesValidation="False" />
                            </td>
                            <td>
                                <asp:Button ID="btnFinalize" style='margin-right:20px' class="btn btn-default" runat="server" Text="Step 3 :  Finalization" OnClick="btnFinal_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    

                    </table>

            </div>

            <asp:MultiView ID="MvRegistration" runat="server">
                <asp:View ID="ViewMyInformation" runat="server">

                  <div style="padding-top:10px; padding-bottom:200px" >
                      <table class="city" style="margin-left:auto;margin-right:auto;">
                          <tr>
                              <td class="auto-style39">

                              </td>
                              <td class="auto-style40">
                                  <asp:Label ID="Label1" runat="server" Text="* First Name"></asp:Label>
                              </td>
                              <td class="auto-style41">
                                  <asp:Label ID="Label2" runat="server" Text="Middle Name"></asp:Label>
                              </td>
                              <td class="auto-style42">
                                  <asp:Label ID="Label3" runat="server" Text="* Last Name"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td style="width:400px;" align= "right">
                                  <asp:Label ID="Label4"  runat="server" Text="Name :"></asp:Label>
                              </td>
                              <td class="auto-style22">
                                  <asp:TextBox ID="txtFirstName" Width="250px"  runat="server"></asp:TextBox>   
                              </td>
                              <td class="auto-style9">
                                  <asp:TextBox ID="txtMiddleName" Width="250px"  runat="server"></asp:TextBox>
                              </td>
                              <td class="auto-style8">
                                  <asp:TextBox ID="txtLastName" Width="250px" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td  style="width:400px">

                              </td>
                              <td class="auto-style22">
                                  <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red" ErrorMessage="First Name Required"></asp:RequiredFieldValidator> <br />
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtFirstName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="First Name Must be In Alphabets"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style9">
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtMiddleName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Middle Name Must be In Alphabets"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style8">
                                  <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="Red" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator> <br />
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtLastName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Last Name Must be In Alphabets"></asp:RegularExpressionValidator>
                              </td>
                          </tr>

                           <tr>
                              <td align= "right" class="auto-style10">
                                  <asp:Label ID="Label5" runat="server" Text="* Date Of Birth :"></asp:Label>
                              </td>
                              <td class="auto-style23">
                                  <asp:TextBox ID="txtDOB" runat="server"  AutoPostBack="True" OnTextChanged="txtDOB_TextChanged"></asp:TextBox> <br />
                                  
                              </td>
                              <td class="auto-style12">
                                  
                                  <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" ForeColor="Red" ErrorMessage="Date Of Birth Required"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style13">
                                  <asp:Label ID="Label6" runat="server" Text="Age:"></asp:Label><asp:Label ID="lblAge" runat="server" Text=""></asp:Label> 
                              </td>
                          </tr>

                          <tr>
                              <td align= "right" class="auto-style10">
                                  <asp:Label ID="Label7" runat="server" Text="* Department :"></asp:Label>
                              </td>
                              <td class="auto-style23">
                                  <asp:DropDownList ID="ddlDepartment"  runat="server" ></asp:DropDownList>
                              </td>

                              <td class="auto-style12">
                                  <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" InitialValue="0" ForeColor="Red" ErrorMessage="Department is Required"></asp:RequiredFieldValidator>
                              </td>
                          </tr>


                          <tr>
                              <td align= "right" class="auto-style18">
                                  <asp:Label ID="Label8" runat="server" Text="* Date Of Joining :"></asp:Label>
                              </td>
                              <td class="auto-style19">
                                  <asp:TextBox ID="txtDOJ" runat="server"></asp:TextBox> 
                              </td>
                              <td class="auto-style20">
                                  <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDOJ" ForeColor="Red" ErrorMessage="Date Of Joining Required"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style21">
                                  
                              </td>
                          </tr>


                           <tr>
                              <td align= "right" class="auto-style14">
                                  <asp:Label ID="Label9" runat="server" Text="* Gross Salary :"></asp:Label>
                              </td>
                              <td class="auto-style23">
                                  <asp:TextBox ID="txtGrossSal" runat="server" AutoPostBack="True" OnTextChanged="ddlTax_SelectedIndexChanged"></asp:TextBox> 
                              </td>
                              <td class="auto-style16">
                                  <asp:RegularExpressionValidator ID="regex" runat="server" ControlToValidate="txtGrossSal"  ValidationExpression="\d+" ForeColor="Red"  ErrorMessage="Gross Salary Must Be Number"></asp:RegularExpressionValidator>
                                  <br />
                                  <asp:RequiredFieldValidator ID="rfvGS" runat="server" ControlToValidate="txtGrossSal" ForeColor="Red" ErrorMessage="Gross Salary Required"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style17">
                                  
                              </td>
                          </tr>

                           <tr>
                              <td align= "right" class="auto-style10">
                                  <asp:Label ID="Label10" runat="server" Text="* Tax :"></asp:Label>
                              </td>
                              <td class="auto-style19">
                                  <asp:DropDownList ID="ddlTax" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTax_SelectedIndexChanged">
                                      <asp:ListItem Text="" Value="" />
                                      <asp:ListItem Text="0%" Value="0" />
                                      <asp:ListItem Text="10%" Value="10" />
                                      <asp:ListItem Text="20%" Value="20" />
                                      <asp:ListItem Text="30%" Value="30" />
                                  </asp:DropDownList>
                              </td>

                              <td class="auto-style16">
                                  <asp:RequiredFieldValidator ID="tfvTac" runat="server" ControlToValidate="ddlTax" ForeColor="Red" ErrorMessage="Tax is Required"></asp:RequiredFieldValidator>
                              </td>
                          </tr>

                           <tr>
                              <td align= "right" class="auto-style10">
                                  <asp:Label ID="Label11" runat="server" Text="* Net Salary :"></asp:Label>
                              </td>
                              <td class="auto-style19">
                                   <asp:Label ID="lblNetSalary" runat="server" Text=""></asp:Label> 
                              </td>
                              <td class="auto-style16">
                                 
                              </td>
                              <td class="auto-style13">
                                  
                              </td>
                          </tr>

                          
                           <tr>
                              <td align= "right" class="auto-style30">
                                  
                              </td>
                              <td class="auto-style33">
                                  <asp:Button style='margin-right:20px' class="btn btn-primary" ID="btnSaveNext1"  runat="server" Text="Save & Next" OnClick="btnSaveNext1_Click" />
                                  <asp:Button ID="btnClear1" class="btn btn-warning"  runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear1_Click" />
                              </td>
                               <td class="auto-style32">
                                   <asp:Label ID="lblSuccessfull" runat="server" Text=""></asp:Label>
                               </td>
                               
                          </tr>
                      </table>

                  </div>  

                </asp:View>
                <asp:View ID="ViewDependetInformation" runat="server">

                    <div class="city" style="margin-left:100px; padding-top:10px; padding-bottom:10px; margin-right:100px">
                   <div >

                       <table  style="margin-left:auto;margin-right:auto;">
                           <tr>
                               <td class="auto-style43">

                               </td>
                               <td class="auto-style43">
                                   <asp:Label ID="Label12" runat="server" Text="* Name"></asp:Label>
                               </td>
                               <td class="auto-style44">
                                   <asp:Label ID="Label13" runat="server" Text="* Date Of Birth"></asp:Label>
                               </td>
                               <td class="auto-style43">
                                   <asp:Label ID="Label14" runat="server" Text="Age"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td align= "right" class="auto-style74">
                                   <asp:Label ID="Label15" runat="server" Text="Spouse :"></asp:Label>
                               </td>
                               <td class="auto-style74">
                                   <asp:TextBox ID="txtSpouceName" runat="server"></asp:TextBox>
                               </td>
                               <td class="auto-style77">
                                  <asp:TextBox ID="txtSpouceDOB" runat="server" AutoPostBack="True" OnTextChanged="txtSpouceDOB_TextChanged"></asp:TextBox>
                                     
                               </td>
                               <td class="auto-style74">
                                   <asp:Label ID="lblSpouceAge" runat="server" Text=""></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td class="auto-style9" >
                                  
                               </td>
                               <td class="auto-style9">
                                   <asp:RequiredFieldValidator ID="rfvSpouseName" ControlToValidate="txtSpouceName" ForeColor="Red" runat="server" ErrorMessage="Spouse Name Required"></asp:RequiredFieldValidator>  <br/>
                                    
                               </td>
                               <td class="auto-style645">
                                  <asp:RequiredFieldValidator ID="rfvSpouseDOB" ControlToValidate="txtSpouceDOB" ForeColor="Red" runat="server" ErrorMessage="Spouse DOB Required"></asp:RequiredFieldValidator>
                               </td>
                               <td class="auto-style9">
                                  
                               </td>
                           </tr>
                           <tr>
                               <td>

                               </td>
                               <td class="auto-style9">
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtSpouceName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Spouce Name Must be In Alphabets"></asp:RegularExpressionValidator>
                               </td>
                               <td class="auto-style645">

                               </td>
                           </tr>
                       </table>
                       <hr />
                       <table class="city" style=" margin-left:auto;margin-right:auto;">
                           <tr>
                               <td align="Center" colspan="6" class="auto-style56">
                                    <asp:Label ID="Label32" ForeColor="Green"  runat="server" Text="Only 2 Childs Allowed, Select And Then Enter The Details"></asp:Label>
                                </td>
                           </tr>
                           <tr>

                               <td class="auto-style64"></td>
                               <td class="auto-style644" >* Name</td>
                               <td class="auto-style65">* Date Of Birth</td>
                               <td align= "center" class="auto-style64">Age</td>
                               <td class="auto-style64">* Relation</td>
                           </tr>
                           <tr>

                               <td class="auto-style2">

                                   <asp:CheckBoxList ID="cblChild" runat="server" Height="200px" Width="100px" AutoPostBack="True"  OnSelectedIndexChanged="cblChild_SelectedIndexChanged">
                                       <asp:ListItem  Text = "Child 1" Value = "1"></asp:ListItem>                              
                                        <asp:ListItem Text = "Child 2" Value = "2"></asp:ListItem>
                                        <asp:ListItem Text = "Child 3" Value = "3"></asp:ListItem>
                                        <asp:ListItem Text = "Child 4" Value = "4"></asp:ListItem>
                                     </asp:CheckBoxList>
                                   
                               </td>
                               
                              

                               <td>
                                   <table style="height:200px">
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtNameChild1" Enabled="false"  runat="server"></asp:TextBox>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtNameChild1"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Child Name Must be In Alphabets"></asp:RegularExpressionValidator>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtNameChild2" Enabled="false"  runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtNameChild2"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Child Name Must be In Alphabets"></asp:RegularExpressionValidator>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtNameChild3" Enabled="false"  runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtNameChild3"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Child Name Must be In Alphabets"></asp:RegularExpressionValidator>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtNameChild4" Enabled="false" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtNameChild4"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Child Name Must be In Alphabets"></asp:RegularExpressionValidator>
                                           </td>
                                       </tr>
                                   </table>
                               </td>
                               <td class="auto-style646">
                                   <table  style="height:200px">

                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtDOBChild1" CssClass="datepicker" Enabled="false" runat="server" AutoPostBack="True" OnTextChanged="txtDOBChild1_TextChanged"></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtDOBChild2" CssClass="datepicker" Enabled="false" runat="server" AutoPostBack="True" OnTextChanged="txtDOBChild2_TextChanged"></asp:TextBox>
                                                
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtDOBChild3" CssClass="datepicker" Enabled="false" runat="server" AutoPostBack="True" OnTextChanged="txtDOBChild3_TextChanged"></asp:TextBox>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:TextBox ID="txtDOBChild4" CssClass="datepicker" Enabled="false" runat="server" AutoPostBack="True" OnTextChanged="txtDOBChild4_TextChanged"></asp:TextBox>
                                           </td>
                                       </tr>
                                   </table>
                               </td>
                               <td>
                                   <table style="height:200px">
                                       <tr>
                                           <td>
                                              <asp:Label ID="lblAgeChild1" runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblAgeChild2" runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                              <asp:Label ID="lblAgeChild3" runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblAgeChild4" runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                   </table>
                               </td>
                               <td>
                                   <table style="height:200px">
                                       <tr>
                                           <td>
                                                <asp:DropDownList ID="ddlrelationChild1" Enabled="false" runat="server">
                                                    <asp:ListItem Text="Select" Value="" />
                                                    <asp:ListItem Text="SON" Value="S" />
                                                    <asp:ListItem Text="DAUGHTER" Value="D" />
                                                </asp:DropDownList>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:DropDownList ID="ddlrelationChild2" Enabled="false" runat="server">
                                                   <asp:ListItem Text="Select" Value="" />
                                                    <asp:ListItem Text="SON" Value="S" />
                                                    <asp:ListItem Text="DAUGHTER" Value="D" />
                                               </asp:DropDownList>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                                <asp:DropDownList ID="ddlrelationChild3" Enabled="false"  runat="server">
                                                    <asp:ListItem Text="Select" Value="" />
                                                    <asp:ListItem Text="SON" Value="S" />
                                                    <asp:ListItem Text="DAUGHTER" Value="D" />
                                                </asp:DropDownList>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:DropDownList ID="ddlrelationChild4" Enabled="false" runat="server">
                                                   <asp:ListItem Text="Select" Value="" />
                                                    <asp:ListItem Text="SON" Value="S" />
                                                    <asp:ListItem Text="DAUGHTER" Value="D" />
                                               </asp:DropDownList>
                                           </td>
                                       </tr>
                                   </table>
                               </td>
                               <td>
                                   <table style="height:200px">
                                       <tr>
                                           <td>
                                              <asp:Label ID="lblErrChild1" ForeColor="Red" runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblErrChild2" ForeColor="Red"  runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                              <asp:Label ID="lblErrChild3" ForeColor="Red"  runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblErrChild4" ForeColor="Red"  runat="server" Text=""></asp:Label>
                                           </td>
                                       </tr>

                                   </table>
                               </td>
                               
                           </tr>
                           </table>
                  </div> 
                        <hr />
                    <div >
                        <table class="city" style=" margin-left:auto;margin-right:auto;">
                                    <tr>
                                <td align="Center" style="" class="auto-style66">
                                    <asp:Label ID="Label31" ForeColor="Green"  runat="server" Text="Only 2 Parents Allowed, Select And Then Enter The Details"></asp:Label>
                                </td>

                            </tr>
                           <tr>
                               
                               <td >
                                   <asp:CheckBoxList ID="cblParent" runat="server" RepeatDirection="Horizontal" Width="1276px" AutoPostBack="True" OnSelectedIndexChanged="cblParent_SelectedIndexChanged"   >
                                    <asp:ListItem  Text = "Father" Value = "1"></asp:ListItem>                              
                                        <asp:ListItem Text = "Mother" Value = "2"></asp:ListItem>
                                        <asp:ListItem Text = "Father In Law" Value = "3"></asp:ListItem>
                                        <asp:ListItem Text = "Mother In Law" Value = "4"></asp:ListItem>
                                </asp:CheckBoxList>
                               </td>
                           </tr>
                            <tr>
                                <td class="auto-style69">
                                    <table >
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label16" runat="server" Text="Name :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtFatherName" Enabled="false" runat="server" AutoPostBack="True"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtFatherName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Name Must be Alphabets"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="Label17" runat="server" Text="Name :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtMotherName" Enabled="false" runat="server"></asp:TextBox>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtMotherName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Name Must be Alphabets"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="Label18" runat="server" Text="Name :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtFatherILName" Enabled="false" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtFatherILName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Name Must be Alphabets"></asp:RegularExpressionValidator>
                                            </td>
                                            <td style="width:280px">
                                                <asp:Label ID="Label19" runat="server" Text="Name :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtMotherILName" Enabled="false" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtMotherILName"  runat="server" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"  ErrorMessage="Name Must be Alphabets"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label20" runat="server" Text="Date Of Birth :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtFatherDOB" Enabled="false" CssClass="datepicker1" runat="server" AutoPostBack="True" OnTextChanged="txtFatherDOB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="Label21" runat="server" Text="Date Of Birth :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtMotherDOB" Enabled="false" CssClass="datepicker1" runat="server" AutoPostBack="True" OnTextChanged="txtMotherDOB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="Label22" runat="server" Text="Date Of Birth :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtFatherILDOB" Enabled="false" CssClass="datepicker1" runat="server" AutoPostBack="True" OnTextChanged="txtFatherILDOB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="width:280px">
                                                <asp:Label ID="Label23" runat="server" Text="Date Of Birth :"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtMotherILDOB" Enabled="false" CssClass="datepicker1" runat="server" AutoPostBack="True" OnTextChanged="txtMotherILDOB_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:CheckBox ID="cbfatherDOB" Text="I Dont Know DOB" Enabled="false" runat="server" OnCheckedChanged="cbfatherDOB_CheckedChanged" AutoPostBack="True" />
                                            </td>
                                            <td class="auto-style4">
                                                <asp:CheckBox ID="cbMotherDOB" Text="I Dont Know DOB" Enabled="false"  runat="server" AutoPostBack="True" OnCheckedChanged="cbMotherDOB_CheckedChanged" />
                                            </td>
                                            <td class="auto-style5">
                                                <asp:CheckBox ID="cbfatherILDOB" Text="I Dont Know DOB" Enabled="false" runat="server" AutoPostBack="True" OnCheckedChanged="cbfatherILDOB_CheckedChanged" />
                                            </td>
                                            <td style="width:280px">
                                                <asp:CheckBox ID="cbMotherILDOB" Text="I Dont Know DOB" Enabled="false" runat="server" AutoPostBack="True" OnCheckedChanged="cbMotherILDOB_CheckedChanged" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label24" runat="server" Text="Age : "></asp:Label> <asp:Label ID="lblFatherAge" runat="server" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlFatherAge" Visible="false" runat="server" OnSelectedIndexChanged="ddlFatherAge_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="Label25" runat="server" Text="Age : "></asp:Label> 
                                                <asp:Label ID="lblMotherAge" runat="server"  Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlMotherAge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMotherAge_SelectedIndexChanged" Visible="false">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="Label27" runat="server" Text="Age : "></asp:Label> 
                                                <asp:Label ID="lblFatherILAge" runat="server" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlFatherILAge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFatherILAge_SelectedIndexChanged" Visible="false">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                            <td style="width:280px">
                                                <asp:Label ID="Label29" runat="server" Text="Age : "></asp:Label> 
                                                <asp:Label ID="lblMotherILAge" runat="server" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlMotherILAge" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMotherILAge_SelectedIndexChanged" Visible="false">
                                                </asp:DropDownList>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style58">
                                                <asp:Label ID="lblFatherErr" runat="server" ForeColor="Red"  Text=""></asp:Label> 
                                                
                                            </td>
                                            <td class="auto-style59">
                                                <asp:Label ID="lblMotherErr" runat="server" ForeColor="Red"  Text=""></asp:Label> 
                                                
                                            </td>
                                            <td class="auto-style60">
                                                <asp:Label ID="lblFatherILErr" runat="server" ForeColor="Red"  Text=""></asp:Label> 
                                                
                                            </td>
                                            <td class="auto-style61">
                                                <asp:Label ID="lblMotherILErr" runat="server" ForeColor="Red"  Text=""></asp:Label> 
                                               
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            
                       </table>
                        <hr />
                        <table class="city" style="margin-left:auto;margin-right:auto;">
                            <tr>
                                
                                <td class="auto-style68">
                                    <asp:Button  ID="btnSaveNext2" class="btn btn-primary" runat="server" Text="Save & Next" OnClick="btnSaveNext2_Click" />
                                  <asp:Button ID="btnClear2" style='margin-left:20px' class="btn btn-warning"  runat="server" Text="Clear" OnClick="btnClear2_Click" CausesValidation="False" />
                                </td>
                                
                            </tr>
                        </table>
                        
                    </div>
                </div>

                </asp:View>
                <asp:View ID="ViewFinalization" runat="server">

                <div  style="padding-top:10px; padding-bottom:600px">
                    <table class="city" style=" border:1px solid black; margin-left:auto;margin-right:auto;" >
                        
                        <tr>
                            <th style="width:50px"></th>
                            <th  style="text-align:center">
                                <asp:Label ID="Label26" runat="server" Text="Family Information"></asp:Label>
                            </th>
                            <th style="width:50px"></th>
                        </tr> 

                        <tr>
                            <td></td>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                                <br />
                            </td>
                         <td></td>
                        </tr>

                        </table>
                    <table>
                        <tr>
                            <td >
                                    <asp:Button style='margin-left:500px'  ID="btnFinalizeblock" runat="server" Text="Finalize" OnClick="btnFinalizeblock_Click" />
                                    <asp:Button ID="btnPrint" style='margin-left:400px' OnClientClick="PrintGridData()" runat="server" Text="Print" />
                             </td>
                        </tr>
                        <tr >
                            <td  align="Center"><asp:Label ID="lblMessage" style='margin-left:500px'  runat="server" ForeColor="Green" Text=""></asp:Label></td>
                        </tr>
                    </table>
                 </div>  
                            
                </asp:View>
            </asp:MultiView>
            
        </div>


     </div>        
</form>
        
</body>

</html>

