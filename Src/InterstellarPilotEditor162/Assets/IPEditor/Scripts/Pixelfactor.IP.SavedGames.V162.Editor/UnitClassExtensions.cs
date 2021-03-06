using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor
{
    public static class UnitClassExtensions
    {
        public static bool IsStation(this UnitClass unitClass)
        {
            return unitClass.ToString().StartsWith("Station");
        }

        public static bool IsShip(this UnitClass unitClass)
        {
            return unitClass.ToString().StartsWith("Ship");
        }

        public static bool IsShipOrStation(this UnitClass unitClass)
        {
            return IsStation(unitClass) || IsShip(unitClass);
        }

        public static bool IsTurret(this UnitClass unitClass)
        {
            return unitClass == UnitClass.Station_LaserIII || unitClass == UnitClass.Station_LaserV;
        }

        public static bool IsWormhole(this UnitClass unitClass)
        {
            return unitClass.ToString().StartsWith("Wormhole");
        }

        public static bool IsCargo(this UnitClass unitClass)
        {
            return unitClass.ToString().StartsWith("Cargo");
        }
    }
}
