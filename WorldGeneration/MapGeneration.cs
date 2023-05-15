using Project.Game.SaveSystem;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Project.Game.WorldGeneration
{
    /// <summary>
    /// Class responsible for generating a different terrain map everytime the game is started.
    /// </summary>
    public class MapGeneration : MonoBehaviour, ISavable<MapSaveData>
    {
        private const int MinOffsetRange = -100000;
        private const int MaxOffsetRange = 100000;
        private const float BoxHeight = 8f;
        private const float OverlapBias = 2f;

        [SerializeField] private MapParametersConfiguration mapParameters;
        [SerializeField] private Tilemap grassTilemap;
        [SerializeField] private Tilemap waterTilemap;
        [SerializeField] private Tile waterTile;
        [SerializeField] private Tile grassTile;
        [SerializeField] private BoxCollider waterTileBoxCollider;
        [SerializeField] private Grid mapGrid;
        
        private int mapSideLength;
        private float noiseFrequency;
        private int noiseSeed;
        private float distanceFromMapCenter;
        private bool useRandomSeed;
        private float landThresholdValue;
        private float noiseValue;
        private float islandRadius;
        private float landOffset;
        private Vector2 offset;

        private void Awake()
        {
            SaveSystemManager.Instance.RegisterToSaveManager(this);
            SaveSystemManager.Instance.OnGameLoaded += LoadGame;
            StartNewGame();
        }

        private void OnDestroy()
        {
            if (SaveSystemManager.HasInstance)
            {
                SaveSystemManager.Instance.OnGameLoaded -= LoadGame;
            }
        }

        /// <summary>
        /// Method responsible for loading the map data.
        /// </summary>
        public void LoadData(MapSaveData mapSaveData)
        {
            noiseFrequency = mapSaveData.NoiseFrequency;
            noiseSeed = mapSaveData.NoiseSeed;
            distanceFromMapCenter = mapSaveData.DistanceFromMapCenter;
            landThresholdValue = mapSaveData.LandThresholdValue;
            noiseValue = mapSaveData.NoiseValue;
            islandRadius = mapSaveData.IslandRadius;
            offset.x = mapSaveData.Offset.x;
            offset.y = mapSaveData.Offset.y;
        }

        /// <summary>
        /// Method responsible for saving the required data - map parameters.
        /// </summary>
        public void SaveData(GameData gameData)
        {
            gameData.MapSaveData = new MapSaveData
            {
                NoiseFrequency = noiseFrequency,
                NoiseSeed = noiseSeed,
                DistanceFromMapCenter = distanceFromMapCenter,
                LandThresholdValue = landThresholdValue,
                NoiseValue = noiseValue,
                IslandRadius = islandRadius,
                Offset = offset,
                MapSideLength = mapSideLength
            };
        }
        
        private void StartNewGame()
        {
            GetMapData();

            if (!useRandomSeed)
            {
                Random.InitState(noiseSeed);
            }

            offset = new Vector2(Random.Range(MinOffsetRange, MaxOffsetRange), Random.Range(MinOffsetRange, MaxOffsetRange));
            GenerateTerrain();
        }
        
        private void LoadGame(GameData gameData)
        {
            LoadData(gameData.MapSaveData);
            GetMapData();
            GenerateTerrain();
        }

        private void GetMapData()
        {
            mapSideLength = mapParameters.MapSideLength;
            noiseFrequency = mapParameters.NoiseFrequency;
            noiseSeed = mapParameters.NoiseSeed;
            distanceFromMapCenter = mapParameters.DistanceFromMapCenter;
            useRandomSeed = mapParameters.UseRandomSeed;
            landThresholdValue = mapParameters.LandThresholdValue;
        }

        private void GenerateTerrain()
        {
            islandRadius = mapSideLength / 2 * distanceFromMapCenter;

            for (int x = 0; x < mapSideLength; x++)
            {
                for (int y = 0; y < mapSideLength; y++)
                {
                    noiseValue = Mathf.PerlinNoise(x * noiseFrequency + offset.x, y * noiseFrequency + offset.y);
                    landOffset = Mathf.Pow(x - (mapSideLength / 2), 2) + Mathf.Pow(y - (mapSideLength / 2), 2)
                                 - (islandRadius * islandRadius);
                    if (noiseValue > landThresholdValue && landOffset > 0)
                    {
                        SpawnTile(waterTilemap, x, y, waterTile);
                    }
                    else
                    {
                        SpawnTile(grassTilemap, x, y, grassTile);
                    }
                }
            }
        }

        private void SpawnTile(Tilemap tilemap, int width, int height, Tile tile)
        {
            tilemap.SetTile(new Vector3Int(width, height, 0), tile);
        }
    }
}