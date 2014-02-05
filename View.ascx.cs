using System;
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
        IEnumerable<Item> items;

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
            items = new ItemController().GetItems();
            rptContent.DataSource = items;
            rptContent.DataBind();
        }

        protected void rptContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var imgLogo = e.Item.FindControl("imgLogo") as Image;
            var imgSS = e.Item.FindControl("imgScreenShot") as Image;
            Item dataitem = (Item) e.Item.DataItem;
            imgLogo.ImageUrl = FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.LogoID));
            imgSS.ImageUrl = FileManager.Instance.GetUrl(FileManager.Instance.GetFile(dataitem.ScreenshotID));
        }
    }
}