using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class SelectionHelper
    {
        public static bool IsSelected(Component component)
        {
            if (component == null)
            {
                return false;
            }

            foreach (var o in Selection.objects)
            {
                if (o == component.gameObject)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
