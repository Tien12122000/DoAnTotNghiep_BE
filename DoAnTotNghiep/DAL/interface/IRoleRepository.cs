using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IRoleRepository
    {
        DataTable RoleModels();
    }
}
