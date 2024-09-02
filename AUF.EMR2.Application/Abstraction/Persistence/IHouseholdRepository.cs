﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Models.Pagination;
using AUF.EMR2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace AUF.EMR2.Application.Abstraction.Persistence
{
    public interface IHouseholdRepository : IGenericRepository<Household>
    {
        Task<IPagedList<Household>> GetHouseholdList(RequestParams requestParams, string query = "");
        Task<Household> GetHousehold(int id);
        Task<Household> GetHouseholdByHouseholdNo(string householdNo);
    }
}