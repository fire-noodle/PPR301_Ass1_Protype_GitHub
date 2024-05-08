using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public FPS_Controller FPSC;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
            if (isPaused)
            {
                ResumeGame();

            }
            else
			{
                PauseGame();
			}
		}
    }

    public void PauseGame()
	{

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        FPSC.canMove = false;
        FPSC.canZoom = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public void ResumeGame()
	{
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        FPSC.canMove = true;
        FPSC.canZoom = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void doExitGame()
    {
        Application.Quit();
    }

}
