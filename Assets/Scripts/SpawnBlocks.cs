using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class SpawnBlocks : MonoBehaviour {
    public Quaternion blockRotation;
    public Vector3 blockPosition;
    public GameObject blockInstance;
    public float multiplier = 0.333f;
    private GameObject activeBlock;
    [Tooltip("Time interval in seconds for spawning blocks")]
    public float spawnInterval;
    private AudioSource source;
    public string blockRotate = "";
    private int  rotation = 0;
    private Rigidbody rb;
    public AudioClip swoosh_01;
    private float nextActionTime = 0.0f;
    public float period;
    private Queue blockQueue;
    public bool tutorialMode;
    private GameObject tutorialBlock = null;

    // Use this for initialization
    void Start () {
        if (tutorialMode && tutorialBlock != null) return;
        period = spawnInterval;
        blockQueue = new Queue();
	}

    void repositionCanvas(Vector3 p)
    {
        GameObject o = GameObject.Find("Canvas");
        o.transform.position = new Vector3(p.x + 0.0f, p.y + 0.7f, p.z + 0.0f);
        //spawnBlocks = o.GetComponent<SpawnBlocks>();
        Vector3 camPos = Camera.main.transform.position;
        GameObject cam = GameObject.Find("OVRCameraRig");
        if (cam == null)
        {
            cam = GameObject.Find("[CameraRig]");
        }
        camPos = cam.transform.position;
        camPos = UnityEngine.VR.InputTracking.GetLocalPosition(VRNode.LeftEye);
        o.transform.LookAt(
            new Vector3(camPos.x, camPos.y/*transform.position.y*/, camPos.z)
            );
        o.transform.Rotate(new Vector3(0, 1, 0), 180);
    }

    // Spawns a Block in a random location (except the fixed height of 10). Enqueues the block in the block Queue
    void SpawnBlock()
    {
        if (tutorialMode)
        {
            if (tutorialBlock == null)
            {
                // create tutorial block on fixed position, then return
                //Vector3 p = new Vector3(1 * multiplier + 0.166f, -0.2f, 2 * multiplier + 0.166f);
                Vector3 p = new Vector3(0 * multiplier + 0.166f, 4.5f, 0 * multiplier + 0.166f);
                tutorialBlock = Instantiate(blockInstance);
                tutorialBlock.transform.position = p;
                repositionCanvas(p);
            }
            return;
        }
        Vector3 position = new Vector3(Random.Range(-2, 2) * multiplier + 0.166f, 22, Random.Range(-2, 2) * multiplier + 0.166f);
        GameObject instance = Instantiate(blockInstance);
        instance.transform.position = position;
        blockQueue.Enqueue(instance);
    }

    void OnCollisionEnter(Collision col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update () {
        if (tutorialMode)
        {
            if (tutorialBlock != null)
            {
                repositionCanvas(tutorialBlock.transform.position);
                tutorialBlock.transform.rotation = blockRotation;
                tutorialBlock.transform.Rotate(new Vector3(1, 0, 0), 90);
                tutorialBlock.transform.position = new Vector3(blockPosition.x, tutorialBlock.transform.position.y, blockPosition.z);
            }
        }

        // if there are Blocks in the queue, and we have no active Block 
        // (because it was just removed when it dropped to the floor), get the next block in the queue
        if (!blockQueue.Equals(null))
        {
            if (blockQueue.Count > 0)
            {
                if (!activeBlock)
                {
                    activeBlock = blockQueue.Peek() as GameObject;
                    rb = activeBlock.GetComponent<Rigidbody>();
                }
            }
        }

        // find out if the block has reached the floor or an obstacle (i.e. when it stops moving in the y direction)
        if (activeBlock & rb)
        {
            
            if (Mathf.Abs(rb.velocity.y) < 0.1f & rb.transform.position.y < 8)
            {
                if (blockQueue.Count > 0)
                {
                    if (blockQueue.Peek() == activeBlock)
                    {
                        //rb.isKinematic = false;
                        blockQueue.Dequeue();
                        activeBlock = null;  
                    }
                }
            }
        }

        //Get the right device
        //var rightDevice = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        // Let Block fall without drag and remove Block from queue
        if (Input.GetKeyDown("page down"))// || Input.GetKeyDown(KeyCode.JoystickButton0)) // || SteamVR_Controller.Input(rightDevice).GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            rb.drag = 0;
            nextActionTime = Time.time + period;
            //SpawnBlock();
            blockQueue.Dequeue();
            activeBlock = null;
        }

        // Rotate block around x axis
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.JoystickButton2)) 
        {
            Debug.Log("1 pressed");
            if (rb & blockRotate == "")
            {
                blockRotate = "X";
                rotation = 0;
            }
        }

        // Rotate block around y axis
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (rb & blockRotate == "")
            {
                blockRotate = "Y";
                rotation = 0;
            }
        }

        // Rotate block around z axis
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (rb & blockRotate == "")
            {
                blockRotate = "Z";
                rotation = 0;
            }
        }

        // Execute rotations
        if (blockRotate != "")
        {
            rotation = rotation + 1;
            switch (blockRotate)
            {
                case "X":
                    rb.transform.Rotate(1, 0, 0);
                    break;
                case "Y":
                    rb.transform.Rotate(0, 1, 0);
                    break;
                case "Z":
                    rb.transform.Rotate(0, 0, 1);
                    break;
                default:
                    break;
            }
            if (rotation == 90)
            {
                blockRotate = "";
            }
        }

        // Spwan the next block after a certain time has passed (controlled by SpawnInterval)
        if (Time.time > nextActionTime ) {
           nextActionTime = Time.time + period;
           SpawnBlock();
        }

    }
}
