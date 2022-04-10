using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class DrawString
    {
        public static void Draw(string text, Vector3 worldPos, Color? colour = null, GUIStyle guiStyle = null, Vector3? screenPosOffset = null)
        {
            UnityEditor.Handles.BeginGUI();

            guiStyle = guiStyle ?? GUIStyle.none;
            guiStyle.normal.textColor = colour ?? Color.white;


            var view = UnityEditor.SceneView.currentDrawingSceneView;
            Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);
            Vector2 size = GUI.skin.label.CalcSize(new GUIContent(text));

            screenPos += (screenPosOffset ?? Vector3.zero);

            GUI.Label(new Rect(screenPos.x - (size.x / 2), -screenPos.y + view.position.height + 4, size.x, size.y), text, guiStyle);
            UnityEditor.Handles.EndGUI();
        }
    }
}
