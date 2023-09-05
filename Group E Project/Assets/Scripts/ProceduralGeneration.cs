using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    public Tilemap GroundTilemap;
    public Tilemap GroundColliderTilemap;
    public Tilemap RampTilemap;
    public Tilemap RampColliderTilemap;
    public Tilemap Prefab1;
    public Tilemap Prefab2;
    public Tilemap Prefab3;
    public Tilemap Prefab4;
    public BoundsInt ChunkReader;
    public int ChunkLength = 50;
    public int ChunkCount = 0;
    public GameObject player;
    public GameObject DeathZone;
    public GameObject Enemy;

    void Start()
    {
        TileBase[] Prefab1Base = Prefab1.GetTilesBlock(Prefab1.cellBounds);
        GroundTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
        GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
        Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 37, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        TileBase[] Prefab1Base = Prefab1.GetTilesBlock(Prefab1.cellBounds);
        TileBase[] Prefab2Base = Prefab2.GetTilesBlock(Prefab2.cellBounds);
        TileBase[] Prefab3Base = Prefab3.GetTilesBlock(Prefab3.cellBounds);
        TileBase[] Prefab4Base = Prefab4.GetTilesBlock(Prefab4.cellBounds);

        if (player.transform.position.x >= ChunkLength * ChunkCount)
        {
            ChunkReader.y = ChunkReader.y + RandomHeight();
            ChunkCount++;
            ChunkReader.x = ChunkReader.x + 50;
            switch (RandomNumberGenerator())
            {
            case 1:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
             Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
            
             break;
            case 2:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
             Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
             break;
            case 3:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
            
             ChunkReader.y = ChunkReader.y - 15;
             break;
            case 4:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
              Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
             Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
             
   
            
             break;
            case 5:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
             Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 42, 0), Quaternion.identity);
             Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 80, ChunkReader.y + 42, 0), Quaternion.identity);
        
             break;
            }

        }
           
        
    }

    public void InitialLevelGeneration()
    {

    }

    public int RandomNumberGenerator()
    {
    int random = (int) Random.Range(1, 6);
    Debug.Log(random);
    return random;

    }

    public int RandomHeight()
    {
    int random = (int) Random.Range(-3, 3);
    Debug.Log(random);
    return random;

    }



}
