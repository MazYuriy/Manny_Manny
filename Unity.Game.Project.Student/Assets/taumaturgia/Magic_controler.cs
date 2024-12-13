using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_controler : MonoBehaviour
{
    public List<MonoBehaviour> magicBlockSkript = new List<MonoBehaviour>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Binding()
    {
        Debug.Log(magicBlockSkript[0]);
    }
}
