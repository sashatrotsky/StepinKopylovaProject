using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
   public abstract class EntitiesBase
    {
        public int Id { get; set; }
        
        public string nazv { get; set; }


    }
}
