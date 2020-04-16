using System.Collections.Generic;
using System.Linq;

namespace Amore.Domain.Data.Model
{
    public class CompleteOrderInfo
    {
        public CompleteOrderInfo(double subTotal, IEnumerable<(string, string, double)> orderItemInfo)
        {
            SubTotal = subTotal;
            OrderItemInfo = orderItemInfo.ToList();
        }

        public double SubTotal { get; }
        public List<(string, string, double)> OrderItemInfo { get; }
    }
}