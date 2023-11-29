using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsLogged())
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }

        private bool IsLogged()
        {
            return Session["Usuario"] != null;
        }

        public bool IsTelefonista()
        {
            return (Session["Cuenta"] as Cuenta).Rol.Nombre == "Telefonista";
        }

        public void DisableButtons(List<LinkButton> linkButtons)
        {
            linkButtons.ForEach(button => button.Enabled = false);
        }

        public void DisableButtonsInRepeater(Repeater repeater)
        {
            List<LinkButton> linkButtons = new List<LinkButton>();

            foreach (RepeaterItem item in repeater.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnUpdate = (LinkButton)item.FindControl("BtnUpdate");
                    if (btnUpdate != null)
                    {
                        linkButtons.Add(btnUpdate);
                    }

                    LinkButton btnQuitar = (LinkButton)item.FindControl("BtnQuitar");
                    if (btnQuitar != null)
                    {
                        linkButtons.Add(btnQuitar);
                    }
                }
            }

            DisableButtons(linkButtons);
        }

    }
}