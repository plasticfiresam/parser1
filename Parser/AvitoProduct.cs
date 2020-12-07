using SQLite;

namespace Parser
{
    /// <summary>
    /// Данные о товаре с площадки Авито
    /// </summary>
    public class AvitoProduct
    {
        /// <summary>
        ///  Наименование товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ценовое предложение с валютой
        /// </summary>
        public string PriceOffer { get; set; }
        /// <summary>
        /// Ссылка на страницу товара
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Число посетителей с динамикой
        /// </summary>
        public string Visitors { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Номер объявления
        /// </summary>
        public string Number { get; set; }

        public Seller Seller { get; set; }

        /// <summary>
        /// Строковое представление информации о товаре
        /// </summary>
        /// <returns>Строка с информацией о товаре</returns>
        public string GetDataString()
        {
            return $"Наим.: {Name}, Номер объявления: {Number}, Посетители: {Visitors}, Сслыка: {Link}, Цена: {PriceOffer}\n, ";
        }
    }
}
