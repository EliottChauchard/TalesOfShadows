using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlateformFall : MonoBehaviour
{
    [SerializeField]
    private GameObject plateform;
    private BoxCollider2D plateformCollider;
    private SpriteRenderer plateformSpriteRenderer;
    private Animator plateformAnimator;
    private Transform plateformTransform;
    [SerializeField]
    private float timeBeforeFall;

    // Start is called before the first frame update
    void Start()
    {
        plateformCollider = plateform.GetComponent<BoxCollider2D>();
        plateformSpriteRenderer = plateform.GetComponent<SpriteRenderer>();
        plateformAnimator = plateform.GetComponent<Animator>();
        plateformTransform = plateform.GetComponent<Transform>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("PlateformFall");
        }
    }

    IEnumerator PlateformFall()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(timeBeforeFall);
        plateformSpriteRenderer.drawMode = SpriteDrawMode.Simple;
        plateformCollider.autoTiling = false;
        plateformTransform.localScale = new Vector3(1f, 1f, 1f);
        plateformAnimator.SetBool("plateformFall", true);
        FindObjectOfType<ELC_ScreenShake>().ScreenShake(0.7f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        plateformCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        
        plateformSpriteRenderer.enabled = false;
    }
}
