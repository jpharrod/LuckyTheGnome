using UnityEngine;
using System.Collections;

public class Collision_Script : MonoBehaviour {
    
    void OnTriggerEnter(Collider col){
        Debug.Log("OUCH!");
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
