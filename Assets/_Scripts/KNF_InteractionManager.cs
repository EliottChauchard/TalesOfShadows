using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KNF_InteractionManager : MonoBehaviour
{
    public Text dialogueText;
    //public KNF_InteractableTrigger iT;
    
    private Queue<string> sentences;
    [SerializeField]
    private float waittime = 0;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartInteract (KNF_Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndInteraction();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waittime);
        }
    }

    void EndInteraction()
    {
        animator.SetBool("IsOpen", false);
        //iT.lastPressed = 0;
        KNF_DialogueReset.lastpressed = 0;
    }


    // Update is called once per frame
    void Update()
    {
       
        
    }
}
