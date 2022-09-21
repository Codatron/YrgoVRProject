using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenInBackground : MonoBehaviour
{
    GoToFlying goToFlying;

    private void Start()
    {
        goToFlying = FindObjectOfType<GoToFlying>();
    }
    private void OnEnable()
    {
        StartGame.beginGame += LoadButton;
    }

    private void OnDisable()
    {
        StartGame.beginGame -= LoadButton;
    }

    void LoadButton()
    {
        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MergeScenes");

        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log("Loading done");

                if (goToFlying.hej)
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}