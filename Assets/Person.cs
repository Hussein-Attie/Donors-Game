using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Person : MonoBehaviour
{
     SpriteRenderer Skin;
     SpriteRenderer Shirt;
     SpriteRenderer Hair;
    SpriteRenderer Hijab;

    public Color[] skincolors;
    public Color[] shirtcolors;
    public Color[] haircolors;
    public Color[] Hijabcolors;

    private GameObject glasses;
    private GameObject beard;

     public int powernumber;
    private GameObject timepowerup;
    private GameObject exppowerup;
    private GameObject clearalpowerup;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 3);
       

        gameObject.transform.GetChild(random).gameObject.SetActive(true);
        glasses = transform.GetChild(4).gameObject;
        beard = transform.GetChild(5).gameObject;
        timepowerup = transform.GetChild(6).gameObject;
        exppowerup = transform.GetChild(7).gameObject;
        clearalpowerup = transform.GetChild(8).gameObject;
        beard.SetActive(false);
        glasses.SetActive(false);
        timepowerup.SetActive(false);
        exppowerup.SetActive(false);
        clearalpowerup.SetActive(false);
        powernumber = Random.Range(0, 30);
      



        if (random == 1)
        {
        Skin = gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<SpriteRenderer>();
        Shirt = gameObject.transform.GetChild(1).transform.GetChild(1).GetComponent<SpriteRenderer>();
        Hair = gameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<SpriteRenderer>();
            
        }
        else if (random ==0)
        {
            Skin = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>();
            Shirt = gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>();
            Hair = gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<SpriteRenderer>();
            if(Random.Range(0,4)==2)
            {
            beard.SetActive(true);
            }
            else
            {
                beard.SetActive(false);
            }
            

        }
        else if (random == 2)
        {
            Skin = gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<SpriteRenderer>();
            Shirt = gameObject.transform.GetChild(2).transform.GetChild(1).GetComponent<SpriteRenderer>();
            Hair = gameObject.transform.GetChild(2).transform.GetChild(2).GetComponent<SpriteRenderer>();
            Hijab = gameObject.transform.GetChild(2).transform.GetChild(3).GetComponent<SpriteRenderer>();
        }

        Skin.color = skincolors[Random.Range(0, skincolors.Length)];
        Shirt.color = shirtcolors[Random.Range(0, shirtcolors.Length)];
        Hair.color = haircolors[Random.Range(0, haircolors.Length)];
        if (beard != null)
        {
            beard.GetComponent<SpriteRenderer>().color = Hair.color;
        }
        if (Hijab != null)
        {
            Hijab.color = Hijabcolors[Random.Range(0, Hijabcolors.Length)];
        }
        int chance = Random.Range(0, 5);

        if (chance == 0)
        {
            glasses.SetActive(true);
        }

        if (powernumber == 2 || powernumber == 24 )
        {

            exppowerup.SetActive(true);
        }
       
         if(powernumber == 1  || powernumber == 13)
        {

            timepowerup.SetActive(true);
        }
         if(powernumber == 19)
        {
            clearalpowerup.SetActive(true);
        }
     

      
      
           
                
            
    }

    // Update is called once per frame
    void Update()
    {
       
    

        
    }
}
