using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGitRepositories.Models
{
    public class Contributor
    {
        String _login;

        public String login
        {
            get { return _login; }
            set { _login = value; }
        }
        String _id;

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }
        String _avatar_url;

        public String avatar_url
        {
            get { return _avatar_url; }
            set { _avatar_url = value; }
        }
        String _html_url;

        public String html_url
        {
            get { return _html_url; }
            set { _html_url = value; }
        }
        String _type;

        public String type
        {
            get { return _type; }
            set { _type = value; }
        }
        int _contributions;

        public int contributions
        {
            get { return _contributions; }
            set { _contributions = value; }
        }
    }
}