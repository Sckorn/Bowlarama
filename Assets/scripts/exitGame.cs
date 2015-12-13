using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {

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

    void OnMouseUp()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
