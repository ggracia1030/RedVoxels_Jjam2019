using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    private MetaGameManager metaGameManager;

    // Start is called before the first frame update
    void Start()
    {

        metaGameManager = GameObject.Find("MetaGameManager").GetComponent<MetaGameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MetaPlayer")
        {
            //THEN HES DEAAD
            metaGameManager.ResetMetaPlayerPosition();

        }
        else if(other.tag == "Player")
        {
            other.transform.position = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
