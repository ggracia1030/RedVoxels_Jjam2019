﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{


    [SerializeField] private float maxGoalTime;

    private float actualGoalTime;


    private void Awake()
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {

        actualGoalTime = maxGoalTime;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            actualGoalTime -= Time.deltaTime;

            if(actualGoalTime <= 0)
            {
                actualGoalTime = maxGoalTime;

                //THEN WE CHANGE THE LEVEL

            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            actualGoalTime = maxGoalTime;
        }
    }
}
