using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMeunFunctions : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler {
	Text myText;
	public enum MenuFunction {START, QUIT, OPTIONS, CREDITS, LEVEL}
	public MenuFunction menuFunction;

	delegate void MyMenuFucntion();
    MyMenuFucntion myMenuFunction;
	[SerializeField] Color highlightedColor;
	[SerializeField] Color normalColor;
	[SerializeField] Color disabledColor;
	[SerializeField] Color pressedColor;
	[SerializeField] Image line1;
	[SerializeField] Image line2;
	[Tooltip("What level to activate with this button")]
	[SerializeField] int level;
	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<Text>();
		myText.color = normalColor;
		switch(menuFunction)
		{
			case StartMeunFunctions.MenuFunction.START:
				// Debug.Log("My delegate function starts the game");
				myMenuFunction = FindObjectOfType<StartMenuManager>().StartGame;
				break;
			case StartMeunFunctions.MenuFunction.OPTIONS:
				myMenuFunction = quitGame;
				// Debug.Log("My delegate function opens Options Menu");
				break;
			case StartMeunFunctions.MenuFunction.QUIT:
				myMenuFunction = quitGame;
				// Debug.Log("My delegate function Quits the game");
				break;
			case StartMeunFunctions.MenuFunction.CREDITS:
				Debug.Log("My delegate function shows credits");
				break;
			case StartMeunFunctions.MenuFunction.LEVEL:
				Debug.Log("startMenuFunctions button for choosing a level");
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
		 SwitchDelegateFunction();
		//  Debug.Log(eventData.pointerEnter);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         myText.color = normalColor; //Or however you do your color
		 line1.enabled = false;
		 line2.enabled = false;
		 myMenuFunction = null;
     }
	 public void OnPointerUp(PointerEventData eventData)
	 {
		myText.color = normalColor; //Or however you do your color
		 line1.color = normalColor;
		 line2.color =	normalColor;
		 line1.enabled = false;
		 line2.enabled = false;
		 if (myMenuFunction != null)
			myMenuFunction();
	 }
	 public void OnPointerDown(PointerEventData eventData)
	 {
		 myText.color = pressedColor;
		 line1.color = pressedColor;
		 line2.color = pressedColor;
	 }
	void quitGame()
	{
		Application.Quit();
	}
	void ChooseALevel()
	{
		// this function will set the level chooser integer called "ChosenLevel" to whatever the current instace of theis Class contains 
		FindObjectOfType<LevelChooser>().chosenLevel = level;
	}
	void SwitchDelegateFunction()
	{
		switch(menuFunction)
		{
			case StartMeunFunctions.MenuFunction.START:
				// Debug.Log("My delegate function starts the game");
				myMenuFunction = FindObjectOfType<StartMenuManager>().StartGame;
				break;
			case StartMeunFunctions.MenuFunction.OPTIONS:
				myMenuFunction = quitGame;
				// Debug.Log("My delegate function opens Options Menu");
				break;
			case StartMeunFunctions.MenuFunction.QUIT:
				// Debug.Log("My delegate function Quits the game");
				break;
			case StartMeunFunctions.MenuFunction.CREDITS:
				Debug.Log("My delegate function shows credits");
				break;
			case StartMeunFunctions.MenuFunction.LEVEL:
				Debug.Log("startMenuFunctions button for choosing a level");
				break;
			default:
				break;
		}
	}
}
