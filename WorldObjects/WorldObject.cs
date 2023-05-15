using Project.Game.SaveSystem;
using UnityEngine;

namespace Project.Game.WorldObjects
{
    /// <summary>
    /// Class containing basic information about world objects.
    /// </summary>
    public class WorldObject : MonoBehaviour, ISavable<WorldObjectSaveData>
    {
        [SerializeField] private WorldObjectConfiguration worldObjectConfiguration;
        
        /// <summary>
        /// Bool defining whether the object was harvested or not.
        /// </summary>
        [field: SerializeField] public bool IsHarvested { get; private set; }
        
        /// <summary>
        /// Vector3 defining object position on the map.
        /// </summary>
        [field: SerializeField] public Vector3 ObjectPosition { get; private set; }

        /// <summary>
        /// Vector3 defining object position on the map.
        /// </summary>
        [field: SerializeField] public Vector3 ObjectRotation { get; private set; }
        
        /// <summary>
        /// Enum defining object type.
        /// </summary>
        [field: SerializeField] public ObjectToSpawnType ObjectToSpawnType { get; private set; }
        
        private void Awake()
        {
            ObjectToSpawnType = worldObjectConfiguration.ObjectToSpawnType;
            SaveSystemManager.Instance.RegisterToSaveManager(this);
        }
        
        /// <summary>
        /// Method responsible for loading data - object parameters.
        /// </summary>
        public void LoadData(WorldObjectSaveData worldObjectSaveData)
        {
            IsHarvested = worldObjectSaveData.IsHarvested;
            ObjectPosition = worldObjectSaveData.WorldObjectPosition;
            ObjectRotation = worldObjectSaveData.WorldObjectRotation;
            ObjectToSpawnType = worldObjectSaveData.ObjectToSpawnType;
        }

        /// <summary>
        /// Method responsible for saving the required data - object parameters.
        /// </summary>
        public void SaveData(GameData gameData)
        {
           gameData.ObjectSaveData.Add(new WorldObjectSaveData(IsHarvested, transform.position,
               transform.rotation.eulerAngles, ObjectToSpawnType));
        }
    }
}