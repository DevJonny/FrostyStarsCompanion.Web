using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Model.Frostgrave;

namespace FrostyStarsCompanion.Web.Services
{
    public interface IDataStore<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
    }
}