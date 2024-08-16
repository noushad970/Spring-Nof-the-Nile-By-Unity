using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForSec());
    }
    IEnumerator waitForSec()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GamePlay");
    }
}
