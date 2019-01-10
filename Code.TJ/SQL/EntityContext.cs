using Code.TJ.Models;
using Code.TJ.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Code.TJ.SQL
{
    public class EntityContext : DbContext, IContext
    {
        public EntityContext()
       : base("data source=localhost;initial catalog=CodeTJ;integrated security=True;")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.CreateIfNotExists();
            var context = ((IObjectContextAdapter)this).ObjectContext;
            context.ObjectStateManager.ObjectStateManagerChanged += ObjectStateManager_ObjectStateManagerChanged;
            context.ObjectMaterialized += Context_ObjectMaterialized;
        }

        void Context_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            if (!(e.Entity is EntityBase entity))
                return;
            SetEntityContext(entity);
        }

        void ObjectStateManager_ObjectStateManagerChanged(object sender, CollectionChangeEventArgs e)
        {
            if (!(e.Element is EntityBase entity))
                return;
            SetEntityContext(entity);
        }

        void SetEntityContext(EntityBase entity)
        {
            if (entity.Context == null)
            {
                entity.SetContext(this);
            }
        }

        public void Add<T>(T entity) where T : EntityBase
        {
            this.Entry(entity).State = EntityState.Added;
        }

        public IQueryable<T> GetEntities<T>() where T : EntityBase
        {
            try
            {
                var type = typeof(T);
                return GetEntities(type).Cast<T>();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid Entity Type supplied for Lookup", ex);
            }
        }

        public IQueryable<T> GetEntities<T>(IEnumerable<string> properties) where T : EntityBase
        {
            var result = GetEntities(typeof(T)).Cast<T>();
            return properties.Aggregate(result, (current, property) => current.Include(property)).Cast<T>();
        }

        public IQueryable GetEntities(Type typeOfEntity)
        {
            try
            {
                return Set(typeOfEntity).AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Mappings
        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<Code.TJ.Models.Code> Codes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.Entity<EntityBase>().HasKey(e => e.Id);
            TaskMapping(modelBuilder);
            CodeMapping(modelBuilder);
            UserMapping(modelBuilder);
        }

        private void TaskMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().ToTable(nameof(TaskItem));
            modelBuilder.Entity<TaskItem>().HasOptional(g => g.User).WithMany(a => a.Tasks)
                .HasForeignKey(g => g.UserId);
            //modelBuilder.Entity<TaskItem>().Property(f => f.CreatedDate).HasColumnType("datetime2");
        }

        private void CodeMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Code>().ToTable(nameof(Models.Code));
            modelBuilder.Entity<Models.Code>().HasOptional(g => g.User).WithMany(a => a.Codes)
                .HasForeignKey(g => g.UserId);
            modelBuilder.Entity<Models.Code>().HasOptional(g => g.Task).WithMany(a => a.Codes)
             .HasForeignKey(g => g.TaskId);
        }

        void UserMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
        }
        #endregion
    }
}