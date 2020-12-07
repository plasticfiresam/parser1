using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Parser
{
    /// <summary>
    /// Парсер данных о товарах с Авито
    /// </summary>
    public class AvitoParser
    {
        /// <summary>
        /// Собираем информацию о товарах на главной
        /// </summary>
        /// <returns>Коллекция с товарами с главной страницей</returns>
        public async Task<Collection<AvitoProduct>> ParseHomePageProducts()
        {
            Collection<AvitoProduct> avitoProducts = new Collection<AvitoProduct>();

            /// Парсим домашнюю страницу
            var homePageDocument = await DocumentParser.GetDocument(AvitoLinks.HomePage);
            /// Ищем карточки товаров через LINQ запрос
            var productCards = homePageDocument.All.Filter(AvitoSelector.ProductCardSelector).ToCollection<IElement>();


            var productCard = productCards[0];
            /// Сначала парсим инфу о товаре из карточки
            var firstProductInfo = ParseProductDataFromCard(productCard);
            Console.WriteLine($"Получение информации о товаре: {firstProductInfo.Name}");
            /// Затем парсим информацию с его детальной страницы
            Thread.Sleep(2000);
            var resutlProductInfo = ParseProductPage(firstProductInfo);
            /// Ну и добавляем в массив
            Console.Clear();
            avitoProducts.Add(resutlProductInfo.Result);

            ///// Проходим по каждой карточке и заходим на страницу товара
            //foreach (var productCard in productCards)
            //{
            //    /// Сначала парсим инфу о товаре из карточки
            //    var firstProductInfo = ParseProductDataFromCard(productCard);
            //    Console.WriteLine($"Получение информации о товаре: {firstProductInfo.Name}");
            //    /// Затем парсим информацию с его детальной страницы
            //    Thread.Sleep(2000);
            //    var resutlProductInfo = ParseProductPage(firstProductInfo);
            //    /// Ну и добавляем в массив
            //    Console.Clear();
            //    avitoProducts.Add(resutlProductInfo.Result);
            //}

            return avitoProducts;
        }


        /// <summary>
        /// Сбор информации о товаре из карточки товара
        /// </summary>
        /// <param name="productCardElement">Элемент карточки товара</param>
        /// <returns>Данные товара</returns>
        private AvitoProduct ParseProductDataFromCard(IElement productCardElement)
        {
            /// Создаем объект для хранения инфы о товаре
            var product = new AvitoProduct
            {
                /// Парсим название по селекторам
                Name = productCardElement.QuerySelector(AvitoSelector.ProductCardTitleSelector).TextContent,
                /// Аналогично цену с валютой
                PriceOffer = OfferParser.GetOfferData(productCardElement.QuerySelector(AvitoSelector.ProductCardOffersSelector))?.ToString(),
                /// Парсим ссылку на страницу
                Link = productCardElement.QuerySelector<IHtmlAnchorElement>(AvitoSelector.ProductCardLinkSelector).Href
            };

            return product;
        }

        /// <summary>
        /// Сбор информации о товаре со страницы товара
        /// </summary>
        /// <param name="avitoProduct">Данные товара</param>
        /// <returns>Новый объект с дополненными данными товара</returns>
        private async Task<AvitoProduct> ParseProductPage(AvitoProduct avitoProduct)
        {
            var newProduct = new AvitoProduct();

            /// Парсим страницу товара
            var productPage = await DocumentParser.GetDocument(avitoProduct.Link);

            /// Копируем имеющиеся данные в новый объект
            newProduct.Name = avitoProduct.Name;
            newProduct.PriceOffer = avitoProduct.PriceOffer;
            newProduct.Link = avitoProduct.Link;
            /// Добавляем новые со страницы товара
            newProduct.Visitors = productPage.QuerySelector(AvitoSelector.ProductPageVisitors)?.TextContent.Trim();
            newProduct.Number = productPage.QuerySelector(AvitoSelector.ProductPageNumber)?.TextContent;
            newProduct.Description = productPage.QuerySelector(AvitoSelector.ProductPageDescription)?.TextContent;

            var linkBlock = productPage.QuerySelector<IHtmlAnchorElement>(AvitoSelector.ProductSellerNameLink);
            var productSeller = new Seller
            {
                Name = linkBlock.TextContent.Trim(),
                Link = linkBlock.Href
            };

            newProduct.Seller = productSeller;

            return newProduct;

        }
    }
}
