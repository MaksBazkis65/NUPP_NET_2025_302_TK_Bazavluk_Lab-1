﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Fitness.Common
{
    public interface ICrudService<T>
    {
        void Create(T element);
        T? Read(Guid id); 
        IEnumerable<T> ReadAll();
        void Update(T element);
        void Remove(T element);
    }


}
