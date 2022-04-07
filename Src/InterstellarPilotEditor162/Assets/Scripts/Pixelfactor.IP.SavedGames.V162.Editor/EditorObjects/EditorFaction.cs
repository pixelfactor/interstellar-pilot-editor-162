using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Factions;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Factions.Bounty;
using Pixelfactor.IP.SavedGames.V162.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorFaction : MonoBehaviour
    {
        public int Id = 0;

        /// <summary>
        /// The id of the name that was generated for this faction. Stops duplicates being generated<br />
        /// Applies when <see cref="HasGeneratedName"/>
        /// </summary>
        public int GeneratedNameId = -1;

        /// <summary>
        /// The id of the name that was generated for this faction. Stops duplicates being generated<br />
        /// Applies when <see cref="HasGeneratedName"/>
        /// </summary>
        public int GeneratedSuffixId = -1;

        /// <summary>
        /// Applies when <see cref="HasCustomName"/>
        /// </summary>
        public string CustomName;

        /// <summary>
        /// Applies when <see cref="HasCustomName"/>
        /// </summary>
        public string CustomShortName;

        /// <summary>
        /// Money
        /// </summary>
        public int Credits;

        public string Description;

        public bool IsCivilian = false;

        /// <summary>
        /// Trader, miner etc
        /// </summary>
        public FactionType FactionType = FactionType.None;

        /// <summary>
        /// 0 - 1
        /// </summary>
        public float Aggression = 0.5f;

        /// <summary>
        /// 0 - 1
        /// </summary>
        public float Virtue = 0.5f;

        /// <summary>
        /// 0 - 1
        /// </summary>
        public float Greed = 0.5f;

        /// <summary>
        /// 0 - 1
        /// </summary>
        public float TradeEfficiency = 0.5f;

        /// <summary>
        /// Determines if can declare was
        /// </summary>
        public bool DynamicRelations = true;

        /// <summary>
        /// Whether to show job board at stations
        /// </summary>
        public bool ShowJobBoards = false;

        /// <summary>
        /// If new jobs are created
        /// </summary>
        public bool CreateJobs = false;

        /// <summary>
        /// The RP is a limit on how many ships/stations the faction can build. Increasing this will increase the factions potential power
        /// </summary>
        public float RequisitionPointMultiplier = 1.0f;

        /// <summary>
        /// Destroy faction when no ships/stations left
        /// </summary>
        public bool DestroyWhenNoUnits = true;

        /// <summary>
        /// 0 - 1<br />
        /// Determines strength of NPCs when pilotting. Not used for much in v1.6.2
        /// </summary>
        public float MinNpcCombatEfficiency = 0.0f;

        /// <summary>
        /// 0 - 1<br />
        /// Determines strength of NPCs when pilotting. Not used for much in v1.6.2
        /// </summary>
        public float MaxNpcCombatEfficiency = 1.0f;

        /// <summary>
        /// Artificial bonus to the potential power of this faction
        /// </summary>
        public int AdditionalRpProvision = 0;

        /// <summary>
        /// Not used for much in 1.6.2
        /// </summary>
        public bool TradeIllegalGoods = false;
    }
}
