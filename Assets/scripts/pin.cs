using UnityEngine;
using System.Collections;

public class pin
{
    public GameObject pinPref;
    private bool isDown = false;
    private int pinNum;

    public int pinNumber
    {
        get { return pinNum; }
        set { pinNum = value; }
    }

    public bool down
    {
        get { return this.isDown; }
    }

    public pin(int _num)
    {
        this.pinNum = _num;
        this.PlaceIt();
    }

    private void PlaceIt()
    {
        if(this.pinNum > 0)
        {
            PinMorpher pMorph = GameObject.Find("PinMorpher").GetComponent<PinMorpher>();
            GameObject existingPin = GameObject.Find("Pin0");
            float ratio = (float) this.pinNum;
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;
            if (this.pinNum < 4)
            {
                x = existingPin.transform.position.x + ratio * 0.5f + 0.1f;
                y = existingPin.transform.position.y;
                z = existingPin.transform.position.z;
            }
            else
                if (this.pinNum < 7)
                {
                    x = existingPin.transform.position.x + ratio * 0.5f - 1.75f;
                    y = existingPin.transform.position.y;
                    z = existingPin.transform.position.z - 0.5f;
                }
                else
                    if (this.pinNum < 9)
                    {
                        x = existingPin.transform.position.x + ratio * 0.5f - 3.0f;
                        y = existingPin.transform.position.y;
                        z = existingPin.transform.position.z - 0.95f;
                    }
                    else
                    {
                        x = existingPin.transform.position.x + ratio * 0.5f - 3.75f;
                        y = existingPin.transform.position.y;
                        z = existingPin.transform.position.z - 1.35f;
                    }
            
            pMorph.MorphSingle(this.pinNum, new Vector3(x, y, z)); 
        }
        else
        {
            PinMorpher pMorph = GameObject.Find("PinMorpher").GetComponent<PinMorpher>();
            pMorph.MorphSingle(this.pinNum);
        }        
    }

    public void itIsDown()
    {
        this.isDown = true;
        this.KillSelf();
    }

    private void KillSelf()
    {
        if (this.isDown)
        {
            game g = GameObject.Find("Main Camera").GetComponent<game>();
            g.player.frames[1].AddPoint();
            PinGroup.totalPins--;
            UnityEngine.Object.Destroy(GameObject.Find("Pin" + this.pinNum.ToString()), 5.0f);
        }
    }
}
