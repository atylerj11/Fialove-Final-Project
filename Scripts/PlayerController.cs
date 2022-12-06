using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject nextLvlScreen;
    public GameObject currentCanvas;

    private void Start()
    {
    }


    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;

        }

        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = speed * dir;

        if(KeepScore.score >= 25){
            //Debug.Log($"Score above 25");
            nextLvlScreen.SetActive(true);
            currentCanvas.SetActive(false);

        }
    }
}
