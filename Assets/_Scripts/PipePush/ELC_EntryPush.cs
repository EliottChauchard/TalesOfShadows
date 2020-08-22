using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_EntryPush : MonoBehaviour
{
    [SerializeField]
    private GameObject ExitObject;

    public void ActivatePush()
    {
        ExitObject.GetComponent<ELC_ExitPush>().PipePush();
    }
}
