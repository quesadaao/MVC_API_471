using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using ent = Solution.DO.Objects;

namespace Solution.Maps
{
    public class Maps
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ent.Employees, data.Employees>();


                cfg.CreateMap<data.Employees, ent.Employees>();

            });

        }
    }
}
