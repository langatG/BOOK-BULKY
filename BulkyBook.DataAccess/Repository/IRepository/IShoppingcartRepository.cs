﻿using BulkyBook.Models;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IShoppingcartRepository : IRepository<ShoppingCart>
    {
        //T -> Category
        //void Update(ShoppingCart obj);
    }
}