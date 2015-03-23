using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcGitRepositories.Controllers
{
    public class RepositoriesController : Controller
    {
        //
        // GET: /MyRepositories/

        String strURLGetRepositoriesByUser;
        String strURLSearchRepositories;

        String _strMessage;

        // Variable to store Message if exists any problem
        public String StrMessage
        {
            get { return _strMessage; }
            set { _strMessage = value; }
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public RepositoriesController()
        {
            strURLGetRepositoriesByUser = " https://api.github.com/users/{0}/repos";
            strURLSearchRepositories = "https://api.github.com/search/repositories?q={0}&sort={1}&order={2}";

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyRepositories()
        {
            
            ViewBag.Message = "Repositórios do Carlos Bastos.";
            

            return View();
        }

        public String GetMyRepositories()
        {

            
            // Attach user for the repository
            String strUrlWebService = String.Format(strURLGetRepositoriesByUser, "carlosandresbastos");
            String strResponse = GET(strUrlWebService);

            
            return strResponse;
        }

        public String SearchRepositories(String strWord)
        {

            
            // Attach Position to search to the URL
            String strUrlWebService = String.Format(strURLSearchRepositories, strWord);
            String strResponse = GET(strUrlWebService);


            return strResponse;
        }




        // Returns JSON string
        string GET(string url)
        {
            string s;
            using (WebClient client = new WebClient())
            {
                string ua = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:8.0) Gecko/20100101 Firefox/8.0";
                client.Headers.Add(HttpRequestHeader.UserAgent, ua);
                client.UseDefaultCredentials = true;
                s = client.DownloadString(url);
            }
            return s;
        }

    }
}
