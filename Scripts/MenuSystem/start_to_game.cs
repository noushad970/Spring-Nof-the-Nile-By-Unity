using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_to_game : MonoBehaviour
{
    [SerializeField] Image loadingbar;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        yield return null;
        //AdController.Instance.ShowBannerAds();
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Start");
        //Don't let the Scene activate until you allow it to
        // asyncOperation.allowSceneActivation = false;

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            // Check if the load has finished
           loadingbar.fillAmount = asyncOperation.progress;
            if (asyncOperation.progress >= 0.9f)
            {
                Debug.Log(asyncOperation.progress);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
