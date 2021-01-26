using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.estadisticas
{
    public partial class goleadores : System.Web.UI.Page
    {
        Estadisticas est = new Estadisticas();
        protected void Page_Load(object sender, EventArgs e)
        {
            gv1.DataSource = est.Goleadores();
            gv1.DataBind();
        }
    }
}