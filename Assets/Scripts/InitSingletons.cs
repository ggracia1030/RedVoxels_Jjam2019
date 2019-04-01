using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSingletons : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("(singleton) GameManager") == null)
        {
            InputManager.Instance.Init();
            GameManager.Instance.Init();
        }
        Destroy(gameObject);
    }
}
