using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetector : TouchDetector {

    protected override void Update()
    {
		base.Update ();

        // If there are two touches on the device...
		if (Input.touchCount == 2)
        {
			TouchIdentifier touchZero = GetTouchIdentifierWithTouch(Input.GetTouch(0));
			TouchIdentifier touchOne = GetTouchIdentifierWithTouch(Input.GetTouch(1));
            // Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.transform.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.transform.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.transform.position - touchOne.transform.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            PinchUpdate(deltaMagnitudeDiff);
        }
    }

    protected virtual void PinchUpdate(float deltaMagnitudeDiff)
    {

    }

}
