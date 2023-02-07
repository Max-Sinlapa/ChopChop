using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoCamZoomPinchDetector : PinchDetector
{
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

    protected override void PinchUpdate(float deltaMagnitudeDiff)
    {
        base.PinchUpdate(deltaMagnitudeDiff);
		print (deltaMagnitudeDiff);
        // If the camera is orthographic...
		if (_Camera.orthographic)
        {
            // ... change the orthographic size based on the change in distance between the touches.
			_Camera.orthographicSize -= deltaMagnitudeDiff * orthoZoomSpeed;

            // Make sure the orthographic size never drops below zero.
			_Camera.orthographicSize = Mathf.Max(_Camera.orthographicSize, 1f);
        }
        else
        {
            // Otherwise change the field of view based on the change in distance between the touches.
			_Camera.fieldOfView -= deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 0 and 180.
			_Camera.fieldOfView = Mathf.Clamp(_Camera.fieldOfView, 0.1f, 179.9f);
        }
    }
}
