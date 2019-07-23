using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private bool watered = false, musiced = false;
    // Start is called before the first frame update
    void Start()
    {
        watered = false;
        musiced = false;
    }
    public bool GetWatered()
    {
        return watered;
    }
    public bool GetMusiced()
    {
        return musiced;
    }
    public void SetWatered()
    {
        watered = true;
    }
    public void SetMusiced()
    {
        musiced = true;
    }
}
