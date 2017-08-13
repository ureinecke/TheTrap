using UnityEngine;
using System.Collections;

public class BlockInstance : MonoBehaviour {
    public Color color;
    Renderer rend;
    Material mat;
	// Use this for initialization
	void Start () {
        mat = gameObject.GetComponent<Renderer>().material;
        rend = gameObject.GetComponent<Renderer>();
        mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
	}
	
	// Update is called once per frame
	void Update () {
	 mat.SetColor("_EmissionColor", color * Mathf.Clamp(-(gameObject.transform.position.y+4), 0.5f, 10.0f));
        RendererExtensions.UpdateGIMaterials(rend);
        DynamicGI.UpdateEnvironment();
	}
    void OnCollisionEnter(Collision col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

}
