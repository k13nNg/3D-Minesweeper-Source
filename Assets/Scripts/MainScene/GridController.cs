using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static int x;
    public static int z;

	public static Element[,] elem;

	public GridController(int width, int height){
		elem = new Element[width, height];
	}

   public void assignMines(int x, int z, Element tempElem){
	   elem[x,z] = tempElem;
   }

    public static void revealCells(int x, int y){
        if(x < 0 || y < 0 || x > Tile_Spawner.width-1 || y > Tile_Spawner.height-1 || elem[x,y].checkTexture("empty0") || elem[x,y].mine || !elem[x,y].checkTexture("default") || elem[x,y].checkTexture("flag_texture")){
			return;
		}

		if(mineCounter(x, y) != 0){
			elem[x,y].changeTexture(mineCounter(x,y));
		}

		else{
			elem[x,y].changeTexture(0);

			revealCells(x-1, y+1);
			revealCells(x, y+1);
			revealCells(x+1, y+1);
			revealCells(x-1, y);
			revealCells(x+1, y);
			revealCells(x-1, y-1);
			revealCells(x, y-1);
			revealCells(x+1, y-1);


        }
    }

    public static int mineCounter(int x, int y){
		int[,] checkMap = new int[,]{ {x-1, y+1}, {x, y+1}, {x+1, y+1}, 
										{x-1, y}, {x,y}, {x+1, y}, 
										{x-1, y-1}, {x, y-1}, {x+1, y-1}};

		int count = 0;


		for(int i = 0; i < checkMap.GetLength(0); i++){
			if(checkMap[i, 0] >= 0 && checkMap[i,0] <= Tile_Spawner.width-1 && checkMap[i, 1] >= 0 && checkMap[i, 1] <= Tile_Spawner.height-1){
				if(elem[checkMap[i, 0], checkMap[i,1]].mine){
					count++;
				}
			}
		}

		return count;

	}

	public static int checkMines(){
		int mineCount = 0;

		for(int i = 0; i < elem.GetLength(0); i++ ){
			for(int j = 0; j < elem.GetLength(1); j++){
				if(elem[i,j].mine){
					mineCount++;
				}
			}
		}

		return mineCount;
	}

	public static void setMine(int x, int y){

		int mines = 0;

		while(mines != (int)(0.1* (Tile_Spawner.width*Tile_Spawner.height))){
			int position = (int)(Random.Range(0f, (float)(Tile_Spawner.width*Tile_Spawner.height)));

			if(!elem[position/Tile_Spawner.width, position%Tile_Spawner.height].mine || position/Tile_Spawner.width != x || position%Tile_Spawner.height != y){
				elem[position/(Tile_Spawner.width), position%(Tile_Spawner.height)].mine = true;

				mines++;
			}				
			
		}
		
	}

	public static bool checkWin(){
		int count = 0;

		for(int i = 0; i < elem.GetLength(0); i++){
			for(int j = 0; j < elem.GetLength(1); j++){
				if(elem[i, j].checkTexture("default") || elem[i, j].checkTexture("flag_texture")){
					count++;
				}
			}
		}

		return count == checkMines();
	}	
}
