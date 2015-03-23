using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGitRepositories.Models
{
    public class RepositoryItems
    {
        List<BasicRepository> _items;

        public List<BasicRepository> items
        {
            get { return _items; }
            set { _items = value; }
        }
    }

    public class BasicRepository
    {
        String _id;

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _name;

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        String _full_name;

        public String full_name
        {
            get { return _full_name; }
            set { _full_name = value; }
        }

        String _html_url;
        public String html_url
        {
            get { return _html_url; }
            set { _html_url = value; }
        }

        String _description;
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }


    }


}