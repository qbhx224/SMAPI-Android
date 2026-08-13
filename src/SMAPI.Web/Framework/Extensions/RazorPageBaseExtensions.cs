using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace StardewModdingAPI.Web.Framework.Extensions;

/// <summary>Provides extensions for <see cref="RazorPageBase"/>.</summary>
public static class RazorPageBaseExtensions
{
    /// <param name="page">The page to extend.</param>


        /// <summary>Get a serialized JSON representation of the value.</summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The serialized JSON.</returns>
        /// <remarks>This bypasses unnecessary validation (e.g. not allowing null values) in <see cref="IJsonHelper.Serialize"/>.</remarks>
        public static IHtmlContent ForJson(this RazorPageBase page, object? value)
        {
            string json = JsonConvert.SerializeObject(value);
            return new HtmlString(json);
        }

}
