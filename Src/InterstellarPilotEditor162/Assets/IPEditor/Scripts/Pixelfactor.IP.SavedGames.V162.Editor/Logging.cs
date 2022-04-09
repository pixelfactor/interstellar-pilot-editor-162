using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class Logging
    {
        public static void LogAndThrow(string error, UnityEngine.Object context = null)
        {
            Debug.LogError(error, context);
            throw new System.Exception("A critical error occured while exporting and the operation cannot continue.");
        }
    }
}
