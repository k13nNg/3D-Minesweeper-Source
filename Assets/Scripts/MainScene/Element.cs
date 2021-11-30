using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public bool mine;
    public float x;
    public float z;

    public Material[] emptyTextures;
    public Material mineTexture;
    public Material flagTexture;
    public Material defaultTexture;

    void Start(){
        // mine = Random.value < 0.15;
        GetComponent<Renderer>().material = defaultTexture;
    }

    public void changeTexture(int adjacent){
        if(mine){
            GetComponent<Renderer>().material = mineTexture;
        }

        else{
            GetComponent<Renderer>().material = emptyTextures[adjacent];
        }
    }

    public void changeTexture(string name){
        if(name.Equals("flag")){
            GetComponent<Renderer>().material = flagTexture;
        }

        else{
            GetComponent<Renderer>().material = defaultTexture;
        }
    }

    public bool checkTexture(string textureName){
        string tempStr = GetComponent<Renderer>().material.name.Replace(" (Instance)", "");
        return tempStr.Equals(textureName);
    }
}