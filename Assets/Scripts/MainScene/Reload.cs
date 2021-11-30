using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Reload : MonoBehaviour
{
    public GameObject miniMap;

     public void RestartGame()
    {
        miniMap.SetActive(true);
        SceneManager.LoadScene("MainScene");
    }
}
