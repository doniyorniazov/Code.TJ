using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Code.TJ.Models.Common
{
    public class EntityBase : INotifyPropertyChanged
    {
        protected EntityBase()
        {

        }

        public EntityBase(IContext context)
        {
            Context = context;
            Context.Add(this);
        }

        Guid _id;
        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }
            set => _id = value;
        }

        string _title;
        public string Title
        {
            get => _title;
            set { _title = value; NotifyPropertyChanged(); }
        }

        public IContext Context { get; private set; }

        public void SetContext(IContext context)
        {
            Context = context;
        }

        #region Notify

        /// <summary>
        /// Property Changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fire the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property that changed (defaults from CallerMemberName)</param>
        protected void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}