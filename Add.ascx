<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add.ascx.cs" Inherits="LD2.Showcase.Add" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="FilePicker" Src="~/controls/FilePickerUploader.ascx" %>

<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormItem">
        <dnn:Label ID="lblTitle" runat="server" />
        <asp:TextBox ID="txtTitle" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label ID="lblLink" runat="server" />
        <asp:TextBox ID="txtLink" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label ID="lblDescription" runat="server" />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="20" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label ID="lblLogo" runat="server" />
        <dnn:FilePicker ID="LogoUpldr" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label ID="lblScreenshot" runat="server" />
        <dnn:FilePicker ID="ScrnShtUpldr" runat="server" />
    </div>
</div>
<div style="float: left;">
    <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
    <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />
</div>