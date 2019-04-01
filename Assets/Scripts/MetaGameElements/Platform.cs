using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private MetaGameManager metaGameManager;

    public enum Platformtype {MOVING , STATIC, DEATH}
    public Platformtype pType;

    public float moveSpeed;

    //movement mechanics
    //BOOLS
    public bool canMove;
    public bool stopInThePoints;
    public bool stopTimeIsRandom;
    [Range(0, 10)] public float maxTimeWaiting;
    public bool loopRoute;

    private int currentPoint;
    public Vector3[] Points;
    private float TimeWaiting;
    private int goingBackNum;




    public bool debugBoolForMatchingNPCPos = false; //DEBUG TOOL TO BE DELETEEEEED

    // Use this for initialization
    void Start()
    {

        metaGameManager = GameObject.Find("MetaGameManager").GetComponent<MetaGameManager>();

        //if there's no moving points it will not be called
        if (Points.Length <= 0)
        {
            canMove = false;
            return;
        }

        if (stopTimeIsRandom)
            TimeWaiting = Random.Range(0, maxTimeWaiting);
        else
            TimeWaiting = maxTimeWaiting;

        goingBackNum = 1;

        //bools
        //if (loopRoute)
        //    patrolRoute = false;

        //we initialize the Init Position, where it will start.
        Points[0] = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {


            if (Vector3.Distance(gameObject.transform.position, Points[currentPoint]) < 0.4f)
            {

                if (stopInThePoints)                                            //if we decided to stop in everypoint
                {
                    TimeWaiting -= Time.deltaTime;

                    if (TimeWaiting <= 0)                                        //when time finished
                    {
                        if (stopTimeIsRandom)                                   //if we decided to do random stop intervals
                            TimeWaiting = Random.Range(0, maxTimeWaiting);
                        else                                                    //if not
                            TimeWaiting = maxTimeWaiting;

                        currentPoint += 1 * goingBackNum;
                    }
                }
                else
                {
                    currentPoint += 1 * goingBackNum;
                }


                if (loopRoute)                                                  //if we decided to loop back to the start
                {
                    if (currentPoint >= Points.Length)
                        currentPoint = 0;
                }
                else                                                            //if it doesnot loop, it will retrack the pathto the start
                {
                    if (currentPoint >= Points.Length)
                    {
                        goingBackNum *= -1;
                        currentPoint = Points.Length - 2;
                    }
                    else if (currentPoint < 0)
                    {

                        goingBackNum *= -1;
                        currentPoint = 1;

                    }
                }
            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Points[currentPoint], moveSpeed * Time.deltaTime);
            }
        }


    }


    private void OnDrawGizmos()
    {

        if (canMove)
        {
            if (debugBoolForMatchingNPCPos)
                Points[0] = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            //Starting Point
            Gizmos.color = Color.green;
            Gizmos.DrawCube(Points[0], new Vector3(0.5f, 0.5f, 0.5f));
            if (0 != Points.Length - 1)
                Debug.DrawLine(Points[0], Points[0 + 1], Color.blue);

            //Inside Points
            Gizmos.color = Color.blue;
            for (int i = 1; i < Points.Length - 1; i++)
            {
                Gizmos.DrawCube(Points[i], new Vector3(0.5f, 0.5f, 0.5f));
                if (i != Points.Length - 1)
                    Debug.DrawLine(Points[i], Points[i + 1], Color.blue);

            }

            //EndPoint
            Gizmos.color = Color.red;
            Gizmos.DrawCube(Points[Points.Length - 1], new Vector3(0.5f, 0.5f, 0.5f));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            switch (pType)
            {
                case Platformtype.MOVING:
                case Platformtype.STATIC:
                default:
                    collision.transform.parent = gameObject.transform;
                    break;
                case Platformtype.DEATH:
                    //THEN HES DEAAD
                    metaGameManager.ResetMetaPlayerPosition();
                    break;
                
            }

            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            switch (pType)
            {
                case Platformtype.MOVING:
                case Platformtype.STATIC:
                default:
                    collision.transform.parent = null;
                    break;
                case Platformtype.DEATH:
                    break;

            }

        }
    }


}
