using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;
    //public AudioSource audioSource;
    //public AudioClip clip;


    public GameObject npc;
    public GameObject npcAtTable;

    void Start()
    {
        //audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose) {

            if (dialoguePanel.activeInHierarchy)
            {

                zeroText();

            }
            else {

                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {

            contButton.SetActive(true);
        }
    }

    public void zeroText() {

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    
    }

    IEnumerator Typing() {

        foreach (char letter in dialogue[index].ToCharArray()) {

            //audioSource.Play();
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        
        }
    }

    public void NextLine() {

        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {

            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else {

            zeroText();
            npc.SetActive(false);
            npcAtTable.SetActive(true);

        }
    
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {

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
