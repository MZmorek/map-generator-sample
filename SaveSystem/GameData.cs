using System.Collections.Generic;
using Project.Game.Buildings;
using Project.Game.ResourceManagement;
using Project.Game.UnitManagement;
using Project.Game.WorldGeneration;
using Project.Game.WorldObjects;

namespace Project.Game.SaveSystem
{
    /// <summary>
    /// Class containing game data which can be saved and loaded in game.
    /// </summary>
    [System.Serializable]
    public class GameData
    {
        /// <summary>
        /// Class used in saving WorldGeneration parameters.
        /// </summary>
        public MapSaveData MapSaveData;

        /// <summary>
        /// Class used in saving Buildings' data.
        /// </summary>
        public List<BuildingSaveData> BuildingSaveData;

        /// <summary>
        /// Class used in saving world objects' data.
        /// </summary>
        public List<WorldObjectSaveData> ObjectSaveData;
        
        /// <summary>
        /// Class used in saving world objects' data.
        /// </summary>
        public List<ResourceSaveData> ResourceSaveData;

        /// <summary>
        /// Class used in saving all units' data.
        /// </summary>
        public List<UnitSaveData> UnitSaveData;

        /// <summary>
        /// The values defined inside the constructor are the default values the game starts with
        /// when there is no data to load.
        /// </summary>
        public GameData()
        {
            BuildingSaveData = new List<BuildingSaveData>();
            MapSaveData = new MapSaveData();
            ObjectSaveData = new List<WorldObjectSaveData>();
            ResourceSaveData = new List<ResourceSaveData>();
            UnitSaveData = new List<UnitSaveData>();
        }
    }
}