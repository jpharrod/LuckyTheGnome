using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour {

    public int Movement_Modifier = 1;
    public Vector3 Camera_NewTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * Movement_Modifier, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Time.deltaTime * Movement_Modifier * -1, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, Time.deltaTime * Movement_Modifier);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, Time.deltaTime * Movement_Modifier * -1);
        }
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            transform.Translate(0, Time.deltaTime * Movement_Modifier, 0);
        }
        else if (d < 0f && transform.position.y > 6.5)
        {
            transform.Translate(0, Time.deltaTime * Movement_Modifier * -1, 0);
        }
    }
}
