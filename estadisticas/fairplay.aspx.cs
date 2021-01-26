using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.estadisticas
{
    public partial class fairplay : System.Web.UI.Page
    {
        Estadisticas est = new Estadisticas();
        protected void Page_Load(object sender, EventArgs e)
        {
            gv1.DataSource = est.FairPlay();
            gv1.DataBind();
        }
    }
}