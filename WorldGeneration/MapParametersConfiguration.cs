using UnityEngine;

namespace Project.Game.WorldGeneration
{
    /// <summary>
    /// Scriptable object containing various map generation parameters.
    /// </summary>
    [CreateAssetMenu(menuName = "World Data/Map Data", fileName = "NewMap", order = 0)]
    public class MapParametersConfiguration : ScriptableObject
    {
        /// <summary>
        /// Contains length of side of the map.
        /// </summary>
        [field: SerializeField] public int MapSideLength { get; private set; }
        
        /// <summary>
        /// Contains a value of Perlin Noise noise frequency.
        /// </summary>
        [Header("Perlin Noise Parameters")]
        [Range(0, 0.2f)] 
        [field: SerializeField] public float NoiseFrequency { get; private set; }
        
        /// <summary>
        /// Contains a value of Perlin Noise noise frequency used while generating objects.
        /// </summary>
        [Range(0, 0.2f)] 
        [field: SerializeField] public float NoiseFrequencyForObjects { get; private set; }
        
        /// <summary>
        /// Contains a noise seed value which can be entered manually.
        /// </summary>
        [field: SerializeField] public int NoiseSeed { get; private set; }
        
        /// <summary>
        /// Contains a value defining distance from center of the map.
        /// Used to measure base island radius.
        /// </summary>
        [Range(0.4f, 0.6f)] 
        [field: SerializeField] public float DistanceFromMapCenter { get; private set; }
        
        /// <summary>
        /// Bool defining if the map should be generated randomly,
        /// or if the manually entered seed value should be used.
        /// </summary>
        [field: SerializeField] public bool UseRandomSeed { get; private set; }
        
        /// <summary>
        /// Parameter defining where land tiles should be spawned,
        /// depending on the threshold value.
        /// </summary>
        [field: SerializeField] public float LandThresholdValue { get; private set; }
    }
}