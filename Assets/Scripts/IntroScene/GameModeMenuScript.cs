using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenuScript : MonoBehaviour
{
    private GameObject gameModeMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameModeMenu = GameObject.Find("GameModeMenu");
        gameModeMenu.SetActive(false);
    }

    public void Easy(){

        Tile_Spawner.width = 10;
        Tile_Spawner.height = 10;
        Tile_Spawner.playerSpawnX = -5;
        Tile_Spawner.playerSpawnZ = 13;
        Debug.Log("Width: "+Tile_Spawner.width+ " Height: "+Tile_Spawner.height);
        changeScene();

    }

    public void Medium(){
        Tile_Spawner.width = 25;
        Tile_Spawner.height = 25;
        Tile_Spawner.playerSpawnX = -18;
        Tile_Spawner.playerSpawnZ = 45;
        Debug.Log("Width: "+Tile_Spawner.width+ " Height: "+Tile_Spawner.height);
        changeScene();


    }

    public void Hard(){

        Tile_Spawner.width = 50;
        Tile_Spawner.height = 50;
        Tile_Spawner.playerSpawnX = -34;
        Tile_Spawner.playerSpawnZ = 87;
        Debug.Log("Width: "+Tile_Spawner.width+ " Height: "+Tile_Spawner.height);
        changeScene();

    }

    private void changeScene(){
        SceneManager.LoadScene("MainScene");

    }



}
