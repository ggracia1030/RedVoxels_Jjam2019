﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerMovement()
    {
        InputManager.Instance.GetAxis("vertical");
        InputManager.Instance.GetAxis("horitzontal");
    }
}
