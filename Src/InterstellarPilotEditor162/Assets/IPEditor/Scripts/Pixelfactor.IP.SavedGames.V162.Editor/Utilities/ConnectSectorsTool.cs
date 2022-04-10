using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class ConnectSectorsTool
    {
        const string wormholePrefabPath = "Assets/IPEditor/Prefabs/Wormholes/Wormhole.prefab";

        /// <summary>
        /// TODO: This tool will always create two new wormholes, it won't look for existing ones first.
        /// </summary>
        [MenuItem("IPEditor/Tools/Sectors/Connect selected sectors with wormholes")]
        public static void ConnectSelectedSectorsWithWormholesMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            ConnectSelectedSectorsWithWormholes(editorSavedGame.PreferredWormholeDistance);
        }

        private static void ConnectSelectedSectorsWithWormholes(float wormholeDistance)
        {
            var selectedSectors = GetSelectedSectorsOrThrow().ToList();
            if (selectedSectors.Count != 2)
            {
                Logging.LogAndThrow("Expected to have 2 selected sectors");
            }

            ConnectSectors(selectedSectors, wormholeDistance);
        }

        private static void ConnectSectors(List<EditorSector> selectedSectors, float wormholeDistance)
        {
            var wormhole1 = ConnectSectorTo(selectedSectors[0], selectedSectors[1], wormholeDistance * selectedSectors[0].WormholeDistanceMultiplier);
            var wormhole2 = ConnectSectorTo(selectedSectors[1], selectedSectors[0], wormholeDistance * selectedSectors[1].WormholeDistanceMultiplier);

            wormhole1.TargetWormholeUnit = wormhole2.GetComponent<EditorUnit>();
            wormhole2.TargetWormholeUnit = wormhole1.GetComponent<EditorUnit>();

            AutoNameObjects.AutoNameWormhole(wormhole1);
            AutoNameObjects.AutoNameWormhole(wormhole2);
        }

        private static EditorUnitWormholeData ConnectSectorTo(
            EditorSector editorSector1,
            EditorSector editorSector2,
            float wormholeDistance)
        {
            var wormholePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(wormholePrefabPath);
            var newWormhole = (GameObject)PrefabUtility.InstantiatePrefab(wormholePrefab.gameObject);
            newWormhole.transform.SetParent(editorSector1.transform, false);

            var direction = (editorSector2.transform.position - editorSector1.transform.position).normalized;
            newWormhole.transform.position = editorSector1.transform.position + (direction * wormholeDistance);
            newWormhole.transform.rotation = Quaternion.LookRotation(-direction, Vector3.up);

            var newWormholeData = newWormhole.GetComponent<EditorUnitWormholeData>();
            return newWormholeData;
        }

        public static IEnumerable<EditorSector> GetSelectedSectorsOrThrow()
        {
            foreach (var obj in Selection.objects)
            {
                if (obj is GameObject gameObject)
                {
                    var editorSector = gameObject.GetComponent<EditorSector>();
                    if (editorSector != null)
                    {
                        yield return editorSector;
                    }
                    else
                    {
                        Logging.LogAndThrow("Must select sectors");
                    }
                }
                else
                {
                    Logging.LogAndThrow("Selection is invalid");
                }
            }
        }
    }
}
