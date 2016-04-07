﻿using UnityEngine;
using System.Collections;

public class PlayerInputHandler : MonoBehaviour {

    public MovementController playerMove;
    public PlayerLookControl playerLook;

    [Header("Controls")]
    public string moveAxisHorizontal = "Horizontal";
    public string moveAxisVertical = "Vertical";
    public string lookAxisHorizontal = "LookHorizontal";
    public string lookAxisVertical = "LookVertical";
    public string jumpButton = "Jump";

    Transform mainCam;
    Vector3 moveControlDir = Vector3.zero;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("RenderCamera").transform;
    }

    void Update ()
    {
        if(playerMove != null)
        {
            calculateMoveDirBasedOnCamera();
            playerMove.moveDir = moveControlDir;

            if (Input.GetButtonDown(jumpButton))
            {
                playerMove.jump();
            }
        }

        if(playerLook != null)
        {
            playerLook.LookDir = new Vector2(Input.GetAxis(lookAxisVertical), Input.GetAxis(lookAxisHorizontal));
        }
    }

    void calculateMoveDirBasedOnCamera()
    {
        moveControlDir = new Vector3(Input.GetAxisRaw(moveAxisHorizontal), 0.0f, Input.GetAxisRaw(moveAxisVertical));
        //Debug.Log(moveControlDir);
        moveControlDir = mainCam.rotation * moveControlDir;
        moveControlDir.y = 0;
    }
}
