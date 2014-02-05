<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="LD2.Showcase.View" %>

<asp:Panel ID="adminPanel" runat="server" Visible="false">
    <asp:HyperLink ID="LnkAdd" runat="server" resourceKey="BtnAdd" CssClass="dnnTertiaryAction" />
</asp:Panel>

<asp:Repeater ID="rptContent" runat="server" OnItemDataBound="rptContent_ItemDataBound">
    <ItemTemplate>
        <div class="LD2_Showcase">
            <!-- Logo -->
            <div class="LD2_Logo">
                <a href='<%#DataBinder.Eval(Container.DataItem,"Link").ToString() %>'><asp:Image ID="imgLogo" runat="server" /></a>
            </div>

            <!-- Title & Description -->
            <div class="LD2_TD">
                <div class="LD2_Title">
                    <asp:HyperLink ID="lnkTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Title").ToString() %>' 
                        NavigateUrl='<%#DataBinder.Eval(Container.DataItem,"Link").ToString() %>'/>
                </div>

                <div class="LD2_Description">
                    <asp:Label ID="lblDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description").ToString() %>' />
                </div>
            </div>

            <!-- Screenshot -->
            <div class="LD2_Screenshot">
                <asp:Image ID="imgScreenshot" runat="server" />
            </div>
        </div>
        
        <div style="margin-bottom: 50px;"></div>
    </ItemTemplate>
</asp:Repeater>
