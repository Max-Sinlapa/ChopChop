using UnityEngine;
using UnityEngine.Serialization;

public class SwipeDetector : TouchDetector {

    public enum Movement {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
		None = -1
    };

    public float DurationSwipe = 0.5f;

    /// <summary>The required angle of the swipe in degrees.
    /// 0 = Up.
    /// 90 = Right.
    /// 180 = Down.
    /// 270 = Left.</summary>
    float RequiredAngle;

    /// <summary>The angle of the arc in degrees that the swipe must be inside.
    /// -1 = No requirement.
    /// 90 = Quarter circle (+- 45 degrees).
    /// 180 = Semicircle (+- 90 degrees).</summary>
    [FormerlySerializedAs("AngleThreshold")]
    public float RequiredArc = 90f;

    public override void OnTouchEnded(Touch touch)
    {
        // If Finded with fingerID
        if (_touchPool.ContainsKey(touch.fingerId))
        {
            SwipedDetect(_touchPool[touch.fingerId], touch);
        }

        base.OnTouchEnded(touch);
    }

    void SwipedDetect(TouchIdentifier touchid, Touch touch)
    {
        float duration = Time.time - touchid.timeCreated;
        Debug.Log("Duration : " + duration);
        
        if (duration < DurationSwipe)
        {
            Vector2 direction = touch.position - touchid.startPosition;
            Debug.Log("Delta : " + direction.normalized.ToString());
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            SwipedDirection(angle,Convert4Direction(angle));
        }
    }

    protected virtual void SwipedDirection(float angle, Movement currentDirection)
    {
        Debug.Log("Angle : " + angle + " : Direction is : " + currentDirection);
    }

    Movement Convert4Direction(float angle)
    {
        float angleDelta = 0.0f;
        
        for(int i = 0; i < 4; i++)
        {
            RequiredAngle = 90 * i;
            angleDelta = Mathf.DeltaAngle(angle, RequiredAngle);
            if (angleDelta < RequiredArc * -0.5f || angleDelta >= RequiredArc * 0.5f) { }
            else return (Movement)i;
            
        }
        return Movement.None;
    }
}
