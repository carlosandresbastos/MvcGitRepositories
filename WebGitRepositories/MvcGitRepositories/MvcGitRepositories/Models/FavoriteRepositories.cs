using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGitRepositories.Models
{
    public class FavoriteRepositories
    {
        List<RepositoryFavorite> _Repositories;

        public List<RepositoryFavorite> Repositories
        {
            get { return _Repositories; }
            set { _Repositories = value; }
        }
    }
    public class RepositoryFavorite
    {
        String _IdRepository;

        public String IdRepository
        {
            get { return _IdRepository; }
            set { _IdRepository = value; }
        }
    }


}