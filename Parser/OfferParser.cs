using System;
using AngleSharp.Dom;

namespace Parser
{
    /// <summary>
    /// Парсер цены
    /// </summary>
    public class OfferParser
    {
        /// <summary>
        /// Парсит данные о цене из элемента с ценой
        /// </summary>
        /// <param name="element">Элемент с данными о цене товара</param>
        /// <returns>Данные о цене</returns>
        public static OfferData GetOfferData(IElement element)
        {
            OfferData offerData = new OfferData();
            var priceCurrencyEl = element.QuerySelector(AvitoSelector.PriceCurrencySelector);
            offerData.PriceCurrency = priceCurrencyEl != null ? GetAttributeValue(priceCurrencyEl.Attributes, "content") : null;
            var priceEl = element.QuerySelector(AvitoSelector.PriceValueSelector);
            offerData.Price = priceEl != null ? GetAttributeValue(priceEl.Attributes, "content") : null;

            return offerData;
        }

        /// <summary>
        /// Получение значения аттрибута
        /// Так как данные о цене и валюте находятся в схеме, описывающей товар,
        /// собираем их именно из атрибутов тегов, которые размечают карточку товара
        /// </summary>
        /// <param name="attrs">Объект с аттрибутами</param>
        /// <param name="attributeName">Название требуемого атрибута</param>
        /// <returns></returns>
        public static string GetAttributeValue(INamedNodeMap attrs, string attributeName)
        {
           foreach (var attribute in attrs)
            {
                if (attribute.Name==attributeName)
                {
                    return attribute.Value;
                }
            }
            return null;
        }
    }
}
