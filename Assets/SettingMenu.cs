using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    private GameObject setting;
    // Start is called before the first frame update
    void Start()
    {
        setting = GameObject.Find("Settings");
        setting.SetActive(false);
    }

    
}
