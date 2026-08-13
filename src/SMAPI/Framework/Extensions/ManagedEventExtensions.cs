using StardewModdingAPI.Framework.Events;

namespace StardewModdingAPI.Framework.Extensions;

/// <summary>Provides internal extensions for <see cref="ManagedEvent{T}"/>.</summary>
internal static class ManagedEventExtensions
{
    /// <typeparam name="TEventArgs">The event args type to construct.</typeparam>
    /// <param name="event">The event to extend.</param>
    public static void RaiseEmpty<TEventArgs>(this ManagedEvent<TEventArgs> @event)
        where TEventArgs : new()
    {
        if (@event.HasListeners)
            @event.Raise(Singleton<TEventArgs>.Instance);
    }
}
