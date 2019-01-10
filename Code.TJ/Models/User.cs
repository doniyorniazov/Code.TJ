using Code.TJ.Models.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Code.TJ.Models
{
    public class User : EntityBase
    {
        protected User() { }

        public User(IContext context) : base(context)
        {
            Tasks = new ObservableCollection<TaskItem>();
            Codes = new ObservableCollection<Code>();
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<TaskItem> Tasks { get; set; }

        public virtual ICollection<Code> Codes { get; set; }
    }

    public enum Role
    {
        Teacher = 0,
        Student = 1
    }
}