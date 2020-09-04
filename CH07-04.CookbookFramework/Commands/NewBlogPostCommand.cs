using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CH07_03.CookbookMVVM;
using CH07_04.CookbookFramework.Models;

namespace CH07_04.CookbookFramework.Commands
{
    class NewBlogPostCommand : CommandBase
    {
        Blog _blog;
        BlogPost _post;
        public NewBlogPostCommand(Blog blog)
        {
            _blog = blog;
        }

        public override void Execute(object parameter)
        {
            if (_post == null) _post = (BlogPost)parameter;
            _blog.Posts.Add(_post);
        }

        public override void Undo()
        {
            _blog.Posts.Remove(_post);
        }
    }
}
