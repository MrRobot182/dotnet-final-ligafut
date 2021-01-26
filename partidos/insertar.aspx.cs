using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LigaFutbol.partidos
{
    public partial class insertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SeleccionLocal(object sender, EventArgs e)
        {

        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.DayOfWeek != DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }

        }

        protected void Insertar(object sender, EventArgs e)
        {
            
        }
    }
}