using Code.TJ.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code.TJ.Models
{
    public class TaskItem : EntityBase
    {
        protected TaskItem()
        {

        }

        public TaskItem(IContext context) : base(context)
        {

        }

        public string Description { get; set; }

        public string Explanation { get; set; }

        public int Number { get; set; }

        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime? CreatedDate { get; set; }

        public TaskType Type { get; set; }

        public TaskStatus Status { get; set; }

        public virtual ICollection<Code> Codes { get; set; }
    }

    public enum TaskStatus
    {
        Approved = 0,
        WaitingOnApproval = 1
    }

    public enum TaskType
    {
        Question = 0,
        Syntax = 1
    }
}