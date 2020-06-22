using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundDestroyer : MonoBehaviour {

    public float location;

    private void Awake()
    {
        float dist = (transform.position.z - Camera.main.transform.position.z);
        float x = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        transform.position = new Vector3(x - location, 0, 0);
    }

}
