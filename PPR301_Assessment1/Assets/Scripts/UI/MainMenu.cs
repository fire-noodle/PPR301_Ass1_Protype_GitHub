using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void PlayGame()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		/*
		float timer = 0;
		bool timerReached = false;

		var op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

		op.allowSceneActivation = false;

		if (!timerReached)
			timer += Time.deltaTime;

		if (!timerReached && timer > 5)
		{
			Debug.Log("Done waiting");
			op.allowSceneActivation = true;

			//Set to false so that We don't run this again
			timerReached = true;

				op.allowSceneActivation = false;
		}
*/
	}

	public void QuitGame()
	{
		Application.Quit();

	}
}
