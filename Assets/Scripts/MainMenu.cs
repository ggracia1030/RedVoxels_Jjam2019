using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject playBtn;
    GameObject currentSelected;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    private void Update()
    {
        if(currentSelected != EventSystem.current.currentSelectedGameObject)
        {
            if(EventSystem.current.currentSelectedGameObject != null)
            {
                currentSelected = EventSystem.current.currentSelectedGameObject;
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(currentSelected);
            }
        }   
    }

    public void onClickPlay()
    {
        GetComponent<Animator>().SetTrigger("BeginTransition");
    }

    public void onClickExit()
    {
        Application.Quit();
    }
    public void ChangeScene()
    {
        GameManager.Instance.ChangeToLevel(0);
    }
}
