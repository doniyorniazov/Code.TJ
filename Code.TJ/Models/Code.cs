using Code.TJ.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code.TJ.Models
{
    public class Code : EntityBase
    {
        protected Code() { }

        public Code(IContext context) : base(context) { }

        public string Text { get; set; }

        public CodeType Type { get; set; }

        public Guid? TaskId { get; set; }
        public virtual TaskItem Task { get; set; }

        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
    }

    public enum CodeType
    {
        CSharp = 0,
        Php = 1,
        VB = 2
    }
}