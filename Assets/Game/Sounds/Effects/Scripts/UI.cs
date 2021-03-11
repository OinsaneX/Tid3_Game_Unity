using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image HP;
    public Image Food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetHP(float count)
    {
        HP.fillAmount = count;
    }
    public void SetFood(float count)
    {
        Food.fillAmount = count;
    }
}
