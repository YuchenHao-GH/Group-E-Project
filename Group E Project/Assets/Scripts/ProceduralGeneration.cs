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
    public Tilemap Prefab6;
    public Tilemap Prefab7;
    public BoundsInt ChunkReader;
    public int ChunkLength = 50;
    public int ChunkCount = 0;
    public GameObject player;
    public GameObject DeathZone;
    public GameObject Enemy;
    Vector3Int Playerposition;
    public int count;
    void Start()
    {
        TileBase[] Prefab1Base = Prefab1.GetTilesBlock(Prefab1.cellBounds);
        GroundTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
        GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab1Base);

    }

    // Update is called once per frame
    void Update()
    {
        TileBase[] Prefab1Base = Prefab1.GetTilesBlock(Prefab1.cellBounds);
        TileBase[] Prefab2Base = Prefab2.GetTilesBlock(Prefab2.cellBounds);
        TileBase[] Prefab3Base = Prefab3.GetTilesBlock(Prefab3.cellBounds);
        TileBase[] Prefab4Base = Prefab4.GetTilesBlock(Prefab4.cellBounds);
        TileBase[] Prefab6Base = Prefab6.GetTilesBlock(Prefab6.cellBounds);
        TileBase[] Prefab7Base = Prefab7.GetTilesBlock(Prefab7.cellBounds);

        if (player.transform.position.x >= ChunkLength * ChunkCount)
        {
            count = 0;
            ChunkReader.y = ChunkReader.y + count;
            ChunkCount++;
            ChunkReader.x = ChunkReader.x + 60;
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
           
                        ChunkReader.y = ChunkReader.y - (14 - count);
                   
                    
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
                    case 6:
             GroundTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
             GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 98, ChunkReader.y + 32, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 22, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (10 - count);
                    break;

                case 7:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 18, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 8:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 18, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 105, ChunkReader.y + 28f, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 9:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab1Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 50, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 90, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 10:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 58, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 11:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 48, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 12:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 45, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 57, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 13:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 58, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 98, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 14:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 48, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 98, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 15:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab2Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 45, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 57, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 98, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 16:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 17:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 60, ChunkReader.y + 42, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 18:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab3Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 50, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 65, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 80, ChunkReader.y + 42, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 19:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 53, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 20:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 47, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 63, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 21:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 45, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 63, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 22:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 53, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 83, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 23:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab4Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 55, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 75, ChunkReader.y + 29, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 83, ChunkReader.y + 42, 0), Quaternion.identity);
                    break;
                case 24:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 47, ChunkReader.y + 42, 0), Quaternion.identity);
                    
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 22, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (10 - count);
                    break;
                case 25:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 47, ChunkReader.y + 42, 0), Quaternion.identity);
                    
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 32, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 22, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (10 - count);
                    break;
                case 26:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 47, ChunkReader.y + 42, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 32, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 22, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (10 - count);
                    break;
                case 27:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab6Base);
                   
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 70, ChunkReader.y + 32, 0), Quaternion.identity);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 22, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (10 - count);
                    break;
                case 28:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 18, 0), Quaternion.identity);
                    Instantiate(Enemy, new Vector3(ChunkCount * ChunkLength + 105, ChunkReader.y + 28f, 0), Quaternion.identity);
                   
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;
                case 29:
                    GroundTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    GroundColliderTilemap.SetTilesBlock(ChunkReader, Prefab7Base);
                    Instantiate(DeathZone, new Vector3(ChunkCount * ChunkLength + 72, ChunkReader.y + 18, 0), Quaternion.identity);
                    ChunkReader.y = ChunkReader.y - (14 - count);
                    break;

            }


        }

        Playerposition = new Vector3Int((int)player.transform.position.x, (int)player.transform.position.y, (int)player.transform.position.z);
        TileBase[] Lol = GroundTilemap.GetTilesBlock(GroundTilemap.cellBounds);
        
      

       
        
    }

    public void InitialLevelGeneration()
    {

    }

    public int RandomNumberGenerator()
    {
    int random = (int) Random.Range(1, 30);
    return random;

    }

    public int RandomHeight()
    {
    int random = (int) Random.Range(-2, 0);
    Debug.Log(random);
    return random;

    }

    

}
