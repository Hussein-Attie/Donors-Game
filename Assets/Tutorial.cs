using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject coverpanel;
    private int mousepress=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once pe frame
    void Update()
    {
     
        
        if (PlayerPrefs.GetInt("MousePress") <= 6)
        {
            
           

            if (Input.GetMouseButtonDown(0))
            {
             mousepress++;
             PlayerPrefs.SetInt("MousePress", mousepress);
            }

            if(mousepress == 0)
            {
                panel1.SetActive(true);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                panel5.SetActive(false);
                coverpanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (mousepress == 1)
            {
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel3.SetActive(false);
                panel4.SetActive(false);
                panel5.SetActive(false);
                coverpanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (mousepress == 2)
            {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(true);
                panel4.SetActive(false);
                panel5.SetActive(false);
                coverpanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (mousepress == 3)
            {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(true);
                panel5.SetActive(false);
                coverpanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (mousepress == 4)
            {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                panel5.SetActive(true);
                coverpanel.SetActive(true);
                Time.timeScale = 0;
            }
            if (mousepress == 5)
            {
                panel1.SetActive(false);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                coverpanel.SetActive(false);
                panel5.SetActive(false);
                Time.timeScale = 0;
            }
            if(mousepress == 6)
            {
                Time.timeScale = 1f;
                mousepress++;
            }
        }
   

           
     
    }
   
}
