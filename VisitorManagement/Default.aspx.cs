using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;

namespace VisitorManagement
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string VisitorSignIn()
        {
            //return new List<dynamic>
            //{
            //    new {label = "Hello", value = "Hello"}
            //};           

            return "foo";
        }
    }
}