using DotNetNuke.Common;
using LD2.Showcase.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD2.Showcase
{
    public partial class Add : ShowcaseModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var i = new Item()
            {
                Title = txtTitle.Text,
                Link = txtLink.Text,
                Description = txtDescription.Text,
                LogoID = LogoUpldr.FileID,
                ScreenshotID = ScrnShtUpldr.FileID
            };

            new ItemController().CreateItem(i);

            Response.Redirect(Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL());
        }
    }
}