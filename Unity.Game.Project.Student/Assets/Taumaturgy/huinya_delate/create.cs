using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    //public GameObject PointCreate;
    private Taumaturgia_original_1 Taumaturgia_original_linc;

    public List<GameObject> FormObject;
    public List<GameObject> ElementEfectObject; 

   // public static List<GameObject> Amunition = new List<GameObject>();

    private int intForm;
    private int intElement;

    void Start()
    {
        Taumaturgia_original_linc= FindObjectOfType<Taumaturgia_original_1>();
    }


    
    // Update is called once per frame
    public void choiseDirection1(int vall)
    {
        intForm = vall;
    }
    public void choiseDirection2(int vall)
    {
        intElement = vall;
    }
    void BlockActivation()
    {
        if (Taumaturgia_original_linc.CreateTrue == true)
        {
            GameObject newFormObject = Instantiate(FormObject[intForm], Taumaturgia_original_linc.PointCreate.transform.position, Taumaturgia_original_linc.PointCreate.transform.rotation);
            GameObject newElementEfectObject = Instantiate(ElementEfectObject[intElement], Taumaturgia_original_linc.PointCreate.transform);
            newElementEfectObject.transform.SetParent(newFormObject.transform, false);

            Taumaturgia_original_linc.amunition_Magic.Add(newFormObject);

            Taumaturgia_original_linc.CreateTrue = false;
            Taumaturgia_original_linc.W += 1;
        }
        else if(Taumaturgia_original_linc.amunition_Magic.Count != 0)
        {
            Taumaturgia_original_linc.W += 1;
        }
    }
   
}
