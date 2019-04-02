using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{


    public GameObject Portal;

    public Material redMaterial;
    public Material notActiveMat;
    public Material switchMat;

    private bool onetimer = false;

    private void Start()
    {
        Portal.transform.GetChild(2).gameObject.SetActive(false);
        Portal.transform.GetChild(1).GetComponent<MeshRenderer>().material = notActiveMat;
        gameObject.GetComponent<MeshRenderer>().material = notActiveMat;
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag == "MetaPlayer")
        {
            if (!onetimer)
            {

                Portal.transform.GetChild(2).gameObject.SetActive(true);
                Portal.transform.GetChild(1).GetComponent<MeshRenderer>().material = redMaterial;
                gameObject.GetComponent<MeshRenderer>().material = switchMat;
                onetimer = true;
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MetaPlayer")
        {
            Portal.transform.GetChild(2).gameObject.SetActive(false);
            Portal.transform.GetChild(1).GetComponent<MeshRenderer>().material = notActiveMat;
            gameObject.GetComponent<MeshRenderer>().material = notActiveMat;
            onetimer = false;
        }


    }

}
