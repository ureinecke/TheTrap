using UnityEngine;
using System.Collections;

public class Brain_Collider : MonoBehaviour {
    public bool HeadIsInsideSomething;
    public bool BrainCrushed;
    public Shader ClearAllShader;
    public Shader StandardShader;
    public GameObject Cave;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        HeadIsInsideSomething = true;

        if (other.name == "Block(Clone)")
        {
            Cave.GetComponent<Renderer>().material.shader = ClearAllShader;

            if (other.GetComponent<Rigidbody>().velocity.magnitude > 4)
            {
                BrainCrushed = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        HeadIsInsideSomething = false;
        if (other.name == "Block(Clone)")
        {
            Cave.GetComponent<Renderer>().material.shader = StandardShader;
        }
    }
}
