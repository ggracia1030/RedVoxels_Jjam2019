using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaGameManager : MonoBehaviour
{


    [SerializeField] GameObject MetaPlayer;

    protected Vector3 actualCheckpointPos;

    private bool tryToHideText;
    private float counter;

    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        if (MetaPlayer == null)
            MetaPlayer = GameObject.Find("MetaPlayer");

        actualCheckpointPos = MetaPlayer.transform.position;

        tryToHideText = true;

        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (tryToHideText)
        {
            counter -= 0.001f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, counter);

            if(counter <= 0)
            {
                tryToHideText = false;
            }
        }

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
