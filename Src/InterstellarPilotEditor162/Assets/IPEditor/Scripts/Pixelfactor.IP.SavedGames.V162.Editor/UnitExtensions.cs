using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class UnitExtensions
    {
        public static bool IsStation(this Unit unit)
        {
            return unit.Class.ToString().StartsWith("Station");
        }

        public static bool IsShip(this Unit unit)
        {
            return unit.Class.ToString().StartsWith("Ship");
        }

        public static bool IsShipOrStation(this Unit unit)
        {
            return IsStation(unit) || IsShip(unit);
        }
    }
}
