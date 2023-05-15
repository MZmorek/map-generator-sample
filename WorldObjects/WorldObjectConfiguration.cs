using Project.Game.SaveSystem;
using UnityEngine;

namespace Project.Game.WorldObjects
{
    /// <summary>
    /// Scriptable object containing information about various objects spawned on the map.
    /// </summary>
    [CreateAssetMenu(menuName = "World Data/Object Data", fileName = "NewObject", order = 1)]
    public class WorldObjectConfiguration : ScriptableObject
    {
        /// <summary>
        /// Time it takes to harvest this resource or place an extractor.
        /// </summary>
        [field: SerializeField] public float ObjectExtractTime { get; protected set; }

        /// <summary>
        /// Contains game object model.
        /// </summary>
        [field: SerializeField] public GameObject ObjectPrefab { get; private set; }
        
        /// <summary>
        /// Parameter defining where certain objects should be spawned,
        /// depending on the threshold value.
        /// </summary>
        [field: SerializeField] public float ObjectSpawnThresholdValue { get; private set; }
        
        /// <summary>
        /// Contains a value of number of resources generated after
        /// destroying and harvesting the object.
        /// </summary>
        [field: SerializeField] public int NumberOfResourcesGenerated { get; private set; }
        
        /// <summary>
        /// Enum defining object type.
        /// </summary>
        [field: SerializeField] public ObjectToSpawnType ObjectToSpawnType { get; private set; }
        
        /// <summary>
        /// Bool defining if buildings can be built on top of the object.
        /// </summary>
        [field: SerializeField] public bool CanBeBuiltOnto { get; private set; }
        
        /// <summary>
        /// Bool defining if the object can be destroyed to harvest
        /// mass resource from it.
        /// </summary>
        [field: SerializeField] public bool CanBeHarvested { get; private set; }
    }
}