using System;
namespace Parser
{
    /// <summary>
    /// Селекторы для выборок элементов в HTML
    /// </summary>
    public class AvitoSelector
    {
        /// <summary>
        /// Селектор для выборки элемента карточки товара на главной
        /// </summary>
        public const string ProductCardSelector = @"[itemtype=""http://schema.org/Product""]";
        /// <summary>
        /// Селектор для выбора элемента ссылки на товар из карточки товара
        /// </summary>
        public const string ProductCardLinkSelector = @"[itemprop=""url""]";
        /// <summary>
        /// Селектор для выбора элемента с названием товара
        /// </summary>
        public const string ProductCardTitleSelector = @"[itemprop=""name""]";
        /// <summary>
        /// Селектор для выбора элемента с данными о цене(ценовом предложении) товара
        /// </summary>
        public const string ProductCardOffersSelector = @"[itemtype=""http://schema.org/Offer""]";
        /// <summary>
        /// Селектор для выбора элемента с данными о валюте цены
        /// </summary>
        public const string PriceCurrencySelector = @"meta[itemprop=""priceCurrency""]";
        /// <summary>
        /// Селектор для выбора элемента со значением цены
        /// </summary>
        public const string PriceValueSelector = @"meta[itemprop=""price""]";
        /// <summary>
        /// Селектор для выбора элемента с описанием товара на странице товара
        /// </summary>
        public const string ProductPageDescription = @"div[itemprop=""description""]";
        public const string ProductSellerNameLink = @"div[data-marker=""seller-info/name""]>a";
        /// <summary>
        /// Селектор для выбора элемента с номером объявления на странице товара
        /// </summary>
        public const string ProductPageNumber = @"span[data-marker=""item-view/item-id""]";
        /// <summary>
        /// Селектор для выбора элемента с данными о просмотрах товара
        /// </summary>
        public const string ProductPageVisitors = @"div.title-info-metadata-views";
        public AvitoSelector()
        {}
    }
}
