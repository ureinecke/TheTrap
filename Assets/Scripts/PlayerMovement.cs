using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
        public float speed = 3.0F;
    public float jumpSpeed = 3.0F;
    public float gravity = 10.0F;
    private Rigidbody RigidBodyPerson;
    private GameObject CameraHead;
    private Vector3 CurrentPosition;

    public float movementMultiplier = 0.333f;
	// Use this for initialization
	void Start () {
        CameraHead = GameObject.Find("Camera (head)");
        RigidBodyPerson = this.GetComponent<Rigidbody>();
        //CurrentPosition = CameraHead.GetComponent<Rigidbody>().transform.position;
        //RigidBodyPerson.GetComponent<Rigidbody>().transform.position = CurrentPosition;
        //CameraHead.GetComponent<Rigidbody>().transform.position = CurrentPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision);
    }

	// Update is called once per frame
	void Update () {

        //If V is pressed, toggle VRSettings.enabled
        if (Input.GetKeyDown(KeyCode.V))
        {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("Changed VRSettings.enabled to:" + VRSettings.enabled);
        }

        //CharacterController controller = GetComponent<CharacterController>();

        //Get the right device
      //  var rightDevice = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

                if (Input.GetButton("Jump")) // || SteamVR_Controller.Input(rightDevice).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                    CurrentPosition = CameraHead.GetComponent<Rigidbody>().transform.position;
                    RigidBodyPerson.GetComponent<Rigidbody>().transform.position = new Vector3(RigidBodyPerson.GetComponent<Rigidbody>().transform.position.x, CurrentPosition.y, RigidBodyPerson.GetComponent<Rigidbody>().transform.position.z);
                    CameraHead.GetComponent<Rigidbody>().transform.position = new Vector3(RigidBodyPerson.GetComponent<Rigidbody>().transform.position.x, CurrentPosition.y, RigidBodyPerson.GetComponent<Rigidbody>().transform.position.z);
                }
        

    }

}
