using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class TouchIdentifier : MonoBehaviour {
    public int fingerId;
    public float timeCreated;
    public Vector2 startPosition;
	public Vector3 deltaPosition;
}
