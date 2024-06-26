﻿using BomNegocio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IEvaluetionRepository : IWriteRepository<EvaluetionEntity>, IReadRepository<EvaluetionEntity>
    {

    }
}