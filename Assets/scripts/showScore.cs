using UnityEngine;
using System.Collections;

public class showScore : MonoBehaviour {
    void OnMouseOver()
    {
        guiText.fontStyle = FontStyle.Italic;
        guiText.material.color = Color.black;
    }

    void OnMouseExit()
    {
        guiText.fontStyle = FontStyle.Normal;
        guiText.material.color = Color.white;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        Application.LoadLevel(2);
    }
}
