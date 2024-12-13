using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Cursor_move : MonoBehaviour
{
    private List<GameObject> Copy_Block = new List<GameObject>();

    private Vector2 x_y;
    private GameObject Move_Block;
    public GameObject ParentEEEE;
    private bool IsObject;
    public Transform positionBlock;
    public Magic_controler magic_controler;// короч їбись тут з посиланням на інший список 

    public Canvas canvas; // Твій Canvas
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    void Start()
    {
        // Отримуємо GraphicRaycaster компонента Canvas
        raycaster = canvas.GetComponent<GraphicRaycaster>();
        // Створюємо нову подію для обробки курсора
        eventSystem = EventSystem.current;
         //magic_controler = magic_controler.GetComponent<MagicController>();

    }

    void Update()
    {
        Transform AAA = Move_Block.transform.Find("objectScript"); ;

        // Створюємо подію для обробки позиції курсора
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            if (IsObject == false && Move_Block == null)
            {
                // Створюємо список для результатів
                var results = new List<RaycastResult>();

                // Виконуємо raycast
                raycaster.Raycast(pointerEventData, results);
                // Перевіряємо, чи є об'єкт з потрібним тегом
                foreach (var result in results)
                {
                    if (result.gameObject.CompareTag("AAA"))
                    {
                        Move_Block = result.gameObject;
                        IsObject = true; // Знайдено об'єкт з тегом
                        print(result);

                    }

                }
            }
            if (IsObject == true && Move_Block != null)
            {
                Debug.Log("Об'єкт з тегом 'AAA'");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("x_y = " + x_y);
                    Debug.Log("Move_Block.transform.localPosition = " + Move_Block.transform.localPosition);
                    if (Copy_Block.Contains(Move_Block) == false)
                    {
                        Move_Block = Instantiate(Move_Block, pointerEventData.position, Move_Block.transform.rotation);
                        Move_Block.transform.SetParent(ParentEEEE.transform, false);
                        RectTransform rectTransform = Move_Block.GetComponent<RectTransform>();
                        rectTransform.sizeDelta = new Vector2(420, 50);
                        Copy_Block.Add(Move_Block);
                    }
                   
                    Move_Block.transform.position = pointerEventData.position;
                }
               
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(Move_Block.transform.position, positionBlock.position) < 50f)
            {
                Move_Block.transform.position = positionBlock.position;
                
               
                //MonoBehaviour scriptMove_block = AAA.GetComponent<MonoBehaviour>();
                magic_controler.magicBlockSkript.Add(AAA.GetComponent<MonoBehaviour>());
                magic_controler.Invoke("Binding", 0f);
            }
            IsObject = false;
            Move_Block = null;
        }
    }
}
