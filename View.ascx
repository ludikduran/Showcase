<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="LD2.Showcase.View" %>
<asp:Panel ID="adminPanel" runat="server" Visible="false">
    <asp:HyperLink ID="LnkAdd" runat="server" resourceKey="BtnAdd" CssClass="dnnTertiaryAction" />
</asp:Panel>

<asp:Repeater ID="rptContent" runat="server" OnItemDataBound="rptContent_ItemDataBound" OnItemCommand="rptContent_ItemCommand">
    <ItemTemplate>
        <div class="LD2_Showcase">
            <!-- Logo -->
            <div class="LD2_Logo">
                <a href='<%#DataBinder.Eval(Container.DataItem,"Link").ToString() %>'>
                    <asp:Image ID="imgLogo" runat="server" /></a>
            </div>

            <!-- Title & Description -->
            <div class="LD2_TD">
                <div class="LD2_Title">
                    <asp:HyperLink ID="lnkTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Title").ToString() %>'
                        NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Link").ToString() %>' />
                </div>

                <div class="LD2_Description">
                    <asp:Label ID="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description").ToString() %>' />
                </div>
            </div>

            <!-- Screenshot -->
            <asp:HyperLink ID="lnkScreenshot" runat="server">
                <div class="LD2_Screenshot">
                    <asp:Image ID="imgScreenshot" runat="server" />
                </div>
            </asp:HyperLink>
        </div>

        <div class="LD2_Showcase_pnlControls">
            <asp:Panel ID="pnlControls" runat="server" Visible="false">
                <asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="lnkEdit.Text" />
                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" ResourceKey="lnkDelete.Text" />
            </asp:Panel>
        </div>
    </ItemTemplate>
</asp:Repeater>
