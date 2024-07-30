using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading_to_Game : MonoBehaviour
{
    [SerializeField] Image LoadingBar;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        yield return null;
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game_Play");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        Debug.Log(asyncOperation.progress);

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            LoadingBar.fillAmount = asyncOperation.progress;
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
