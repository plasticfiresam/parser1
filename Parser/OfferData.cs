using SQLite;

namespace Parser
{
    /// <summary>
    /// Данные о цене
    /// </summary>
    [Table("Offers")]
    public class OfferData
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string PriceCurrency { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public string Price { get; set; }

        public override string ToString() => $"({Price}, {PriceCurrency})";
    }
}
