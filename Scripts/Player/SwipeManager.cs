using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tab, swipeLeft, swipeRight, swipeUp, swapDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tab = swapDown = swipeLeft = swipeRight = swipeUp = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tab = true;
            isDraging = false;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion
        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tab = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        if (swipeDelta.magnitude > 5)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swapDown = true;
                else
                    swipeUp = true;
            }
            Reset();
        }
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
