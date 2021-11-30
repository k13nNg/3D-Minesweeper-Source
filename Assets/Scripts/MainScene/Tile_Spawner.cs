using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawner : MonoBehaviour
{
    public GameObject tileModel;
    public GameObject scenery;
    public GameObject player;

    public static int width;
    public static int height;

    public static int playerSpawnX;
    public static int playerSpawnZ;

    private GameObject tempScene;

    private int counter;
    private int mineSetter;
    private float countx = 0;

    // Start is called before the first frame update
    void Start()
    {
        GridController gC = new GridController(width, height);
	    

        tempScene = Instantiate(scenery, new Vector3((float)(((Tile_Spawner.width-1)*(1.25))/2), 0.95f, (float)(((Tile_Spawner.width-1)*(1.25))/2)), Quaternion.identity);
        tempScene.transform.localScale = new Vector3((float)(Tile_Spawner.width/8*3), (float)(Tile_Spawner.width/8), (float)(Tile_Spawner.height/8*3));
        Instantiate(player,  new Vector3((float)(Tile_Spawner.playerSpawnX), 1.81f, (float)(Tile_Spawner.playerSpawnZ)), Quaternion.identity);

        for(int x = 0; x < Tile_Spawner.width; x++){

            float countz = 0;

            for(int z = 0; z < Tile_Spawner.height; z++){
                Element tempObject = (Instantiate(tileModel, new Vector3(0, 0.95f, 0), Quaternion.identity)).GetComponent<Element>();
                tempObject.x = countx;
                tempObject.z = countz;
                tempObject.transform.position = new Vector3(countx, 0.95f, countz);
                Debug.Log("x: "+x);
                Debug.Log("z: "+z);
                gC.assignMines(x, z, tempObject);
                countz += 1.25f;
            }

            countx += 1.25f;
        }

    }
    
}
