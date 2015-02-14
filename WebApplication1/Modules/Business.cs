using System;
using WebApplication1.Models;

namespace WebApplication1.Modules
{
    public class Business : IBusiness
    {
        public double Rate { get; set; }
        public double DutyRate { get; set; }

        public Business()
        {
            Rate = 0.1;
            DutyRate = 0.05;
        }

        public double CalTax(Product product)
        {
            var rate =  (product.IsExempt ? 0 : Rate) + (product.IsImported ? DutyRate : 0);

            var tax = product.Price * product.Amount*rate;
            if (tax > 0)
            {
                tax = Math.Ceiling(20 * tax) * 0.05;
            }
            
            return tax;

        }
 
    }
}