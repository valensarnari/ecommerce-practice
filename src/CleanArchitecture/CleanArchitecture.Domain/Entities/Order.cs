using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public State State { get; set; } = State.Pendiente;
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
