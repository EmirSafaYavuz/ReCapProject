﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using(RentACarContext context = new RentACarContext())
            {
                var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                                  join co in context.Colors
                                  on ca.ColorId equals co.Id
                                  join br in context.Brands
                                  on ca.BrandId equals br.Id
                                  select new CarDetailDto
                                  {
                                      Id = ca.Id,
                                      BrandId = br.Id,
                                      BrandName = br.Name,
                                      Name = ca.Name,
                                      ColorId = co.Id,
                                      ColorName = co.Name,
                                      DailyPrice = ca.DailyPrice,
                                      Description = ca.Description,
                                      ModelYear = ca.ModelYear
                                  };

                return result.ToList();
            }
        }
    }
}
