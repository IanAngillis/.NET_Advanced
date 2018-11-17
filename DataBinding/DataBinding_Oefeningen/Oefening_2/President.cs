using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_2
{
    public class President
    {
        private string _name;
        private string _imageUrl;

        public President(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
