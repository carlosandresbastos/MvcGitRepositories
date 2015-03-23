using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcGitRepositories.Controllers;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace MvcGitRepositories.Models
{
    public class RepositoryModel
    {

        public List<BasicRepository> GetRepositoriesbyUser()
        {
            RepositoriesController objRep = new RepositoriesController();
            String strResponse =  objRep.GetMyRepositories();
            
            List<BasicRepository> objRepository = new JavaScriptSerializer().Deserialize<List<BasicRepository>>(strResponse); 
            
            
            return objRepository;
        }

        public RepositoryItems GetRepositoriesbyWord(String strWord)
        {
            RepositoriesController objRep = new RepositoriesController();
            String strResponse = objRep.SearchRepositoriesByWord(strWord);
            RepositoryItems objRepository = new JavaScriptSerializer().Deserialize<RepositoryItems>(strResponse);


            return objRepository;
        }
 
    }
}