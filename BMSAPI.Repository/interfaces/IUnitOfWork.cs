﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSAPI.Repository.interfaces
{
    public interface IUnitOfWork
    {
        public IBlogRepository blogRepository{ get;}

        Task SaveAsync();
    }
}
