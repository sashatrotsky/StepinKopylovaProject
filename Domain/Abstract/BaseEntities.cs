using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
   abstract class BaseEntities <T> where T : class
    {
        public int idd { get; set; }
        
        public T nazv { get; set; }

        protected readonly DbContext _context;


    }
}
