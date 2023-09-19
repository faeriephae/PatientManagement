using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatientManagement.Data.Models
{
    public interface IEntity 
    {
    }

    //to find all types that inherit from a base class(IEntity) via reflection
    //also interface bc inheritance isn't limited
    public abstract class BaseEntity<T> : IEntity
    {
        [Key]
        //Generic nullable, in case key is combined and not int
        public T? Id { get; set; }

        public override string ToString() => $"{GetType().Name}";

        #region Other way to do it

        //public virtual int Id { get; }
        //public static void OnModelCreating<TBase>(ModelBuilder builder)
        //    where TBase : class, IBase
        //{
        //    builder.Entity<TBase>().HasKey(_base => _base.Id);
        //}
        #endregion
    }

    public abstract class Entity : BaseEntity<int>
    {
        //every table has int id
    }
}
