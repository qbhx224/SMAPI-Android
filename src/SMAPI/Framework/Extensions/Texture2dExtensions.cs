using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;

namespace StardewModdingAPI.Framework.Extensions;

/// <summary>Provides internal extensions for <see cref="Texture2D"/>.</summary>
internal static class Texture2dExtensions
{
    /// <param name="texture">The texture to extend.</param>


        /// <summary>Set the texture name field.</summary>
        /// <param name="assetName">The asset name to set.</param>
        /// <returns>Returns the texture for chaining.</returns>
        [return: NotNullIfNotNull(nameof(texture))]
        public static Texture2D? SetName(this Texture2D? texture, IAssetName assetName)
        {
            if (texture != null)
                texture.Name = assetName.Name;

            return texture;
        }

        /// <summary>Set the texture name field.</summary>
        /// <param name="assetName">The asset name to set.</param>
        /// <returns>Returns the texture for chaining.</returns>
        [return: NotNullIfNotNull(nameof(texture))]
        public static Texture2D? SetName(this Texture2D? texture, string assetName)
        {
            if (texture != null)
                texture.Name = assetName;

            return texture;
        }

}
