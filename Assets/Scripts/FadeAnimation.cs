using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }
}
