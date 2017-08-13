using UnityEngine;
using System.Collections;

public class OculusMovement : MonoBehaviour {

    private Rigidbody RigidBodyRig;
    private GameObject CameraHead;
    private Brain_Collider BrainCollider;
    private Transform CameraRig;
    // Use this for initialization
    void Start()
    {
        CameraHead = GameObject.Find("CenterEyeAnchor");
        BrainCollider = CameraHead.GetComponent<Brain_Collider>();
        RigidBodyRig = this.GetComponent<Rigidbody>();
        CameraRig = GameObject.Find("OVRCameraRig").transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        //print(collision);
    }

    // Update is called once per frame
    void Update()
    {


        //Get the right device
        //var rightDevice = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            //if (!BrainCollider.HeadIsInsideSomething)
            //{
                CameraRig.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                RigidBodyRig.velocity = new Vector3(0, 0, 0);
            //}
        }


    }
}
