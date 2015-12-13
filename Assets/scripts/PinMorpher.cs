using UnityEngine;
using System.Collections;

public class PinMorpher : MonoBehaviour {
    public Rigidbody prefab;
	// Use this for initialization
	void Start () {        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MorphThatBitch()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle = i * Mathf.PI * 2 / 10;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * 5f;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    public void MorphSingle(int _num)
    {
        Instantiate(prefab);
        GameObject obj = GameObject.Find("PinPrefab(Clone)");
        obj.name = "Pin" + _num.ToString();
    }

    public void MorphSingle(int _num, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
        GameObject obj = GameObject.Find("PinPrefab(Clone)");
        obj.name = "Pin" + _num.ToString();
    }
}
