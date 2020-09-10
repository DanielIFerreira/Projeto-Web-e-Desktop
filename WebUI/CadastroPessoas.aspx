<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPessoas.aspx.cs" Inherits="WebUI.CadastroPessoas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>:: Cadastro de Pessoas </h2>
    <table>
        <tr>
            <td>Código:</td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
            
        </tr>
          <tr>
            <td>Nome:</td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
              </td>
            
        </tr>
          <tr>
            <td>CPF:</td>
            <td>
                <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
              </td>
            
        </tr>
          <tr>
            <td>Data de Nascimento:</td>
            <td>
                <asp:TextBox ID="txtDtNAscimento" runat="server"></asp:TextBox>
              </td>
            
        </tr>
         <tr>
            <td>Estado Cívil:</td>
            <td>
                <asp:DropDownList ID="ddlEstadosCivis" runat="server">
                    <asp:ListItem Value="S">Solteiro</asp:ListItem>
                    <asp:ListItem Value="C">Casado</asp:ListItem>
                    <asp:ListItem Value="D">Divorciado</asp:ListItem>
                </asp:DropDownList>
              </td>
            
        </tr>
         <tr>
            <td>Sexo:</td>
            <td>
                <asp:RadioButtonList ID="rblSexos" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Feminino</asp:ListItem>
                </asp:RadioButtonList>
              </td>
            
        </tr>
         <tr>
            <td>E-mail:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
              </td>
            
        </tr>
         <tr>
            <td>Telefone:</td>
            <td>
                <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
              </td>
            
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td style="margin-left: 40px">
                <asp:CheckBox ID="cbSMS" runat="server" Text="RecebeSMS" />
              </td>
            
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td style="margin-left: 40px">
                <asp:CheckBox ID="cbEmail" runat="server" Text="RecebeE-mail" />
              </td>
            
        </tr>
    </table>
    <p>
        <asp:Button ID="btInserir" runat="server" OnClick="btInserir_Click" Text="Inserir" Width="108px" />
</p>
<p>
    <asp:Label ID="lblMenssagen" runat="server"></asp:Label>
</p>
<p>
    <asp:GridView ID="grvPessoas" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="CdPessoa" HeaderText="Código" />
            <asp:BoundField DataField="NmPessoa" HeaderText="Nome" />
            <asp:BoundField DataField="NrCPF" HeaderText="CPF" />
            <asp:BoundField DataField="DtNascimento" DataFormatString="{0:d}" HeaderText="Data de Nascimento" />
            <asp:BoundField DataField="DsEmail" HeaderText="E-mail" />
            <asp:CheckBoxField DataField="BtRecebeSMS" HeaderText="Recebe SMS" />
            <asp:CheckBoxField DataField="BtRecebeEmail" HeaderText="Recebe E-mail" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</p>
</asp:Content>
