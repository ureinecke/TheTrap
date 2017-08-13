using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInput : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    public GameObject BlockSpawner;
    private SpawnBlocks spawnBlocks;

    void Start()
    {
        spawnBlocks = BlockSpawner.GetComponent<SpawnBlocks>();
    }

    void Update () {

        // Checks for Top Left Touchpad click
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().x < -0.5f)
        {
            spawnBlocks.blockRotate = "X";
       }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().y > 0.5f)
        {
            spawnBlocks.blockRotate = "Y";        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().x > 0.5f)
        {
            spawnBlocks.blockRotate = "Z";
        }

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().y < -0.5f)
        {
            // down
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


}
