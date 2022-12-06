using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCATTable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject npc;
    public GameObject npcAtTable;

    public static int xcount;

    public GameObject cup;
    public GameObject cake;
    public GameObject toast;

    public GameObject thank;
    public GameObject no;

    // Update is called once per frame
    void Start()
    {

        xcount = Random.Range(1, 4);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose)
        {

            if (dialoguePanel.activeInHierarchy)
            {

                zeroText();

            }
            else
            {

                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {

            contButton.SetActive(true);
        }

        if (cup.activeSelf && xcount == 1) {

            StartCoroutine(ActivationRoutineYes());
            npc.SetActive(true);
            npcAtTable.SetActive(false);

        } else if (cup.activeSelf && xcount != 1) {

            StartCoroutine(ActivationRoutineNo());
            KeepScore.score -= 0.01f;

        } else if (cake.activeSelf && xcount == 3)
        {
            StartCoroutine(ActivationRoutineYes());
            npc.SetActive(true);
            npcAtTable.SetActive(false);
        }
        else if (cake.activeSelf && xcount != 3)
        {
            StartCoroutine(ActivationRoutineNo());
            KeepScore.score -= 0.01f; 

        } else if (toast.activeSelf && xcount == 2)
        {

            StartCoroutine(ActivationRoutineYes());
            npc.SetActive(true);
            npcAtTable.SetActive(false);
        }
        else if (toast.activeSelf && xcount != 2)
        {

            StartCoroutine(ActivationRoutineNo());
            KeepScore.score -= 0.01f;

        }
        else { 
        
        }
    }

    private IEnumerator ActivationRoutineYes()
    {
        //Wait for 14 secs.
        //yield return new WaitForSeconds(14);
        //Turn My game object that is set to false(off) to True(on).
        thank.SetActive(true);
        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(5);
        //Game object will turn off
        thank.SetActive(false);
    }

    private IEnumerator ActivationRoutineNo()
    {
        //Wait for 14 secs.
        //yield return new WaitForSeconds(14);
        //Turn My game object that is set to false(off) to True(on).
        no.SetActive(true);
        //Turn the Game Oject back off after 1 sec.
        yield return new WaitForSeconds(7);
        //Game object will turn off
        no.SetActive(false);
    }


    public void zeroText()
    {

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);

    }

    IEnumerator Typing()
    {

        foreach (char letter in dialogue[index].ToCharArray())
        {

            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
        string order = xcount.ToString();
        dialogueText.text += order;

    }

    //public void NextLine()
    //{

    //    contButton.SetActive(false);

    //    if (index < dialogue.Length)
    //    {

    //        index++;
    //        dialogueText.text = "";
    //        StartCoroutine(Typing());
    //    }
    //    else
    //    {

    //        zeroText();

    //    }

    //}

    public void Yo() {

        thank.SetActive(false);
        xcount = Random.Range(1, 4);


    }

   

        private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            playerIsClose = true;


        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            playerIsClose = false;
            zeroText();


        }

    }


}
