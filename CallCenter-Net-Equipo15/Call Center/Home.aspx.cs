﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace Call_Center
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoIncidenciaDAO tipoIncidenciaDAO = new TipoIncidenciaDAO();
            dgvTiposIncidencias.DataSource = tipoIncidenciaDAO.List();
            dgvTiposIncidencias.DataBind();
        }
    }
}