using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class UnitExtensions
    {
        public static bool IsStation(this Unit unit)
        {
            return unit.Class.IsStation();
        }

        public static bool IsShip(this Unit unit)
        {
            return unit.Class.IsShip();
        }

        public static bool IsShipOrStation(this Unit unit)
        {
            return unit.Class.IsShipOrStation();
        }

        public static bool IsWormhole(this Unit unit)
        {
            return unit.Class.IsWormhole();
        }

        public static bool IsCargo(this Unit unit)
        {
            return unit.Class.IsCargo();
        }
    }
}
