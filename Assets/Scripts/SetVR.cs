using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class SetVR : MonoBehaviour {

    private GameObject SteamCameraRig;
    private GameObject SteamVR;
    private GameObject SteamStatus;
    private GameObject Camera;

    // Use this for initialization
    void Start()
    {
            StartCoroutine(MyCoroutine());

    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1);
    if (VRDevice.isPresent)
    {
        Debug.Log("family " + VRDevice.family + " model " + VRDevice.model);
        Camera = GameObject.Find("Camera");
        if (VRDevice.family == "oculus")
        {
            SteamCameraRig = GameObject.Find("[CameraRig]");
            if (SteamCameraRig != null)
                SteamCameraRig.active = false;
            SteamVR = GameObject.Find("[SteamVR]");
            if (SteamVR != null)
                SteamVR.active = false;
            SteamStatus = GameObject.Find("[Status]");
            if (SteamStatus != null)
                SteamStatus.active = false;
            if (Camera != null)
                Camera.active = true;
        }
        else
        {
            Camera.active = false;
        }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
