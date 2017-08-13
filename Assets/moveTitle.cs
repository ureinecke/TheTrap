using UnityEngine;
using System.Collections;

public class moveTitle : MonoBehaviour {

    private Transform[] directChilds;
    private Transform[] allChilds;
    private int index;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        allChilds = gameObject.GetComponentsInChildren<Transform>();
        directChilds = new Transform[gameObject.transform.childCount];
        index = 0;
        foreach (Transform child in allChilds)
        {
            if (child.parent == gameObject.transform)
            {
                directChilds[index] = child;
                index++;
            }
        }
        index = 0;
        // make only current child visible
        foreach (Transform child in directChilds)
        {

            child.gameObject.active = false;

            index++;
        }
        StartCoroutine(MyCoroutine());


    }

    void playSound()
    {
        //Debug.Log("sound!!");
        audio.Play();
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("start co");
        yield return new WaitForSeconds(1);
        int index_out = 0;
        foreach (Transform child in directChilds)
        {
            child.gameObject.active = true;
            Hashtable ht = new Hashtable();

            ht.Add("amount", new Vector3(0, -40, 0));
            ht.Add("time", 1.3f);
            ht.Add("easetype", iTween.EaseType.linear);
            //ht.Add("speed", 1.3f);
            ht.Add("oncomplete", "playSound");
            ht.Add("oncompletetarget", gameObject); 

            //iTween.MoveBy(child.gameObject, new Vector3(0, -40, 0), 1.3f);
            iTween.MoveBy(child.gameObject, ht);
            yield return new WaitForSeconds(0.8f);
            if (index_out++ == 31)
                yield return new WaitForSeconds(3);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
