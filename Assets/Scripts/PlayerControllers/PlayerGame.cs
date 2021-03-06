﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    public float speed, jumpForce;
    Quaternion direction;
    Vector3 inputMovement, jumpForceVector;
    bool space, canJump, isCarrying, eKey;
    [SerializeField] LayerMask mask;

    Vector3 cRightUp    =    new Vector3( 0.5f, -0.4f,  0.5f);
    Vector3 cRightDown  =    new Vector3( 0.5f, -0.4f, -0.5f);
    Vector3 cLeftUp     =    new Vector3(-0.5f, -0.4f,  0.5f);
    Vector3 cLeftDown   =    new Vector3(-0.5f, -0.4f, -0.5f);

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        RotatePlayer();
        CheckJump();
    }


    void UpdateInput()
    {
        inputMovement = new Vector3(InputManager.Instance.GetAxis("Horizontal") * Time.deltaTime * speed * 100, 0, InputManager.Instance.GetAxis("Vertical") * Time.deltaTime * speed * 100);
        space = InputManager.Instance.GetButtonDown("Jump");
        eKey = InputManager.Instance.GetButtonDown("Action");
        if(eKey && isCarrying)
        {
            Invoke("ResCarry", 0.2f);
            foreach(Transform child in tf)
            {
                child.transform.parent = null;
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void ResCarry() { isCarrying = false; }

    void PlayerMovement()
    {
        rb.velocity = inputMovement + rb.velocity.y * Vector3.up;
        if (space && canJump) PlayerJump();
    }

    void PlayerJump()
    {
        jumpForceVector = new Vector3(0f, jumpForce * 100, 0f);
        rb.AddForce(jumpForceVector);
        canJump = false;
        space = false;
        
        Debug.Log("jump");
    }

    void RotatePlayer()
    {
        tf.rotation = Quaternion.Euler(0,Vector3.Normalize(inputMovement).y,0);
    }

    void CheckJump()
    {
        bool h0, h1, h2, h3;
        h0 = h1 = h2 = h3 = false;


        RaycastHit hit0;
        if (Physics.Raycast(rb.position + cRightUp, Vector3.down, out hit0, Mathf.Infinity, mask))
        {
            if (h0 = hit0.distance < 0.5f) { }

        }
        RaycastHit hit1;
        if (Physics.Raycast(rb.position + cRightDown, Vector3.down, out hit1, Mathf.Infinity, mask))
        {
            if (h1 = hit1.distance < 0.5f) { }
        }
        RaycastHit hit2;
        if (Physics.Raycast(rb.position + cLeftUp, Vector3.down, out hit2, Mathf.Infinity, mask))
        {
            if (h2 = hit2.distance < 0.5f) { }
        }
        RaycastHit hit3;
        if (Physics.Raycast(rb.position + cLeftDown, Vector3.down, out hit3, Mathf.Infinity, mask))
        {
            if (h3 = hit3.distance < 0.5f) { }
        }

        if (h0 || h1 || h2 || h3) { canJump = true; }
        else canJump = false;
    }



    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Carriable" && eKey && !isCarrying)
        {
            other.gameObject.transform.parent = tf;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            isCarrying = true;
        }
    }
}
