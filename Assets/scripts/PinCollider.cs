using UnityEngine;
using System.Collections;

public class PinCollider : MonoBehaviour {
    private int index = -1;
    private string objectName;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        this.index = int.Parse(gameObject.name.Substring(3, 1));
	}
	
	// Update is called once per frame
    void Update()
    {
        if (gameObject.transform.eulerAngles.z > 45.0f || gameObject.transform.eulerAngles.x > 45.0f)
        {
            if (this.index > -1 && this.index < 10)
            {
                game gm = GameObject.Find("Main Camera").GetComponent<game>();
                gm.player.frames[1].pGroup.pins[this.index].itIsDown();
                this.index = -1;
            }
        }
    }
}
