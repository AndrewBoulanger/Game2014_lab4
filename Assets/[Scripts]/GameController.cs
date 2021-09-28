using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public Rect screen;
    public Rect safeArea;

    public RectTransform backButtonRect;
    public RectTransform nextButtonRect;

    public Vector2 backButtonAnchor;
    public Vector2 nextButtonAnchor;

    // Start is called before the first frame update
    void Start()
    {

        backButtonAnchor = backButtonRect.anchoredPosition;
        nextButtonAnchor = nextButtonRect.anchoredPosition;

    }

    // Update is called once per frame
    void Update()
    {
         screen.width = Screen.width;
        screen.height = Screen.height;
         safeArea = Screen.safeArea;
        float xOffset = safeArea.width - screen.width;

      // Debug.Log( Screen.orientation);

        switch(Screen.orientation)
        {

            case ScreenOrientation.LandscapeLeft:
                backButtonRect.anchoredPosition = new Vector2(backButtonAnchor.x + safeArea.x, backButtonAnchor.y) ;
                nextButtonRect.anchoredPosition = new Vector2(nextButtonAnchor.x + xOffset, nextButtonAnchor.y) ;
                break;
            case ScreenOrientation.LandscapeRight:
                backButtonRect.anchoredPosition = new Vector2(backButtonAnchor.x + safeArea.x, backButtonAnchor.y);
                 nextButtonRect.anchoredPosition = new Vector2(nextButtonAnchor.x + xOffset, nextButtonAnchor.y) ;
                break;
            case ScreenOrientation.Portrait:
                backButtonRect.anchoredPosition = new Vector2(backButtonAnchor.x, backButtonAnchor.y);
                nextButtonRect.anchoredPosition = new Vector2(nextButtonAnchor.x, nextButtonAnchor.y) ;
                break;
            default:
                break;
        }

    }
}
