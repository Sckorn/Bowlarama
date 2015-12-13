using UnityEngine;
using System.Collections;

public class PinGroup{
    //private int TotalPins = 10;
    public pin[] pins = new pin[10];
    public GameObject prefab;
    public static int totalPins = 10;

    public PinGroup()
    {
        this.CreatePinGroup();
    }

    private void CreatePinGroup()
    {
        PinGroup.totalPins = 10;
        for (int i = 0; i < 10; i++)
        {
            this.pins[i] = new pin(i);
        }
    }
}
