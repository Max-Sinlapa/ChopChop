using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healbar : MonoBehaviour
{
    public Health playerhealth;
    public Image fillimagge;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth == null)
            return;

        float fillValue = playerhealth.currentHealth;
        slider.value = fillValue;
    }
}
