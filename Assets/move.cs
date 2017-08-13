using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    private Transform[] directChilds;
    private Transform[] allChilds;
    private int index;

    // Use this for initialization
    void Start()
    {
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

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(25);
        int index_out = 0;
        foreach (Transform childs in directChilds)
        {
            index = 0;
            // make only current child visible
            foreach (Transform child in directChilds)
            {
                if (index_out == index)
                {
                    child.gameObject.active = true;
                }
                else
                {
                    child.gameObject.active = false;
                }
                index++;
            }
            iTween.RotateBy(gameObject.GetComponent<Transform>().parent.gameObject, new Vector3(0, 0.3f, 0), 4);
            yield return new WaitForSeconds(6);
            index_out++;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
