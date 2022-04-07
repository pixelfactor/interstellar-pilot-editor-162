namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models
{
    public enum FleetOrderCompletionMode
    {
        /// <summary>
        /// Reinitialise and reattempt the objective - not useful for most circumstances
        /// </summary>
        Repeat,

        /// <summary>
        /// Discard the objective
        /// </summary>
        Destroy,

        /// <summary>
        /// Add the objective to the back of the queue
        /// </summary>
        Requeue
    }
}
