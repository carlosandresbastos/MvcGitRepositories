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

        String _language;

        public String language
        {
            get { return _language; }
            set { _language = value; }
        }

        String _updated_at;

        public String updated_at
        {
            get { return _updated_at; }
            set { _updated_at = value; }
        }

        OwnerInformation _owner;

        public OwnerInformation owner
        {
            get { return _owner; }
            set { _owner = value; }
        }


    }

    public class OwnerInformation
    {
        String _login;

        public String login
        {
            get { return _login; }
            set { _login = value; }
        }
        String _avatar_url;

        public String avatar_url
        {
            get { return _avatar_url; }
            set { _avatar_url = value; }
        }
    }


}