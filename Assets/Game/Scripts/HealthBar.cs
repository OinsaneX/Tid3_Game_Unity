using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : StatusBar
{
    public Slider hitSlider;
    private int oldValue;
    public float hitDelay = 1f;
    float nextUpdate;
    bool updating = false;
    // Start is called before the first frame update


    public override void ChangeMAxValue(int maxValue)
    {
        base.ChangeMAxValue(maxValue);
        hitSlider.maxValue = maxValue;
    }

    public override void UpdateInfo(int newValue)
    {
        base.UpdateInfo(newValue);
        if(newValue<oldValue && !updating)
        {
            nextUpdate = Time.time + hitDelay;
            updating = true;
        }
        if(Time.time> nextUpdate)
        {
            if (newValue < oldValue)
                oldValue -= 1;
            else
                oldValue = newValue;
            if (oldValue == newValue)
                updating = false;
                    }
        hitSlider.value = oldValue;
    }

   
}
