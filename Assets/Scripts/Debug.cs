using UnityEngine;
using System.Collections;

public class debug : MonoBehaviour {

    private TextMesh debugmesh;

    // Use this for initialization
    void Start()
    {

        debugmesh = GetComponent<TextMesh>();
        debugmesh.text = "";
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
            debugmesh.text = ("Pressed: " + e.keyCode);
        if (e.isMouse)
            debugmesh.text = ("Pressed: " + e.button);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
            debugmesh.text = ("JoystickButton0 was pressed");
    }
}
