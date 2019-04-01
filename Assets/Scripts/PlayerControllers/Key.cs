using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public enum KeyType { W, A, S, D, Space};
    [SerializeField] KeyType keyType;
    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            isPressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            isPressed = false;
        }
    }
}
