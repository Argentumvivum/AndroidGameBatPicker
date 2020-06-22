using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour {

    public Transform center;
    private Vector3 v;

    private void Start()
    {
        v = (transform.position - center.position);
    }

    private void Update()
    {
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(center.position);
        Vector3 dir = Input.mousePosition - centerScreenPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = center.position + q * v;
        transform.rotation = q;
    }
}
