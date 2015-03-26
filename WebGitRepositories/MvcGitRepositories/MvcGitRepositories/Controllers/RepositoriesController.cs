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
using MvcGitRepositories.Models;
using System.Xml.Serialization;
using System.Web.Script.Serialization;

namespace MvcGitRepositories.Controllers
{
    public class RepositoriesController : Controller
    {
        //
        // GET: /MyRepositories/

        /// <summary>
        /// URL For GET repositories by User
        /// </summary>
        String strURLGetRepositoriesByUser;

        /// <summary>
        /// URL for Search repositories
        /// </summary>
        String strURLSearchRepositories;

        /// <summary>
        /// Path of XML File to save favorites
        /// </summary>
        String strPath;

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
            strPath = String.Concat(System.Web.HttpContext.Current.Server.MapPath("/"), "favorites.xml");
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method for View - Repository
        /// </summary>
        /// <returns>View of my repositories</returns>
        public ActionResult MyRepositories()
        {
            
            ViewBag.Message = "Repositórios do Carlos Bastos.";
            

            return View();
        }

        public ActionResult FavoritesRepositories()
        {

            ViewBag.Message = "Repositórios Favoritos";


            return View();
        }

        public ActionResult SearchRepositories()
        {

            ViewBag.Message = "Repositórios do Carlos Bastos.";


            return View();
        }


        // Get Repositories of Carlos Bastos
        public String GetMyRepositories()
        {

            
            // Attach user for the repository
            String strUrlWebService = String.Format(strURLGetRepositoriesByUser, "carlosandresbastos");
            String strResponse = GET(strUrlWebService);

            
            return strResponse;
        }


        /// <summary>
        /// Search repositories that match with any word
        /// </summary>
        /// <param name="strWord">Word for search</param>
        /// <returns>Returns a string with the JSON from Web Service</returns>
        public String SearchRepositoriesByWord(String strWord)
        {

            
            // Attach Position to search to the URL
            String strUrlWebService = String.Format(strURLSearchRepositories, strWord, "stars", "desc" );
            String strResponse = GET(strUrlWebService);


            return strResponse;
        }


        
        /// <summary>
        /// Method to connect to a Web API and get JSON Data in String format
        /// </summary>
        /// <param name="url">URL of the method of the web API</param>
        /// <returns>JSON data from web service</returns>
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


        /// <summary>
        /// Web method to Save a Favorite
        /// </summary>
        /// <param name="idFavorite">Code of the favorite</param>
        /// <param name="favUrl">URL to get data from favorite</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveFavorites(String idFavorite, String favUrl)
        {
            RepositoryFavorite objRepFav = new RepositoryFavorite();

            

            objRepFav.IdRepository = idFavorite;
            objRepFav.Url = favUrl;


            FavoriteRepositories objFav = new FavoriteRepositories();
            objFav = DeserializeXML(strPath);
            objFav.Repositories.Add(objRepFav);


            XmlSerializer writer =  new XmlSerializer(typeof(FavoriteRepositories));
            StreamWriter file = new System.IO.StreamWriter(strPath);
            writer.Serialize(file, objFav);
            file.Close();

            return Json(objFav);
        }

        public List<BasicRepository> GetFavorites() {
            List<BasicRepository> objRepos = new List<BasicRepository>();
            FavoriteRepositories objFavorites = this.DeserializeXML(strPath);
            foreach(RepositoryFavorite objFavorite in objFavorites.Repositories)
            {
                String strResponse = this.GET(objFavorite.Url);
                BasicRepository objRepository = new JavaScriptSerializer().Deserialize<BasicRepository>(strResponse);
                objRepos.Add(objRepository);
            }

            return objRepos;
        }

         [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetContributors(String url)
        {
            List<Contributor> objContributors = new List<Contributor>();
            String strResponse = this.GET(url);
            objContributors = new JavaScriptSerializer().Deserialize<List<Contributor>>(strResponse);

            return Json(objContributors);
        }

        public FavoriteRepositories DeserializeXML(String strPathXML)
        {
            FileInfo objFile = new FileInfo(strPathXML);
            FavoriteRepositories objFav = new FavoriteRepositories();

            if (objFile.Exists)
            {
                XmlSerializer objDeserializer = new XmlSerializer(typeof(FavoriteRepositories));
                StreamReader strReadfile = new System.IO.StreamReader(strPathXML);
                var obj = objDeserializer.Deserialize(strReadfile);
                strReadfile.Close();

                objFav = (FavoriteRepositories)obj;
                

            }
            else {
                //If file don't exists, create a new one
                objFav.Repositories = new List<RepositoryFavorite>();
            
            }
           
                return objFav;    
            


        }



 

    }
}
