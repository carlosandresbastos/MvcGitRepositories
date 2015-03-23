using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcGitRepositories.Controllers;

namespace MvcGitRepositories.Models
{
    public class RepositoryModel
    {
        public String GetRepositoriesbyUser()
        {
            RepositoriesController objRep = new RepositoriesController();
            return objRep.GetMyRepositories();
            
        }
    }
}