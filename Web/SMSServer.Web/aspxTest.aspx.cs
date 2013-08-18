using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSServer.Web
{
    public partial class aspxTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("[{ id:'031',	name:'n3.n1',	isParent:true},{ id:'032',	name:'n3.n2',	isParent:false},{ id:'033',	name:'n3.n3',	isParent:true},{ id:'034',	name:'n3.n4',	isParent:false}]");
        }
    }
}