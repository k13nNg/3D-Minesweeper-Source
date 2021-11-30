using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GameObject>().SetActive(false);
    }

   
}
