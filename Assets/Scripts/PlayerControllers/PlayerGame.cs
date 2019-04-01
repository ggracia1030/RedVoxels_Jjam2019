using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    Transform tf;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        tf.position = new Vector3(tf.position.x + (InputManager.Instance.GetAxis("Horizontal")* Time.deltaTime * speed), tf.position.y , tf.position.z + (InputManager.Instance.GetAxis("Vertical") * Time.deltaTime * speed));
       


    }
}
