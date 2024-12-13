using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taumaturgia_original_1 : MonoBehaviour
{
    [Header("точка для розміщенyyня")]
    public GameObject PointCreate;

    public  List<GameObject> amunition_Magic = new List<GameObject>();
   

    // Start is called before the first frame update
    [Header("блоки настройок")]

    public GameObject CreateBlockOptins;
    public GameObject CoverBlockOptins;
    public GameObject MoveBlockOptins;
    public GameObject TemperatureBlockOptins;
    public GameObject TypeAttackBlockOptins;
    public GameObject SizeBlockOptins;
    public GameObject WaitBlockOptins;


    public Transform PanelBlock;
    [Header("точка для розміщення")]
    public GameObject PlacementBlock;

    public List<MonoBehaviour> scripts = new List<MonoBehaviour>();
    public int W ;
    public GameObject Canvas_panel;

    public bool CreateTrue;
    private GameObject instantiatedPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.P))
        {
            Canvas_panel.SetActive(!Canvas_panel.activeSelf);
        }

        if ( W < scripts.Count && !Canvas_panel.activeSelf)
        {
            if (Input.GetMouseButtonUp(0))
            {
                CreateTrue = true;
                print("okomm");
            }

            scripts[W].Invoke("BlockActivation", 0f);
           // print(scripts.Count);
        }
        else
        {
            W = 0;

        }

    }
    public void OnCreateButtonDown()
    {
        instantiatedPrefab = Instantiate(CreateBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnCoverButtonDown()
    {
         instantiatedPrefab = Instantiate(CoverBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnMoveButtonDown()
    {
         instantiatedPrefab = Instantiate(MoveBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnTemperatureButtonDown()
    {
        instantiatedPrefab = Instantiate(TemperatureBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnTypeAttackButtonDown()
    {
         instantiatedPrefab = Instantiate(TypeAttackBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnButtonDown()
    {
        print("немає елеента ");
    }
    public void OnSizeButtonDown()
    {
         instantiatedPrefab = Instantiate(SizeBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    public void OnWaitButtonDown()
    {
         instantiatedPrefab = Instantiate(WaitBlockOptins, PlacementBlock.transform.localPosition, PlacementBlock.transform.rotation);
        Invoke("Binding",0f);
    }
    private void Binding()
    {
        instantiatedPrefab.transform.SetParent(PanelBlock, false);

        Vector2 positionPlacementBlock = PlacementBlock.transform.position;
        positionPlacementBlock.y -= 99;
        PlacementBlock.transform.position = positionPlacementBlock;

        MonoBehaviour a = instantiatedPrefab.GetComponent<MonoBehaviour>();
        if (a != null)
        {
            scripts.Add(a);
        }
    }
}

