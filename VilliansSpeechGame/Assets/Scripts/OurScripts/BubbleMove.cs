using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    private bool mouseDown = false;
    private Vector3 startMousePos;
    private Vector3 startpos;
    private bool restrictX;
    private bool restrictY;
    private float fakeX;
    private float fakeY;
    private float myWidth;
    private float myHeight;
    public Vector3 startingPosition;
    public RectTransform ParentRT;
    public RectTransform MyRect;


    public Vector3 position;
    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
        myWidth = (MyRect.rect.width + 5) / 2;
        myHeight = (MyRect.rect.height + 5) / 2;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        mouseDown = true;
        startpos = transform.position;
        startMousePos = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            Vector3 pos = startpos + diff;
            transform.position = pos;

            if (transform.localPosition.x < 0 - ((ParentRT.rect.width / 2) - myWidth) || transform.localPosition.x > ((ParentRT.rect.width / 2) - myWidth))
                restrictX = true;
            else
                restrictX = false;

            if (transform.localPosition.y < 0 - ((ParentRT.rect.width / 2) - myHeight) || transform.localPosition.y > ((ParentRT.rect.height / 2) - myHeight))
                restrictY = true;
            else
                restrictY = false;

            if (restrictX)
            {
                if (transform.localPosition.x < 0)
                    fakeX = 0 - (ParentRT.rect.width / 2) + myWidth;
                else
                    fakeY = (ParentRT.rect.width / 2) - myWidth;

                Vector3 xpos = new Vector3(fakeX, transform.localPosition.y, 0.0f);
                transform.localPosition = xpos;
            }

            if (restrictY)
            {
                if (transform.localPosition.y < 0)
                    fakeY = 0 - (ParentRT.rect.height / 2) + myHeight;
                else
                    fakeY = (ParentRT.rect.height / 2) - myHeight;

                Vector3 ypos = new Vector3(transform.localPosition.x, fakeY, 0.0f);
                transform.localPosition = ypos;
            }

        }
        if (!mouseDown)
        {
            float dist = Vector3.Distance(transform.position, startingPosition);
            position.x += dist;
            position.y += dist;
            if(position.x > startingPosition.x)
            {
                position.x += dist;
                
            }
            if (position.y > startingPosition.y)
            {
                position.y += dist;
                
            }
            transform.position = position;

        }
    }





}
