using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject playBtn;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(playBtn);
    }

    public void onClickPlay()
    {
        GetComponent<Animator>().SetTrigger("BeginTransition");
    }
    public void ChangeScene()
    {
        GameManager.Instance.ChangeToLevel(0);
    }
}
