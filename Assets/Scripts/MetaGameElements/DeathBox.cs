using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    private MetaGameManager metaGameManager;

    // Start is called before the first frame update
    void Start()
    {

        metaGameManager = GameObject.Find("GameManager").GetComponent<MetaGameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //THEN HES DEAAD
            metaGameManager.ResetMetaPlayerPosition();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
