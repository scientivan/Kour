using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrosshairIconChanged : MonoBehaviour
{
    public Sprite crosshair_lingkaranDot;
    public Sprite crosshair_lingkaran;
    public Sprite crosshair_kotakDot;
    public Sprite crosshair_kotak;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nomer1()
    {
        gameObject.GetComponent<Image>().sprite = crosshair_lingkaranDot;
    }
    public void Nomer2()
    {
        gameObject.GetComponent<Image>().sprite = crosshair_lingkaran;
    }
    public void Nomer3()
    {
        gameObject.GetComponent<Image>().sprite = crosshair_kotakDot;
    }
    public void Nomer4()
    {
        gameObject.GetComponent<Image>().sprite = crosshair_kotak;
    }
}
