using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Carts
{
    public class CartProductResponse
    {
        public int Quantity { get; set; }
        public ProductForCartResponse ProductForCartResponse { get; set; }
    }
}
