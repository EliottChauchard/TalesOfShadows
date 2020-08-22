using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_ExitPush : MonoBehaviour
{
    [SerializeField]
    private GameObject SteamParticles;
    private ELC_IALittleMonster littleMonsterScript;
    private GameObject GameObjectDetected;
    [SerializeField]
    private float monsterStunDelay;
    [SerializeField]
    private float ejectObjectForce;
    [SerializeField]
    private float ejectMonsterForce;

    //raycast
    [SerializeField]
    private Vector2 startPosition;
    private RaycastHit2D raycast;
    private float raycastLenght = 0.5f;
    [SerializeField]
    private LayerMask collisionMask;



    private void Update()
    {
        startPosition = this.transform.position;
        raycast = Physics2D.Raycast(startPosition, transform.TransformDirection(new Vector2(0, 1f)), raycastLenght, collisionMask);
        Debug.DrawRay(startPosition, transform.TransformDirection(new Vector2(0, raycastLenght)), Color.yellow);
    }

    public void PipePush()
    {
        StartCoroutine("SteamParticlesActivation");
        if(raycast.collider != null)
        {
            GameObjectDetected = raycast.collider.gameObject;

            if(raycast.collider.CompareTag("Monster"))
            {
                littleMonsterScript = raycast.collider.gameObject.GetComponent<ELC_IALittleMonster>();
                StartCoroutine("StunMonster");
            }
            else if(raycast.collider.CompareTag("SensibleObject"))
            {
                GameObjectDetected.GetComponent<Rigidbody2D>().AddForce(-raycast.normal * ejectObjectForce);
            }
        }
    }

    IEnumerator SteamParticlesActivation()
    {
        SteamParticles.SetActive(true);
        yield return new WaitForSeconds(1f);
        SteamParticles.SetActive(false);
    }

    IEnumerator StunMonster()
    {
        littleMonsterScript.isStun = true;
        GameObjectDetected.GetComponent<Rigidbody2D>().AddForce(- raycast.normal * ejectMonsterForce);
        yield return new WaitForSeconds(monsterStunDelay);
        littleMonsterScript.isStun = false;
    }
}
