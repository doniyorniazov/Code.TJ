using Code.TJ.Models;
using Code.TJ.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code.TJ.SQL
{
    public class DemoDataCreator
    {
        public EntityContext Context { get; set; }
        public DemoDataCreator()
        {
            Context = new EntityContext();
        }

        public void CreateDemoData()
        {
            #region TeacherUser

            var DoniyorUser = new User(Context);
            DoniyorUser.Name = "Doniyor";
            DoniyorUser.LastName = "Niyozov";
            DoniyorUser.Role = Role.Teacher;
            DoniyorUser.Password = Security.HashSHA1("Test1234");

            #region Question

            var task = new TaskItem(Context);
            task.User = DoniyorUser;
            task.Title = "Қимати ҳарорати боду ҳаво T";
            task.Description = "Қимати ҳарорати боду ҳаво T бо градусҳои Фаренгейт дода шудааст. Қимати ин ҳароратро бо градусҳои Селсия муайян кунед. Ҳарорат бо Селсия TC  ва ҳарорат бо Фаренгейт TF бо ҳам чунин алоқамандӣ доранд:";
            task.Type = TaskType.Question;
            task.Status = TaskStatus.Approved;

            var code = new Code.TJ.Models.Code(Context) { Task = task, User = DoniyorUser, Text = "", Type = CodeType.CSharp };
            var code2 = new Code.TJ.Models.Code(Context) { Task = task, User = DoniyorUser, Text = "", Type = CodeType.Php };
            var code3 = new Code.TJ.Models.Code(Context) { Task = task, User = DoniyorUser, Text = "", Type = CodeType.VB };

            var task2 = new TaskItem(Context);
            task2.User = DoniyorUser;
            task2.Title = "Қимати кунҷ б бо градусҳо дода шудааст";
            task2.Description = "Қимати кунҷ б бо градусҳо дода шудааст (0 < б < 360). Бо назардошти он ки 180° = р радиан, қимати ин кунҷро бо радианҳо муайян кунед. Ба сифати қимати р адади 3.14 истифода баред.";
            task2.Type = TaskType.Question;
            task2.Status = TaskStatus.Approved;


            var code1Oftask2 = new Code.TJ.Models.Code(Context) { Task = task2, User = DoniyorUser, Text = "", Type = CodeType.CSharp };
            var code2Oftask2 = new Code.TJ.Models.Code(Context) { Task = task2, User = DoniyorUser, Text = "", Type = CodeType.Php };
            var code3Oftask2 = new Code.TJ.Models.Code(Context) { Task = task2, User = DoniyorUser, Text = "", Type = CodeType.VB };
            #endregion

            #region Syntax

            var task3 = new TaskItem(Context);
            task3.User = DoniyorUser;
            task3.Title = "";
            task3.Description = "";
            task3.Type = TaskType.Syntax;
            task3.Status = TaskStatus.Approved;

            var code1Oftask3 = new Code.TJ.Models.Code(Context) { Task = task3, User = DoniyorUser, Text = "", Type = CodeType.CSharp };
            var code2Oftask3 = new Code.TJ.Models.Code(Context) { Task = task3, User = DoniyorUser, Text = "", Type = CodeType.Php };
            var code3Oftask3 = new Code.TJ.Models.Code(Context) { Task = task3, User = DoniyorUser, Text = "", Type = CodeType.VB };

            var task4 = new TaskItem(Context);
            task3.User = DoniyorUser;
            task3.Title = "";
            task3.Description = "";
            task3.Type = TaskType.Syntax;
            task3.Status = TaskStatus.Approved;

            var code1Oftask4 = new Code.TJ.Models.Code(Context) { Task = task4, User = DoniyorUser, Text = "", Type = CodeType.CSharp };
            var code2Oftask4 = new Code.TJ.Models.Code(Context) { Task = task4, User = DoniyorUser, Text = "", Type = CodeType.Php };
            var code3Oftask4 = new Code.TJ.Models.Code(Context) { Task = task4, User = DoniyorUser, Text = "", Type = CodeType.VB };
            #endregion

            #endregion

            #region ShahnozaUser

            var ShahnozaUser = new User(Context);
            ShahnozaUser.Name = "Shahnoza";
            ShahnozaUser.LastName = "Niyozova";
            ShahnozaUser.Password = Security.HashSHA1("test");
            ShahnozaUser.Role = Role.Student;

            #region Question

            var question1 = new TaskItem(Context);
            question1.User = ShahnozaUser;
            question1.Title = "";
            question1.Description = "";
            question1.Status = TaskStatus.Approved;
            question1.Type = TaskType.Question;

            var CSharpCodeOfQuestion1 = new Code.TJ.Models.Code(Context) { Task = question1, User = ShahnozaUser, Text = "", Type = CodeType.CSharp };
            var PhpCodeOfQuestion1 = new Code.TJ.Models.Code(Context) { Task = question1, User = ShahnozaUser, Text = "", Type = CodeType.Php };
            var VBCodeOfQuestion1 = new Code.TJ.Models.Code(Context) { Task = question1, User = ShahnozaUser, Text = "", Type = CodeType.VB };

            var question2 = new TaskItem(Context);
            task2.User = ShahnozaUser;
            task2.Title = "";
            task2.Description = "";
            question1.Status = TaskStatus.WaitingOnApproval;
            question1.Type = TaskType.Question;
            var CSharpCodeOfQuestion2 = new Code.TJ.Models.Code(Context) { Task = question2, User = ShahnozaUser, Text = "", Type = CodeType.CSharp };
            var PhpCodeOfQuestion2 = new Code.TJ.Models.Code(Context) { Task = question2, User = ShahnozaUser, Text = "", Type = CodeType.Php };
            var VBCodeOfQuestion2 = new Code.TJ.Models.Code(Context) { Task = question2, User = ShahnozaUser, Text = "", Type = CodeType.VB };

            #endregion

            #region Syntax

            var syntax1 = new TaskItem(Context);
            task3.User = ShahnozaUser;
            task3.Title = "";
            task3.Description = "";
            question1.Status = TaskStatus.Approved;
            question1.Type = TaskType.Syntax;
            var CSharpCodeOfSyntax1 = new Code.TJ.Models.Code(Context) { Task = syntax1, User = ShahnozaUser, Text = "", Type = CodeType.CSharp };
            var PhpCodeOfSyntax1 = new Code.TJ.Models.Code(Context) { Task = syntax1, User = ShahnozaUser, Text = "", Type = CodeType.Php };
            var VBCodeOfSyntax1 = new Code.TJ.Models.Code(Context) { Task = syntax1, User = ShahnozaUser, Text = "", Type = CodeType.VB };

            var syntax2 = new TaskItem(Context);
            task3.User = ShahnozaUser;
            task3.Title = "";
            task3.Description = "";
            question1.Status = TaskStatus.WaitingOnApproval;
            question1.Type = TaskType.Syntax;

            var CSharpCodeOfsyntax2 = new Code.TJ.Models.Code(Context) { Task = syntax2, User = ShahnozaUser, Text = "", Type = CodeType.CSharp };
            var PhpCodeOfsyntax2 = new Code.TJ.Models.Code(Context) { Task = syntax2, User = ShahnozaUser, Text = "", Type = CodeType.Php };
            var VBCodeOfsyntax2 = new Code.TJ.Models.Code(Context) { Task = syntax2, User = ShahnozaUser, Text = "", Type = CodeType.VB };
            #endregion

            #endregion

            Context.SaveChanges();
        }

    }
}