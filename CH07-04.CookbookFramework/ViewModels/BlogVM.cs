using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CH07_03.CookbookMVVM;
using CH07_04.CookbookFramework.Models;
using CH07_04.CookbookFramework.Views;

namespace CH07_04.CookbookFramework.ViewModels
{
    public class BlogVM : ViewModelBase<Blog, MainVM>
    {
        public BloggerVM Blogger
        {
            get { return new BloggerVM { Model = Model.Blogger }; }
        }

        ICommand _newPostCommand;
        public ICommand NewPostCommand
        {
            get
            {
                return _newPostCommand ?? (_newPostCommand =
                   new RelayCommand(() => {
                       var post = new BlogPostVM
                       {
                           Model = new BlogPost()
                       };
                       var dlg = new NewPostWindow
                       {
                           DataContext = post
                       };
                       if (dlg.ShowDialog() == true)
                       {
                           post.Model.When = DateTime.Now;
                           Model.Posts.Add(post.Model);
                           OnPropertyChanged("Posts");
                       }
                   }));
            }
        }

        public IEnumerable<BlogPostVM> Posts
        {
            get
            {
                return Model.Posts.Select(post =>
                   new BlogPostVM { Model = post });
            }
        }
        public BlogVM(Blog blog, MainVM parent) : base(blog, parent)
        {
            var notify = (INotifyCollectionChanged)blog.Posts;
            if (notify != null)
            {
                notify.CollectionChanged += delegate {
                    OnPropertyChanged("Posts");
                };
            }
        }
    }
}
