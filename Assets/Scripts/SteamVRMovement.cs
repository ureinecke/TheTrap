using UnityEngine;
using System.Collections;

public class SteamVRMovement : MonoBehaviour {
    private Rigidbody RigidBodyRig;
    private GameObject CameraHead;
    private Brain_Collider BrainCollider;
    // Use this for initialization
    void Start()
    {
        CameraHead = GameObject.Find("Camera (head)");
        BrainCollider = CameraHead.GetComponent<Brain_Collider>();
        RigidBodyRig = this.GetComponent<Rigidbody>();
        //CurrentPosition = CameraHead.GetComponent<Rigidbody>().transform.position;
        //RigidBodyPerson.GetComponent<Rigidbody>().transform.position = CurrentPosition;
        //CameraHead.GetComponent<Rigidbody>().transform.position = CurrentPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        //print(collision);
    }

    // Update is called once per frame
    void Update()
    {

        //CharacterController controller = GetComponent<CharacterController>();

        //Get the right device
        var rightDevice = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        if (Input.GetButton("Jump") || SteamVR_Controller.Input(rightDevice).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
              if (!BrainCollider.HeadIsInsideSomething)
                 {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                RigidBodyRig.velocity = new Vector3(0, 0, 0);
            //CurrentPosition = CameraHead.GetComponent<Rigidbody>().transform.position;
            //RigidBodyPerson.GetComponent<Rigidbody>().transform.position = new Vector3(RigidBodyPerson.GetComponent<Rigidbody>().transform.position.x, CurrentPosition.y, RigidBodyPerson.GetComponent<Rigidbody>().transform.position.z);
            //CameraHead.GetComponent<Rigidbody>().transform.position = new Vector3(RigidBodyPerson.GetComponent<Rigidbody>().transform.position.x, CurrentPosition.y, RigidBodyPerson.GetComponent<Rigidbody>().transform.position.z);
                }
        }


    }

}
