using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    Image image;
    private bool isEntered;
    private float clickLag;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntered) {
            float mouseX = (Screen.width - Input.mousePosition.x) / Screen.width;
            float mouseY = (Screen.height - Input.mousePosition.y) / Screen.height;
            if (mouseX <= 0.95 && mouseY >= 0.05)
            {
                transform.position = Vector3.Lerp(transform.position, Input.mousePosition, 0.95f);
            }
            if (Input.GetMouseButton(0)) {
                isEntered = false;
                clickLag = 10;
            }
        }
        if (clickLag > 0) {
            clickLag -= 1;
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(1,0.8f,1);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!isEntered && clickLag <= 0) {
            isEntered = true;
        }
    }

}
