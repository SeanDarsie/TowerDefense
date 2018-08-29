using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMeunFunctions : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {
	Text myText;
	public enum MenuFunction {START, QUIT, OPTIONS, CREDITS}
	public MenuFunction menuFunction;

	delegate void MyMenuFucntion();
    MyMenuFucntion myMenuFunction;
	[SerializeField] Color highlightedColor;
	[SerializeField] Color normalColor;
	[SerializeField] Color disabledColor;
	[SerializeField] Color pressedColor;
	[SerializeField] Image line1;
	[SerializeField] Image line2;
	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<Text>();
		myText.color = normalColor;
		switch(menuFunction)
		{
			case StartMeunFunctions.MenuFunction.START:
				Debug.Log("My delegate function starts the game");
				myMenuFunction = FindObjectOfType<StartMenuManager>().StartGame;
				break;
			case StartMeunFunctions.MenuFunction.OPTIONS:
				myMenuFunction = quitGame;
				Debug.Log("My delegate function opens Options Menu");
				break;
			case StartMeunFunctions.MenuFunction.QUIT:
				Debug.Log("My delegate function Quits the game");
				break;
			case StartMeunFunctions.MenuFunction.CREDITS:
				Debug.Log("My delegate function shows credits");
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame

	/// <summary>
	/// Called every frame while the mouse is over the GUIElement or Collider.
	/// </summary>
	public void OnPointerEnter(PointerEventData eventData)
     {
         myText.color = highlightedColor; //Or however you do your color
		 line1.enabled = true;
		 line2.enabled = true;
		//  Debug.Log(eventData.pointerEnter);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         myText.color = normalColor; //Or however you do your color
		 line1.enabled = false;
		 line2.enabled = false;
     }
	 public void OnPointerClick(PointerEventData eventData)
	 {
		 myText.color = pressedColor;
		 myMenuFunction();
	 }
	void quitGame()
	{
		Application.Quit();
	}
}
