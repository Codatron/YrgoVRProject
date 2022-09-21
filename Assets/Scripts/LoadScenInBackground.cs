using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenInBackground : MonoBehaviour
{
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
        Debug.Log("Pro :" + asyncOperation.progress);
        while (!asyncOperation.isDone)
        {
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log("Press the space bar to continue");

                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}