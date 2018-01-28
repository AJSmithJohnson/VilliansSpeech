using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    #region ThoughtMoveVariables

    public string myText = "";
    public GameObject submitBttn;

    private bool mouseDown = false;
    
    private Vector3 startMousePos;
    
    private Vector3 startpos;
    private bool restrictX;
    private bool restrictY;
    private float fakeX;
    private float fakeY;
    private float myWidth;
    private float myHeight;
    public RectTransform ParentRT;
    public RectTransform MyRect;


    private Vector3 rectObjectPosition;
    private Vector3 boable;
    private Vector3 vectorMover;
    #endregion

    public int catagory;
    public int value;
    
    /// <summary>
    /// For the bluff box
    /// </summary>
    public BoxController bluffScript;
    public GameObject bluffBox;

    /// <summary>
    /// For the bluff box
    /// </summary>
    public BoxController methodScript;
    public GameObject    methodBox;

    /// <summary>
    /// For the bluff box
    /// </summary>
    public BoxController demandScript;
    public GameObject    demandBox;

    /// <summary>
    /// For the bluff box
    /// </summary>
    public BoxController threatScript;
    public GameObject    threatBox;

    /// <summary>
    /// For the bluff box
    /// </summary>
    public BoxController locationScript;
    public GameObject    locationBox;

    public Vector3 target;

    public int scriptSelector;
    public int radius = 10;

    // Use this for initialization
    void Start()
    {
        rectObjectPosition = transform.localPosition;
        boable.x = 2;
        boable.y = 2;
        boable.z = 0;
        
        myWidth = (MyRect.rect.width + 5) / 2;
        myHeight = (MyRect.rect.height + 5) / 2;
        SelectCollision();
        
    }

    private void SelectCollision()
    {
        if(catagory == 2)
        {
            target = bluffBox.transform.position;
            scriptSelector = 2; 
        }
        else if(catagory == 1)
        {
            target = methodBox.transform.position;
            scriptSelector = 1;
        }
        else if (catagory == 3)
        {
            target = demandBox.transform.position;
            scriptSelector = 3;
        }
        else if (catagory == 4)
        {
            target = threatBox.transform.position;
            scriptSelector = 4;
        }
        else if (catagory == 5)
        {
            target = locationBox.transform.position;
            scriptSelector = 5;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        mouseDown = true;
        startpos = transform.localPosition;
        startMousePos = Input.mousePosition;
        print(startMousePos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target, transform.position);
        if (mouseDown)
        {
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            
            Vector3 pos = startpos + diff;
            transform.position = currentPos;

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
                return;
                if (transform.localPosition.x < 0)
                    fakeX = 0 - (ParentRT.rect.width / 2) + myWidth;
                else
                    fakeY = (ParentRT.rect.width / 2) - myWidth;

                Vector3 xpos = new Vector3(fakeX, transform.localPosition.y, 0.0f);
                transform.localPosition = xpos;
            }

            if (restrictY)
            {
                return;
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

            transform.localPosition = Vector3.Lerp(transform.localPosition, rectObjectPosition, 2f*Time.deltaTime);
            


        }
        
        if(dist <= radius)
        {
            switch (scriptSelector)
            {
                case 1:
                    methodScript.value = value;
                    methodScript.text.text = myText;
                    break;
                case 2:
                    bluffScript.value = value;
                    bluffScript.text.text = myText;
                    break;
                case 3:
                    demandScript.value = value;
                    demandScript.text.text = myText;
                    break;
                case 4:
                    threatScript.value = value;
                    threatScript.text.text = myText;
                    break;
                case 5:
                    locationScript.value = value;
                    locationScript.text.text = myText;
                    break;
            }
            if(methodScript.value != -1 && bluffScript.value != -1 && demandScript.value != -1 && threatScript.value != -1 && locationScript.value != -1)
            {
                submitBttn.SetActive(true);
            }
            
        }
    }





}
