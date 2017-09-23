using SimpleLogin.Application;
using SimpleLogin.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IAppServiceBase<TEntity> _appServiceBase;

        public AppServiceBase(AppServiceBase<TEntity> appServiceBase)
        {
            _appServiceBase = appServiceBase;
        }
        public void Add(TEntity obj)
        {
            _appServiceBase.Add(obj);
        }

        public void Dispose()
        {
            _appServiceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _appServiceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _appServiceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _appServiceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _appServiceBase.Update(obj);
        }
    }
}
