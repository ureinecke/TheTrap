using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string scene_back;
    public string scene_forth;
    private float duration = 3.0f;
    private float deltaTime = 0.0f;
    private bool change_back;
    private bool change_forth;
    private bool furtherColorChange = true;
    private bool furtherColorChangeActive;
    public float timer;
    private Scene fort;
    private SpawnBlocks spawnBlocks;

    // Use this for initialization
    void Start()
    {
        //GameObject o = GameObject.Find("BlockSpawner");
        //spawnBlocks = o.GetComponent<SpawnBlocks>();
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        if (timer == null)
            timer = 10f;
        yield return new WaitForSeconds(timer);
        change_forth = true;
        SceneManager.LoadSceneAsync(scene_forth);

    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.JoystickButton1))
        //    change_back = true;
        //if (Input.GetKey(KeyCode.JoystickButton0))
        //    change_forth = true;
        if (change_forth == true || change_back == true)
        {
            Transform[] hinges = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];

            Transform[] allChilds = gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform child in hinges)
            {
                if (child.gameObject.name != "Main Camera" || child.gameObject.name != "CameraMover")
                    child.gameObject.active = false;
            }
            deltaTime += Time.deltaTime;
            if (deltaTime < duration)
            {
                if (furtherColorChangeActive == false)
                {
                    GetComponent<Camera>().backgroundColor = Color.Lerp(Color.black, Color.white, deltaTime);
                }
                else
                {
                    GetComponent<Camera>().backgroundColor = Color.Lerp(Color.white, Color.black, deltaTime);
                }
            }
            else
            {
                if (furtherColorChange == true)
                {
                    furtherColorChangeActive = true;
                    deltaTime = 0.0f;
                    furtherColorChange = false;
                }
                else
                {
                    if (change_forth)
                    {
                        if (scene_forth != "" /* && !spawnBlocks.tutorialMode*/)
                            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_forth)); 
                    }
                    else
                    {
                        if (scene_back != "")
                            SceneManager.LoadScene(scene_back);
                    }
                }
            }
        }
    }
}
