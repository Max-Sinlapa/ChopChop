using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMultiTouchDetector : TouchDetector
{
    public override void OnTouchBegan(Touch touch)
    {
        base.OnTouchBegan(touch);
		TouchIdentifier touchId = GetTouchIdentifierWithTouch(touch);
        RandomColor(touchId);
    }

	void RandomColor(TouchIdentifier obj)
    {
        if (obj.GetComponent<SpriteRenderer>() != null)
            SpriteColor(obj);

        if (obj.GetComponent<ParticleSystem>() != null)
            ParticleColor(obj);
    }

	void SpriteColor(TouchIdentifier objTouch)
    {
        SpriteRenderer spr = objTouch.GetComponent<SpriteRenderer>();
        if (spr != null)
        {
            spr.color = RandomColor();
        }
    }

	void ParticleColor(TouchIdentifier objTouch)
    {
        ParticleSystem ps = objTouch.GetComponent<ParticleSystem>();

        if (ps != null)
        {
            ParticleSystem.MainModule mainPS = ps.main;
            mainPS.startColor = RandomColor();
        }
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0, 100) / 100f,
                        Random.Range(0, 100) / 100f,
                        Random.Range(0, 100) / 100f);
    }
}
