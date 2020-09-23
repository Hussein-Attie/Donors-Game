using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour,IUnityAdsListener
{
    public GameObject GameOverScreen;
    public GameObject donorhandler;
    public GameObject puasebutton;
      private static AdManager admanager;
    private string playstoreId = "3759079";
    SoundManager soundManager;
 //   private  GameObject notreadytxt;
    // Start is called before the first frame update
    private void Awake()
    {

        if (admanager == null)
        {
            admanager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);




    }
    public void  InitiaizeAdvertizement()
    {
        Advertisement.Initialize(playstoreId, true);
    }
    void Start()
    {
        Advertisement.AddListener(this);
        InitiaizeAdvertizement();
        soundManager = GameObject.FindGameObjectWithTag("soundManager").GetComponent<SoundManager>();
        //    notreadytxt = GameObject.FindGameObjectWithTag("failedtxt");
        
      

    }
    public void Update()
    {
        if(GameOverScreen == null)
        {
            GameOverScreen = GameObject.FindGameObjectWithTag("gameoverscreen");
        }
        else
        {
            GameOverScreen = GameOverScreen;
        }

        if (donorhandler == null)
        {
            donorhandler = GameObject.FindGameObjectWithTag("donorhandler");
        }
        else
        {
            donorhandler = donorhandler;
        }

        if (puasebutton == null)
        {
            puasebutton = GameObject.FindGameObjectWithTag("puasebutton");
        }
        else
        {
            puasebutton = puasebutton;
        }
    }
    public void PlayRewardedVideo()
    {
        if (!Advertisement.IsReady("rewardedVideo"))
        {
            return;
        }
        else
        {
            Advertisement.Show("rewardedVideo");

        }
     }
    public void PlayVideoAd()
    {
        if (!Advertisement.IsReady("LevelComplete"))
        {
            return;
        }
        else
        {
            Advertisement.Show("LevelComplete");

        }
    }
    public void OnUnityAdsReady(string placementId)
    {
    //  if(placementId == "LevelComplete")
    //    {
         
    //        Advertisement.Show("LevelComplete");
    //    }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == "rewardedVideo")
        {
            Time.timeScale = 0;
            soundManager.MusicaudioSoutce.mute = true; 
            soundManager.SFXaudioSource.mute = true;
        }
        if (placementId == "LevelComplete")
        {
            Time.timeScale = 0;
            soundManager.MusicaudioSoutce.mute = true;
            soundManager.SFXaudioSource.mute = true;
        }

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult) {

            case ShowResult.Failed:
                // Instantiate(notreadytxt);
                //Destroy(notreadytxt, 3f);
                if (placementId == "rewardedVideo")
                {
                    Time.timeScale = 1;
                    soundManager.MusicaudioSoutce.mute = soundManager.MusicToggleValue;
                    soundManager.SFXaudioSource.mute = soundManager.SFXToggleValue;
                }
                break;
            case ShowResult.Skipped:
                if (placementId == "LevelComplete")
                {
                    Time.timeScale = 1;
                    soundManager.MusicaudioSoutce.mute = soundManager.MusicToggleValue;
                    soundManager.SFXaudioSource.mute = soundManager.SFXToggleValue;
                }
                break;
            case ShowResult.Finished:
                if (placementId == "rewardedVideo")
                {
                    if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        Time.timeScale = 1f;
                        GameOverScreen.SetActive(false);
                        donorhandler.SetActive(true);
                        Timer.timeleft = Timer.maxtime;
                        ExpManager.exp += 1f;
                        PlayerPrefs.SetFloat("Exp", ExpManager.exp);
                        soundManager.MusicaudioSoutce.mute = soundManager.MusicToggle;
                        soundManager.SFXaudioSource.mute = soundManager.SFXToggleValue;
                        puasebutton.SetActive(true);
                    }
                    else
                    {

                        ExpManager.exp += 1f;
                        PlayerPrefs.SetFloat("Exp", ExpManager.exp);
                        soundManager.MusicaudioSoutce.mute = soundManager.MusicToggleValue;
                        soundManager.SFXaudioSource.mute = soundManager.SFXToggleValue;
                    
                    }
                   
                }
                if (placementId == "LevelComplete")
                {
                    Time.timeScale = 1;
                    soundManager.MusicaudioSoutce.mute = soundManager.MusicToggleValue;
                    soundManager.SFXaudioSource.mute = soundManager.SFXToggleValue;
                }
                    break;

        }

        
    }
}

   
