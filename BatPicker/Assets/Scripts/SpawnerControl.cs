using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour {

    public bool isEmpty;
    public LayerMask whatIsMonster;

	void FixedUpdate () {
        isEmpty = !Physics2D.OverlapCircle(transform.position, 0.3f, whatIsMonster);
	}
}
