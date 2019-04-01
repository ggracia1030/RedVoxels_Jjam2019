using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public enum KeyType { W, A, S, D, Space};
    [SerializeField] KeyType keyType;
    [SerializeField] PlayerMetaGame playerToMove;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Action();
        }
    }

    void Action()
    {
        switch(keyType)
        {
            case KeyType.W:
                playerToMove.SetVerticalMovement(1);
                break;
            case KeyType.A:
                playerToMove.SetHorizontalMovement(-1);
                break;
            case KeyType.S:
                playerToMove.SetVerticalMovement(-1);
                break;
            case KeyType.D:
                playerToMove.SetHorizontalMovement(1);
                break;
            case KeyType.Space:
                playerToMove.SetJumpInput(true);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPressed = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPressed = false;
        }
    }
}
