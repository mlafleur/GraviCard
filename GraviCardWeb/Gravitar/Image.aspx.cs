using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GraviCardWeb.Gravitar
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var emailAddress = Request.QueryString[0];
            emailAddress = emailAddress.Trim();
            emailAddress = emailAddress.ToLower();
            string hash;
            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(emailAddress));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                hash = sBuilder.ToString();
            }

            Response.ContentType = "application/json"; //JSON Text output
            Response.Write("https://www.gravatar.com/avatar/" + hash + "?d=blank");
        }
    }
}