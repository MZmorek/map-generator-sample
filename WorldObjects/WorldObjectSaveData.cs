using UnityEngine;

namespace Project.Game.WorldObjects
{
    /// <summary>
    /// Class containing object data which can be saved and loaded in game.
    /// </summary>
    [System.Serializable]
    public class WorldObjectSaveData
    {
        // Variables used in spawning objects on the map - required for game saving.
        public bool IsHarvested;
        public Vector3 WorldObjectPosition;
        public Vector3 WorldObjectRotation;
        public ObjectToSpawnType ObjectToSpawnType;
        
        /// <summary>
        /// Default constructor for ObjectSaveData.
        /// </summary>
        public WorldObjectSaveData()
        {
        }

        /// <summary>
        /// Parameterized constructor for ObjectSaveData.
        /// </summary>
        public WorldObjectSaveData(bool isHarvested, Vector3 worldObjectPosition, Vector3 worldObjectRotation,
            ObjectToSpawnType objectToSpawnType)
        {
            IsHarvested = isHarvested;
            WorldObjectPosition = worldObjectPosition;
            WorldObjectRotation = worldObjectRotation;
            ObjectToSpawnType = objectToSpawnType;
        }
    }
}