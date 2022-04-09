using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class GameObjectHelper
    {
        public static T Instantiate<T>(Component parent = null) where T : Component
        {
            var g = new GameObject();
            var c = g.AddComponent<T>();

            if (parent != null)
            {
                g.transform.SetParent(parent.transform, false);
                g.transform.localPosition = Vector3.zero;
            }

            return c;
        }
    }
}
