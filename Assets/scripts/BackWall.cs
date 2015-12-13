using UnityEngine;
using System.Collections;

public class BackWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "ball(Clone)")
        {
            UnityEngine.GameObject.Destroy(c.gameObject, 1.0f);
        }
    }
}
