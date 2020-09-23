using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("bool") == 1)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("bool") == 0)
        {
            gameObject.GetComponent<Toggle>().isOn = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("bool", 1);
        }
        else
        {
            PlayerPrefs.SetInt("bool", 0);
        }


    }
}
