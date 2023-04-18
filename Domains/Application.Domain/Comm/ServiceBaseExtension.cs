using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions;
using Autofac;

using Component.Data;
using Component.Web;
using Component.Core.Common;

namespace Application.Domain
{
    public abstract class ServiceBaseExtension<T> : RepositoryServiceBase<T>, IDisposable
       where T : class
    {
        public IList<IDisposable> DisposableObjects { get; private set; }

        public ServiceBaseExtension(string connKey = "DefaultConnection")
            : base(connKey)
        {
            DisposableObjects = new List<IDisposable>();
        }


        protected void AddDisposableObject(object obj)
        {
            IDisposable disposable = obj as IDisposable;
            if (null != disposable)
            {
                DisposableObjects.Add(disposable);
            }
        }

        public void Dispose()
        {
            foreach (IDisposable obj in DisposableObjects)
            {
                if (null != obj)
                {
                    obj.Dispose();
                }
            }
        }
    }
}