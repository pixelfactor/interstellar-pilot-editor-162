using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;
using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    public class PatrolOrder : FleetOrder
    {
        public int PathDirection { get; set; }
        public bool IsLooping { get; set; }
        public List<PatrolPathNode> Nodes { get; set; } = new List<PatrolPathNode>();
        public bool IsLoop { get; set; }
    }
}
