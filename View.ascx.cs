﻿using System;
using System.Web.UI.WebControls;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using LD2.Showcase.Components;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using System.Collections.Generic;
using DotNetNuke.Services.FileSystem;

namespace LD2.Showcase
{
    public partial class View : ShowcaseModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Make admin panel visible under Edit mode
                if (IsEditable)
                {
                    adminPanel.Visible = true;
                }

                // Make lnkAdd bring up Add control
                LnkAdd.NavigateUrl = EditUrl(string.Empty, string.Empty, "Add");

                FillRepeater();
                
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void FillRepeater()
        {
            IEnumerable<Item> items = new ItemController().GetItems();
            rptContent.DataSource = items;
            rptContent.DataBind();
        }

        protected void rptContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var imgLogo = e.Item.FindControl("imgLogo") as Image;
            var imgSS = e.Item.FindControl("imgScreenShot") as Image;
            var lnkSS = e.Item.FindControl("lnkScreenshot") as HyperLink;
            Item dataitem = (Item) e.Item.DataItem;
            imgLogo.ImageUrl = FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.LogoID));      // Logo image
            imgSS.ImageUrl = FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.ScreenshotID));  // Screenshot image

            // Screenshot HyperLink
            /*
            int height = FileManager.Instance.GetFile(dataitem.ScreenshotID).Height;
            int width = FileManager.Instance.GetFile(dataitem.ScreenshotID).Width;
            string SSUrl = (Request.IsSecureConnection ? "https://" : "http://") + base.PortalAlias.HTTPAlias.ToString() + FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.ScreenshotID));
            lnkSS.NavigateUrl = UrlUtils.PopUpUrl(SSUrl, Control, PortalSettings, false, false, height + 20, width + 20, false, string.Empty);
            */

            createPopUp(lnkSS, dataitem);

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                var pnlControls = e.Item.FindControl("pnlControls") as Panel;

                Item t = (Item) e.Item.DataItem;

                if (IsEditable)
                {
                    pnlControls.Visible = true;
                    lnkDelete.CommandArgument = t.Itm.ToString();
                    lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, "Add", "itmid=" + t.Itm);
                    ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));
                }
            }
        }

        private void createPopUp(HyperLink lnk, Item dataitem)
        {
            int height = FileManager.Instance.GetFile(dataitem.ScreenshotID).Height;
            int width = FileManager.Instance.GetFile(dataitem.ScreenshotID).Width;
            string SSUrl = (Request.IsSecureConnection ? "https://" : "http://") + base.PortalAlias.HTTPAlias.ToString() + FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.ScreenshotID));
            lnk.NavigateUrl = UrlUtils.PopUpUrl(SSUrl, Control, PortalSettings, false, false, height + 20, width + 20, true, string.Empty);
        }

        protected void rptContent_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Add", "itmid" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                var tc = new ItemController();
                tc.DeleteItem(Convert.ToInt32(e.CommandArgument));
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}