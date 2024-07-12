using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    // The name or index of the scene to load asynchronously
    public string sceneToLoad;

    // The name or index of the next scene to load after the delay
    public string nextScene;

    void Start()
    {
        // Start the coroutine to load the scene
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        //ButtonObject.onClick.Invoke();
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Wait for 5 seconds after the scene has loaded
        yield return new WaitForSeconds(5);

        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
