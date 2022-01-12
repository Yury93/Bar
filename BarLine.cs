using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarLine : MonoBehaviour
{
    [SerializeField] Image bar, supBar;
    public float curValue, maxValue;
    float tempValue;
    public static BarLine instance;
    [SerializeField] float towardSPeed = 10;
    [SerializeField] bool IsInstance = true;
    private void Awake()
    {
     if(IsInstance)   instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempValue = Mathf.MoveTowards(tempValue, curValue, Time.deltaTime * towardSPeed);
        bar.fillAmount = tempValue/maxValue;
        supBar.fillAmount = curValue/maxValue;
    }
    public void Add(float val)
    {
       // tempValue += val;
        curValue += val;
        if (curValue > maxValue) curValue = maxValue;
       
    }
    public bool Take(float val)
    {

        if (curValue >= val) { tempValue = curValue; curValue -= val; }
        else return false;
        

        
        return true;
    }
}
