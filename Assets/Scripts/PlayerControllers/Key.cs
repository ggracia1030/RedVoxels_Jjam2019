using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public enum KeyType { W, A, S, D, Space};
    [SerializeField] KeyType keyType;
    public bool isPressed;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Carriable")
        {
            isPressed = true;
            rend.material.SetColor("_EmissionColor", Color.red);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            isPressed = false;
            rend.material.SetColor("_EmissionColor", Color.black);
        }
    }
}
