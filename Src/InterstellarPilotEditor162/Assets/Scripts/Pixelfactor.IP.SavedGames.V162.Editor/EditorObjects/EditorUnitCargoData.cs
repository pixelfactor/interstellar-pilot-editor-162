using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorUnitCargoData : MonoBehaviour
    {
        public CargoClass CargoClass;
        public int Quantity = 1;
        public bool Expires = false;
        public double ExpiryTime = 0d;
    }
}
