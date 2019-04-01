using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSingletons : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        InputManager.Instance.Init();
        GameManager.Instance.Init();
    }
}
