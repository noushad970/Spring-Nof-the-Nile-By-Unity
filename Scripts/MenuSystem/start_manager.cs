using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_manager : MonoBehaviour
{
   // [SerializeField] GameObject gamepanel;
  //  [SerializeField] GameObject settingpanel;
  //  [SerializeField] Toggle MusicToggle;
    // Start is called before the first frame update

    public void gameStart() 
    {
        Initiate.Fade("GamePlay", Color.black, 1.5f);
        Time.timeScale = 1;
       // FindObjectOfType<SoundManager>().ClickSoundClip();
       // AdController.Instance.ShowInterstitialAds();
    }
    public void setting() 
    {
     //   gamepanel.SetActive(false);
     //   settingpanel.SetActive(true);
       // FindObjectOfType<SoundManager>().ClickSoundClip();
    //    settingpanel.GetComponent<Animation>().Play();

    }
    public void Instruction(string InstructionName)
    {
        switch (InstructionName)
        {
            case "Start":
                Initiate.Fade("Select_Level", Color.black, 1.5f);
                Time.timeScale = 1;
                break;
         //   case "OpenSettingPanel":
         //       settingPanel.SetActive(true);
         //       break;
            case "CloseSettingPanel":
                //    gamepanel.SetActive(true);
                // settingpanel.SetActive(false);
                //AdsManager.instance.showInterstitialAd();
                //AdController.Instance.ShowInterstitialAds();
                break;
            case "PrivacyPolicy":
                Debug.Log("PrivacyPolicy");
              // AdController.Instance.PrivacyPolicy();
                break;
            case "RemoveAds":
                Debug.Log("RemoveAds");
               // PlayerPrefs.SetInt("inAppPurchased", 1);
               // PlayerPrefs.Save();
                break;
            case "MoreGames":
                Debug.Log("MoreGames");
              //  AdsManager.instance.showMoreApps();
                break;
            case "RateUs":
            //   AdsManager.instance.showRateUs();
                break;
            case "Music":
           //     SoundManager.instance.isMusicOn = MusicToggle.isOn;
           //     musci_manager.instance.MusicControl(MusicToggle.isOn);
                //  MusicManager.instance.isMusicOn = MusicToggle.isOn;
                break;
        }
    }
}
