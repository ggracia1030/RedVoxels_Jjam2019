using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        ResetCamera();
    }

    void ResetCamera()
    {
        mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShakeCamera(float time)
    {

    }
}
