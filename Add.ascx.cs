using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.FileSystem;
using LD2.Showcase.Components;
using System;

namespace LD2.Showcase
{
    public partial class Add : ShowcaseModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (ItemId > 0)
                    {
                        var i = new ItemController().GetItem(ItemId);
                        if (i != null)
                        {
                            txtTitle.Text = i.Title;
                            txtLink.Text = i.Link;
                            txtDescription.Text = i.Description;
                            LogoUpldr.FilePath = FileManager.Instance.GetFile(i.LogoID).FileName;
                            ScrnShtUpldr.FilePath = FileManager.Instance.GetFile(i.ScreenshotID).FileName;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var i = new Item();
            var iC = new ItemController();

            // Edit Item values
            if (ItemId > 0)
            {
                i = iC.GetItem(ItemId);
                i.Title = txtTitle.Text.Trim();
                i.Link = txtLink.Text.Trim();
                i.Description = txtDescription.Text.Trim();
                i.LogoID = LogoUpldr.FileID;
                i.ScreenshotID = ScrnShtUpldr.FileID;
            }
            else
            {
                i = new Item()
                {
                    Title = txtTitle.Text,
                    Link = txtLink.Text,
                    Description = txtDescription.Text,
                    LogoID = LogoUpldr.FileID,
                    ScreenshotID = ScrnShtUpldr.FileID
                };
            }

            // Update Item
            if (ItemId > 0)
            {
                iC.UpdateItem(i);
            }
            else // Create new Item
            {
                new ItemController().CreateItem(i);
            }

            Response.Redirect(Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
    }
}