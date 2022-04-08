using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class GameObjectHelper
    {
        public static T Instantiate<T>() where T : Component
        {
            var g = new GameObject();
            var c = g.AddComponent<T>();
            return c;
        }
    }
}
