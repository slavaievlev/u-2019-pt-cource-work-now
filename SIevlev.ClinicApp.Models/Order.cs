using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIevlev.ClinicApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime ImplementDate { get; set; }
        
        public int Price { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
        
        public int PatientId { get; set; }
        
        public virtual Patient Patient { get; set; }
        
        [ForeignKey("OrderId")]
        public virtual List<PayStore> PayStores { get; set; }
        
        [ForeignKey("OrderId")]
        public virtual OrderDoctor OrderDoctor { get; set; }
    }
}