using SQLite;
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
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// Decimal value of the item type
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Item type : tip / mile
        /// </summary>
        public string Valuetype { get; set; }
        /// <summary>
        /// TimeStamp of action completed
        /// </summary>
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
