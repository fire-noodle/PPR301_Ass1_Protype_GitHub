using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample : MonoBehaviour
{
    public Button yourButton;
    public Button yourButton2;
    //public Image yourImage;
    //public Component yourFMODsound;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    { 
        yourButton.interactable = false;
        yourButton2.interactable = false;
        //yourImage.GetComponent<Image>().color = new Color32(255, 255, 225, 0);
    }
}