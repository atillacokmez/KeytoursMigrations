using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationForm
{
    public class CarJsonInfo
    {
        public TransferredData TransferredData { get; set; }
        public RedBook RedBook { get; set; }
    }

    public class TransferredData
    {
        public string Id { get; set; }
        public string QuoteId { get; set; }
        public string Sipp { get; set; }
        public string PickupDateTime { get; set; }
        public string DropoffDateTime { get; set; }
        public string LocId { get; set; }
        public string PickUpLocId { get; set; }
        public string DropOffLocId { get; set; }
        public string Name { get; set; }
        public decimal PriceTotal { get; set; }
        public string PickupCity { get; set; }
        public string Operator { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }

    }
    public class RedBook
    {
        public string Country { get; set; }
    }
}
