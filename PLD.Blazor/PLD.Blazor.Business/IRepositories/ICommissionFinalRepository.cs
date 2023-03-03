﻿using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.IRepositories
{
    public interface ICommissionFinalRepository<T> : IGenericRepository<T> where T : class
    {
        void Update(T entity);
    }
}