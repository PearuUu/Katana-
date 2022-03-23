using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
    int width, height;
    float aspectRatio;
    
    // Start is called before the first frame update
    void Start()
    {
        /*width = Screen.width;
        height = Screen.height;

        Debug.Log("width: " + width);
        Debug.Log("height: " + height);
        aspectRatio = width / height;*/

        Debug.Log(Camera.main.aspect);
        Debug.Log(Camera.main.farClipPlane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
