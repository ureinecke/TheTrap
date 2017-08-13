using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(6);
        //iTween.MoveBy(GameObject.Find("Plane"), new Vector3(0, -40, 0), 500);
        //iTween.MoveBy(GameObject.Find("multicave2"), new Vector3(0, -40, 0), 500);
        //iTween.MoveBy(GameObject.Find("Terrain"), new Vector3(0, -40, 0), 500);
        GameObject camMover = GameObject.Find("CameraMover");
        if (camMover != null)
        {
            iTween.MoveBy(camMover, new Vector3(0, +40, 0), 500);
        }
        GameObject cam = GameObject.Find("Main Camera");
        if (cam != null)
        {
            //iTween.MoveBy(cam, new Vector3(0, +40, 0), 500);
        }
        GameObject cam2 = GameObject.Find("CameraRig");
        if (cam2 != null)
        {
            //iTween.MoveBy(cam2, new Vector3(0, +40, 0), 500);
        }
    }

    // Update is called once per frame
    void Update () {
	

	}
}
