using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_SteamFall : MonoBehaviour
{
    ELC_PlayerMoves playerMoves;

    public bool steamFallEnable;
    private bool playerIsFalling;
    private bool playerIsOnGround;
    private float verticalSpeed;

    [SerializeField]
    public float steamFallGravityForce = 0.05f;

    private void Start()
    {
        playerMoves = GetComponent<ELC_PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        //prends les valeurs du script PlayerMoves
        playerIsFalling = playerMoves.playerIsFalling;
        playerIsOnGround = playerMoves.playerIsOnGround;
        verticalSpeed = playerMoves.verticalSpeed;


        if (Input.GetKeyDown(KeyCode.LeftShift) && playerIsFalling == true)
        {
            steamFallEnable = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || playerIsOnGround == true)
        {
            steamFallEnable = false;
        }
        


        //Faire la jauge d'utilisation
    }
}
