using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    Image timerbar;
    public static float maxtime=10;
    public static float  timeleft;
    public GameObject GameOverScreen;
    public Color startColor;
    public Color endcolormidel;
    public Color endcolor;

    public GameObject waveobject;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        timerbar = GetComponent<Image>();
        timeleft = maxtime;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (timerbar.fillAmount >= 0.5f)
        {
            timerbar.color = Color.Lerp(endcolormidel, startColor,timerbar.fillAmount);
        }
        else if (timerbar.fillAmount < 0.5f)
        {
            timerbar.color = Color.Lerp(endcolor, endcolormidel, timerbar.fillAmount*2);
        }

        if (timeleft > 0)
        {
            if (!waveobject.activeSelf)
            {
                timeleft -= Time.deltaTime;
                timerbar.fillAmount = timeleft / maxtime;
            }
            else
            {
                return;
            }
        }
        else
        {
            GameOver();
            Time.timeScale = 0;
        }
        
        if(timeleft>= maxtime)
        {
            timeleft = maxtime;
        }
        else if(timeleft <=0)
        {
            timeleft = 0;
        }
    }
    void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
    public IEnumerator StartTimer()
    {
        yield return new WaitForSecondsRealtime(2f);
    }
}












