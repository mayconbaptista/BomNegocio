﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Pagination
{
    public abstract class QueryStringParameters
    {
        const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = MaxPageSize;
        public int PageSize
        { 
            get
            { 
                return _pageSize; 
            }
            set
            { 
                _pageSize = (value > _pageSize) ? _pageSize : value;
            }
        }

    }
}
