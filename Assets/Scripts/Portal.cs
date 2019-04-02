using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{


    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {

            other.transform.position = SpawnPoint.position;

        }

    }

}
