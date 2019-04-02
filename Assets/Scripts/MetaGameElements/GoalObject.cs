using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    private MetaGameManager metaGameManager;
    [SerializeField] private float maxGoalTime;
    private float actualGoalTime;

    // Start is called before the first frame update
    void Start()
    {
        metaGameManager = GameObject.Find("MetaGameManager").GetComponent<MetaGameManager>();
        actualGoalTime = maxGoalTime;

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MetaPlayer")
        {
            actualGoalTime -= Time.deltaTime;

            if(actualGoalTime <= 0)
            {
                actualGoalTime = maxGoalTime;
                //THEN WE CHANGE THE LEVEL with the FADE
                GameManager.Instance.ChangeToNextLevel();

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "MetaPlayer")
        {
            actualGoalTime = maxGoalTime;
        }
    }

}