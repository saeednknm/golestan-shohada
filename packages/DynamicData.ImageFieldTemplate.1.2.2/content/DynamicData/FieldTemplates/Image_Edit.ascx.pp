<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Image_Edit.ascx.cs" Inherits="$rootnamespace$.Image_Edit" %>
<asp:PlaceHolder ID="PlaceHolderImage" runat="server" Visible="false">
    <asp:Image ID="ImageEdit" runat="server" /><br />
</asp:PlaceHolder>
<asp:FileUpload ID="FileUploadEdit" runat="server" />

<asp:CustomValidator runat="server" ID="CustomValidator1" ControlToValidate="FileUploadEdit" EnableClientScript="False" ValidateEmptyText="True" />
