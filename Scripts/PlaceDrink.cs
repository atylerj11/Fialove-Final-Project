using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDrink : MonoBehaviour
{
    public float value = 6.00f;
    public float value2 = 3.50f;
    public float value3 = 17.30f;
    public GameObject cup;
    public GameObject cake;
    public GameObject toast;
    private bool on = false;

    //public Vector2 spawn;



    // Start is called before the first frame update

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && cup.tag == "drink" && Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1) && InventoryItem.num > 0)
        {
            if (on == false)
            {
                InventoryItem.num -= 1;
            }
            //Instantiate(cup, new Vector2(4.5, -1.0542))
            cup.SetActive(true);

            //Destroy(cup, 10f);
            
            on = true;
            
        }


        else if (col.gameObject.tag == "Player" && cup.tag == "drink" && Input.GetKey(KeyCode.E) && cup.activeInHierarchy)
        {

           


            if (on == true) {
                KeepScore.score += value;
            }
            cup.SetActive(false);
            on = false;


        }


        else if (col.gameObject.tag == "Player" && toast.tag == "Toast" && Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2) && InventoryItem.num > 0)
        {
            if (on == false)
            {
                InventoryItem.num -= 1;
            }
            //Instantiate(cup, new Vector2(4.5, -1.0542))
            toast.SetActive(true);

            //Destroy(cup, 10f);

            on = true;

        }


        else if (col.gameObject.tag == "Player" && toast.tag == "Toast" && Input.GetKey(KeyCode.E) && toast.activeInHierarchy)
        {




            if (on == true)
            {
                KeepScore.score += value2;
            }
            toast.SetActive(false);
            on = false;


        }

        else if (col.gameObject.tag == "Player" && cake.tag == "Cake" && Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3) && InventoryItem.num > 0)
        {
            if (on == false)
            {
                InventoryItem.num -= 1;
            }
            //Instantiate(cup, new Vector2(4.5, -1.0542))
            cake.SetActive(true);

            //Destroy(cup, 10f);

            on = true;

        }


        else if (col.gameObject.tag == "Player" && cake.tag == "Cake" && Input.GetKey(KeyCode.E) && cake.activeInHierarchy)
        {




            if (on == true)
            {
                KeepScore.score += value3;
            }
            cake.SetActive(false);
            on = false;


        }


    }



    void Start()
    {
        cup.SetActive(false);
        toast.SetActive(false);
        cake.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
