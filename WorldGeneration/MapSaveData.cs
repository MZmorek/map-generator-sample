using UnityEngine;

namespace Project.Game.WorldGeneration
{
    /// <summary>
    /// Class containing map data which can be saved and loaded in game.
    /// </summary>
    [System.Serializable]
    public class MapSaveData
    {
        // Variables used in generating new map - required for game saving.
        public float NoiseFrequency;
        public int NoiseSeed;
        public float DistanceFromMapCenter;
        public float LandThresholdValue;
        public float NoiseValue;
        public float IslandRadius;
        public Vector2 Offset;
        public int MapSideLength;

        /// <summary>
        /// Default constructor for MapSaveData.
        /// </summary>
        public MapSaveData()
        {
        }

        /// <summary>
        /// Parameterized constructor for MapSaveData.
        /// </summary>
        public MapSaveData(float noiseFrequency, int noiseSeed, float distanceFromMapCenter, 
            float landThresholdValue, float noiseValue, float islandRadius, Vector2 offset, int mapSideLength)
        {
            NoiseFrequency = noiseFrequency;
            NoiseSeed = noiseSeed;
            DistanceFromMapCenter = distanceFromMapCenter;
            LandThresholdValue = landThresholdValue;
            NoiseValue = noiseValue;
            IslandRadius = islandRadius;
            Offset = offset;
            MapSideLength = mapSideLength;
        }
    }
}