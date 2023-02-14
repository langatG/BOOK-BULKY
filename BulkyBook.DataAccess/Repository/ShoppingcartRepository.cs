using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ShoppingcartRepository : Repository<ShoppingCart>, IShoppingcartRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingcartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }
        //public void Update(ShoppingCart obj)
        //{
        //    _db.ShoppingCarts.Update(obj);
        //}
    }
}
