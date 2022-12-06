using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CookingMeter : MonoBehaviour
{
    [SerializeField]
    private Image imageMoreHeat;
    [SerializeField]
    private TMP_Text tempature;

    private bool Cooking = false;
    private bool isDirectionUp = true;
    private float amtTempature = 0.0f;
    private float HeatingSpped = 100.0f;

    public GameObject ScreenG;
    public GameObject Current;

    public GameObject food;


    // Update is called once per frame
    void Update()
    {
        if (Cooking) {
            CookingActive();
        }


    }

    void CookingActive() {

        if (isDirectionUp) {
            amtTempature += Time.deltaTime * HeatingSpped;
            if (amtTempature > 100) {
                isDirectionUp = false;
                amtTempature = 100f;
            }
        } else {
            amtTempature -= Time.deltaTime * HeatingSpped;
            if (amtTempature < 0)
            {
                isDirectionUp = true;
                amtTempature = 0.0f;
            }
        }

        imageMoreHeat.fillAmount = (0.74f - 0.28f) * amtTempature / 100.0f + 0.28f;
    
    }

    public void StartHeating() {
        Cooking = true;
        amtTempature = 0.0f;
        isDirectionUp = true;
        tempature.text = "";
    
    }


    public void EndHeating() {

        if (amtTempature >= 57.00f && amtTempature <= 81.00f)
        {
            Instantiate(food, GameObject.FindGameObjectWithTag("cakeSpawner").transform.position, transform.rotation);
            Instantiate(food, GameObject.FindGameObjectWithTag("cakeSpawner").transform.position, transform.rotation);
            Instantiate(food, GameObject.FindGameObjectWithTag("cakeSpawner").transform.position, transform.rotation);
            ScreenG.SetActive(false);
            Current.SetActive(true);

        }
        Cooking = false;
        tempature.text = amtTempature.ToString("F0");



    }
}
