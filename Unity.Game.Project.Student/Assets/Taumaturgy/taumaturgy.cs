 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taumaturgy : MonoBehaviour
{
    [Header ("елементи")]
    [SerializeField, Range(1 ,4)] private int numberlEmenta;
    [SerializeField] private List<string> Element = new List<string> { "Fire", "Water", "Earth" , "Air"};

    [Header ("довжина та швиткість вектору")]
    [SerializeField, Range(1, 10)] private float lengthVector;
    [SerializeField, Range(0, 10)] private float speedVector;

    [Header ("розмір елементу в радіусі основи")]
    [SerializeField, Range(0,5)] private float sizeElement;

    [Header("Тип та форма  атаки")]
    [SerializeField] private List<string> formAtack = new List<string> { "no form (cone)","sphere"};
    [SerializeField, Range(1, 2)] private int  formElement;
    [SerializeField] private List<string> typeAtack = new List<string> { "arize Atack", "from player" };
    [SerializeField, Range(1, 2)] private int nomberTypeElement;

    public Transform _elemental;
    public List<GameObject> ElementPrefab;

     private int innnn;
     private GameObject ELemntPrefabClone;

    private  Vector3 scaleElament1 ;
    void Start()
    {
        
        innnn = typeAtack.Count*(numberlEmenta-1) + (formElement-1);
        // ELemntPrefabClone = Instantiate(ElementPrefab[innnn], _elemental.position, _elemental.rotation);
        //ELemntPrefabClone.transform.localScale = new Vector3(lengthVector,lengthVector,lengthVector);
        Vector3 scaleElament1 = ELemntPrefabClone.transform.localScale;
    }

    void FixedUpdate()
    {
        //Vector3 scaleElament1 = ELemntPrefabClone.transform.localScale;
        // ELemntPrefabClone.transform.SetParent(_elemental);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_elemental.childCount < 1)
            {
                ELemntPrefabClone = Instantiate(ElementPrefab[innnn], _elemental.position, _elemental.rotation);
                ELemntPrefabClone.transform.SetParent(_elemental);
                Vector3 scaleElament1 = ELemntPrefabClone.transform.localScale;

            }
            else
            {
                while (scaleElament1.x <= sizeElement)
                {
                    // Vector3 scaleElament =ELemntPrefabClone.transform.localScale ;
                    scaleElament1= Vector3.Lerp(scaleElament1, new Vector3(sizeElement,sizeElement,sizeElement),Time.deltaTime);
                }
            }

            // ELemntPrefabClone.transform.SetParent(_elemental );
            // ELemntPrefabClone.transform.Translate(new Vector3(0, 0, 1) * speedVector * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ELemntPrefabClone.transform.SetParent(null);
            ELemntPrefabClone.transform.Translate(new Vector3(0, 0, 1) * speedVector * Time.deltaTime); // напрям вперед поки що )

        }
    }
}
