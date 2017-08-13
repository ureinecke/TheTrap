using UnityEngine;
using System.Collections;

public class ColliderTriggerScript : MonoBehaviour {
    private GameObject CameraRig;
    private GameObject CameraHead;
    private Rigidbody CameraRigRigidbody;
    public bool IsOnFloor;
	// Use this for initialization
	void Start () {
        CameraRig = GameObject.Find("[CameraRig]");
        CameraHead = GameObject.Find("Camera (head)");
        CameraRigRigidbody = CameraRig.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       transform.position = new Vector3(CameraHead.transform.position.x, CameraHead.transform.position.y, CameraHead.transform.position.z);
        if (IsOnFloor == true)
        {
           CameraRig.transform.position = new Vector3(CameraRig.transform.position.x, 0, CameraRig.transform.position.z);
        }
	}
    void OnTriggerStay(Collider other)
    {
        if (other.name == "Floor" && IsOnFloor == false)
        {
            CameraRigRigidbody.useGravity = false;
            CameraRigRigidbody.velocity = new Vector3(0, 0, 0);
            IsOnFloor = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CameraRigRigidbody.useGravity = false;
        CameraRigRigidbody.velocity = new Vector3(0, 0, 0);
        if (other.name == "Floor")
        {
            IsOnFloor = true;
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if (!IsOnFloor)
        {
            CameraRigRigidbody.useGravity = true;
        }

        if (IsOnFloor == true && other.name == "Floor")
        {
            CameraRigRigidbody.useGravity = true;
            IsOnFloor = false;
        }
    }
}
