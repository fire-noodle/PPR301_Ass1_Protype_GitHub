using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToLoad : MonoBehaviour
{
    public Button yourButton;
    public Button yourButton2;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        Button btn2 = yourButton2.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    { 
        yourButton.interactable = false;
        yourButton2.interactable = false;
    }
}