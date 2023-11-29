using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace Call_Center
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public bool IsTelefonista()
        {
            return (Session["Cuenta"] as Cuenta).Rol.Nombre == "Telefonista";
        }

        
    }
}