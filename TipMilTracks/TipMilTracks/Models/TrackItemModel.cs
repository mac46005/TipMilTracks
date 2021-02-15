using System;
using System.Collections.Generic;
using System.Text;

namespace TipMilTracks.Models
{
    public class TrackItemModel
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Decimal value of the item type
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Item type : tip / mile
        /// </summary>
        public string Valuetype { get; set; }
    }
}
