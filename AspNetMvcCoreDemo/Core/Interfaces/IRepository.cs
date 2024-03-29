﻿#region using

using System.Collections.Generic;
using ShowInfos.Core.Model;

#endregion

namespace ShowInfos.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> List(List<int> ids);
    }
}