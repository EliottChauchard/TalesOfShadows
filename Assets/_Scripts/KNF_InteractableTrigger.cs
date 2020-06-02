using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KNF_InteractableTrigger : MonoBehaviour
{
    public KNF_Dialogue dialogue;

    public bool isInRange;
    public Animator animator;
    public GameObject interactionIcon;
    public UnityEvent interactAction;
    public UnityEvent interactContinue;
    //public GameObject thingToDistroy;

    List<GameObject> triggers = new List<GameObject>();


    public void TriggerInteract()
    {
        FindObjectOfType<KNF_InteractionManager>().StartInteract(dialogue);
    }
    private void Start()
    {
        interactionIcon.SetActive(false);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("InterractTrigger"))
        {
            if (go.Equals(this.gameObject))
            {
                continue;
                
            }               
            triggers.Add(go);
        }
    }

    private void Update()
    {

        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1) && (KNF_DialogueReset.lastpressed != 1))
            {
                KNF_DialogueReset.lastpressed = 1;
                interactAction.Invoke();
                return;
            }
            else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton1) && (KNF_DialogueReset.lastpressed == 1))
            {
                interactContinue.Invoke();
            }   
        }
        else
        {
            KNF_DialogueReset.lastpressed = 0;            
            animator.SetBool("IsOpen", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            interactionIcon.SetActive(true);
            foreach (GameObject go in triggers)
            {
                go.SetActive(false);
            }        
            //transform.gameObject.tag = "MainTrigger";
            //thingToDistroy.SetActive(false);
            //Debug.Log("Player can interact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactionIcon.SetActive(false);
            foreach (GameObject other in triggers)
            {
                other.SetActive(true);
            }
            //transform.gameObject.tag = "InterractTrigger";
            //thingToDistroy.SetActive(true);
            //Debug.Log("ByeBye");
        }
    }
}

