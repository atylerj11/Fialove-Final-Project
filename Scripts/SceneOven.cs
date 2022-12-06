using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SceneOven : MonoBehaviour
{
    public GameObject txtToDisplay;  //display the UI text
    private bool PlayerInZone;

    public GameObject ScreenG;
    public GameObject Current;



    // Start is called before the first frame update
    void Start()
    {
        PlayerInZone = false; //player not in zone
        txtToDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (PlayerInZone && Input.GetKeyDown(KeyCode.Z))
         {

            //SceneManager.LoadScene("Oven");


            ScreenG.SetActive(true);
            Current.SetActive(false);
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
     }

     private void OnTriggerExit2D(Collider2D other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}
