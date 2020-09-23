using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public static float exp;
    public static float expmax=1;
    public static float percentage;

    public static int level;
    private ExpManager expmanager;
    // Start is called before the first frame update
    private void Awake()
    {

        if (expmanager == null)
        {
            expmanager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(exp);
        exp = PlayerPrefs.GetFloat("Exp");
        level = PlayerPrefs.GetInt("Level");
        expmax = level;
        Debug.Log(exp);
        percentage = exp / expmax;

        PlayerPrefs.SetFloat("Exp", exp);
      
        PlayerPrefs.SetInt("Level", level);

        if(level ==1)
        {
            expmax = 1;
        }
        else if (level > 1)
        {
            expmax = level * 0.75f;
        }
      
    }
}
