using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana_consumption : MonoBehaviour
{
    public List<MonoBehaviour> scripts = new List<MonoBehaviour>();
    [Range(0, 3)]
    public int numbersScript;

    //[Range(1, 4)]
    //public int damageElement;

    [Range(1, 60)]
    public int timeElement;
    private float time;
   
    private bool peregriv;
    private bool peretaryad;
    void Start()
    {
        //scripts = new List<MonoBehaviour>();
        time = timeElement;

    }
    void Update()
    {
        //typeElements[numbersTypeElement];



        //print(scripts[numbersScript - 1]);

        if (Input.GetMouseButton(0) && time > 0 && peregriv == false)
        {
            print("element activation");
            time -= Time.deltaTime;
            foreach (MonoBehaviour script in scripts)
            {
                scripts[numbersScript].Invoke("TypeFires", 0f); //scripts[numbersScript - 1].TypeFires();
            }
            // scripts[numbersScript - 1].TypeFires();
        }
        else
        {
            if (time < timeElement && time > 0)
            {
                peretaryad = true;
                print("peretharyad");
            }
            else
            {
                peretaryad = false;
            }

        }
        if (time <= 0)
        {
            peregriv = true;
            print("peergriv");
        }
        if((peregriv == true || peretaryad == true) && time < timeElement)
        {
            time += Time.deltaTime;
            scripts[numbersScript].Invoke("DestroyObject", 0f);
        }
        else
        {
            peregriv = false;
            peretaryad = false;
            print("gggg");
        }
    }
}
            
