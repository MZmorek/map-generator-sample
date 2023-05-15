using Project.Game.SaveSystem;
using Project.Game.WorldObjects;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Project.Game.WorldGeneration
{
    /// <summary>
    /// Class responsible for placing objects on the map everytime the game is started.
    /// </summary>
    public class ObjectGeneration : MonoBehaviour
    {
        private const int MinOffsetRange = -100000;
        private const int MaxOffsetRange = 100000;
        private const int NinetyDegreeYRotation = 90;
        private const int NumberOfPossibleRotations = 4;

        [SerializeField] private Tilemap grassTilemap;
        [SerializeField] private MapParametersConfiguration mapParametersConfiguration;
        [SerializeField] private WorldObjectConfiguration[] worldObjectConfigurations;

        private float noiseValue;
        private BoundsInt landSize;
        private int mapSideLength;
        private float noiseFrequencyForObjects;
        private Vector2 offset;

        private void Awake()
        {
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
        
        private void StartNewGame()
        {
            GetMapParameters();
            GenerateObjects();
        }

        private void LoadGame(GameData gameData)
        {
            foreach (var worldObject in gameData.ObjectSaveData)
            {
                for (int i = 0; i < worldObjectConfigurations.Length; i++)
                {
                    if (worldObjectConfigurations[i].ObjectToSpawnType == worldObject.ObjectToSpawnType)
                    {
                        Instantiate(worldObjectConfigurations[i].ObjectPrefab, worldObject.WorldObjectPosition,
                            Quaternion.Euler(worldObject.WorldObjectRotation), grassTilemap.transform.parent);
                    }
                }
            }
        }

        private void GetMapParameters()
        {
            mapSideLength = mapParametersConfiguration.MapSideLength;
            noiseFrequencyForObjects = mapParametersConfiguration.NoiseFrequencyForObjects;
            landSize = new BoundsInt(0, 0, 0, mapSideLength, mapSideLength, 0);
        }

        private void GenerateObjects()
        {
            float distanceToTileCenter = 2.5f;
            Vector3 tileCenter = new Vector3(distanceToTileCenter, 0, distanceToTileCenter);
            offset = new Vector2(Random.Range(MinOffsetRange, MaxOffsetRange),
                Random.Range(MinOffsetRange, MaxOffsetRange));
            
            for (int x = landSize.xMin; x < landSize.xMax; x++)
            {
                for (int y = landSize.yMin; y < landSize.yMax; y++)
                {
                    Vector3Int tileLocation = (new Vector3Int(x, y, 0));
                    Vector3 location = grassTilemap.CellToWorld(tileLocation) + tileCenter;
                    noiseValue = Mathf.PerlinNoise(x * noiseFrequencyForObjects + offset.x,
                        y * noiseFrequencyForObjects + offset.y);
                    for (int i = 0; i < worldObjectConfigurations.Length; i++)
                    {
                        if (grassTilemap.HasTile(tileLocation) && noiseValue < worldObjectConfigurations[i].ObjectSpawnThresholdValue)
                        {
                            SpawnObject(location, worldObjectConfigurations[i].ObjectPrefab, grassTilemap);
                            break;
                        }
                    }
                }
            }
        }

        private void SpawnObject(Vector3 location, GameObject objectPrefab, Tilemap tilemap)
        {
            int randomYRotation = Random.Range(0, NumberOfPossibleRotations) * NinetyDegreeYRotation;
            Instantiate(objectPrefab, location, Quaternion.Euler(new Vector3(0, randomYRotation, 0)), tilemap.transform);
        }
    }
}