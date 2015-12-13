using UnityEngine;
using System.Collections;

public class waiting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WaitAndNext()
    {
        StartCoroutine("waiter");
    }

    IEnumerator waiter()
    {
        StartCoroutine("waitIt");
        yield return new WaitForSeconds(10);
        StopCoroutine("waitIt");
    }

    IEnumerator waitIt()
    { 
        yield return new WaitForSeconds(10);
        game g = GameObject.Find("Main Camera").GetComponent<game>();
        g.player.frames[1].NextFrame();
        yield break;       
    }

    public void WaitForText()
    {
        StartCoroutine("TextWait");
    }

    IEnumerator TextWait()
    {
        yield return new WaitForSeconds(10);
        MeshRenderer mr = GameObject.Find("frame_count_show").GetComponent<MeshRenderer>();
        mr.enabled = false;
        game g = GameObject.Find("Main Camera").GetComponent<game>();
        g.player.frames[1].CanThrow = true;
    }
}
