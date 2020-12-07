using System;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace Parser
{
    /// <summary>
    /// Парсит данные страницы и возвращает объект с ней
    /// </summary>
    public class DocumentParser
    {
        /// <summary>
        /// Метод парсинга страницы
        /// </summary>
        /// <param name="url">Ссылка на страницу</param>
        /// <returns>Объект страницы IDocument</returns>
        public static async Task<IDocument> GetDocument(string url)
        {
            if (url == null || url.Length == 0 || !(Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
            {
                throw new ArgumentException("Формат ссылки для получения страницы некорректен");
            }

            var angleConfig = Configuration.Default.WithDefaultLoader().WithDefaultCookies().WithMetaRefresh();
            var browsingContext = BrowsingContext.New(angleConfig);

            return await browsingContext.OpenAsync(url);
        }
    }
}
