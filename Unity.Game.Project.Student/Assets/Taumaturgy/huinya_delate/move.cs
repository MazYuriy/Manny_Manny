using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Slider slider;
    private Taumaturgia_original_1 Taumaturgia_original_linc;
    private Vector3 vector = new Vector3(0, 0, 1);
    private float speed;
    void Start()
    {
        Taumaturgia_original_linc = FindObjectOfType<Taumaturgia_original_1>();
        
    }
   
    public void choiceDirection(int value)
    {
        if (value == 0) { vector = new Vector3(0, 0, 1); }
        if (value == 1) { vector = new Vector3(-1, 0, 0); }
        if (value == 2) { vector = new Vector3(1, 0, 0); }
    }
    void BlockActivation()
    {
       
        speed = slider.value;

        Debug.Log("pizdui na hui " +vector + slider.value );
        foreach (GameObject obj in Taumaturgia_original_linc.amunition_Magic)
        {
            obj.transform.Translate(vector *Time.deltaTime *slider.value*40f ) ;
            Taumaturgia_original_linc.W += 1;
        }
  
        Debug.Log("pizdui na hui " + vector + slider.value ) ;
    }
}
