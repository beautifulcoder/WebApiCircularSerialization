﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCircularSerialization.Models.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> AllAsync();
    }
}
