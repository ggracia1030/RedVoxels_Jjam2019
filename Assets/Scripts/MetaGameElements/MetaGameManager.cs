using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaGameManager : MonoBehaviour
{


    [SerializeField] GameObject MetaPlayer;

    private Vector3 actualCheckpointPos;

    // Start is called before the first frame update
    void Start()
    {
        if (MetaPlayer == null)
            MetaPlayer = GameObject.Find("MetaPlayer");

        actualCheckpointPos = MetaPlayer.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMetaPlayerPosition()
    {
        MetaPlayer.transform.position = actualCheckpointPos;
    }


    public void ChangeActualCheckPointPos(Vector3 newPos)
    {
        actualCheckpointPos = newPos;
    }
}
