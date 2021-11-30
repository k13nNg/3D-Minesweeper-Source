using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Select_Tile : MonoBehaviour
{
    private Camera cam;
    private Element target;

    [SerializeField] private Material myMaterial;

    public GameObject winCanvas;
    public GameObject miniMap;
    public Text txt;

    void Start(){
        winCanvas.SetActive(false);
    }

   void Update(){
    cam = GameObject.FindGameObjectWithTag("FP_Camera").GetComponent<Camera>();
    Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if(Physics.Raycast(ray, out RaycastHit hit)){
               target = hit.collider.gameObject.GetComponent<Element>();

               if(target != null){

                    if(GridController.checkWin()){
                        txt.text = "VICTORY!!!!!";
                        PlayerController.releaseMouseLock();
                        switchCanvas();
                    }

                    if(Input.GetMouseButtonDown(0) && !target.checkTexture("flag_texture")){

                        if(target.mine){
                            target.changeTexture(-1);
                            //Game Over
                            txt.text = "GAME OVER";
                            PlayerController.releaseMouseLock();
                            switchCanvas();
                        }

                       

                        else{
                            

                            for(int i = 0; i < GridController.elem.GetLength(0); i++){
                                for(int j = 0; j < GridController.elem.GetLength(1); j++){
                                    if(GridController.checkMines() == 0){
                                        GridController.setMine(i, j);
                                        
                                    }

                                    if(GridController.elem[i,j].x == target.x && GridController.elem[i,j].z == target.z){
                                        GridController.revealCells(i, j);
                                        
                                    }
                                }
                            }
                        }
                    }
                    
                    else if(Input.GetMouseButtonDown(1)){
                        if(target.checkTexture("flag_texture")){
                            target.changeTexture("default");
                        }

                        else if(target.checkTexture("default")){
                            target.changeTexture("flag");
                        }
                    }

                    
               }
        }     
                
               
           
    }
        
   

   public void switchCanvas(){
        miniMap.SetActive(false);
        winCanvas.SetActive(true);
    }

}
