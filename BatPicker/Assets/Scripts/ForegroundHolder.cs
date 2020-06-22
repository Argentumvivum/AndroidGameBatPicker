using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundHolder : MonoBehaviour {

    public GameObject[] foregrounds;
    public GameObject foreground;

    public void PickForeground()
    {
        int index = Random.Range(0, foregrounds.Length);
        foreground = foregrounds[index];
    }
}
