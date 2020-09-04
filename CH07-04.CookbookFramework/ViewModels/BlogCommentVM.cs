using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CH07_03.CookbookMVVM;
using CH07_04.CookbookFramework.Models;

namespace CH07_04.CookbookFramework.ViewModels
{
    class BlogCommentVM : ViewModelBase<BlogComment>
    {
        public string Text
        {
            get { return Model.Text; }
            set
            {
                Model.Text = value;
                OnPropertyChanged("IsCommentOK");
            }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                OnPropertyChanged("IsCommentOK");
            }
        }

        public bool IsCommentOK
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Model.Name) &&
                    !string.IsNullOrWhiteSpace(Model.Text);
            }
        }
    }
}
