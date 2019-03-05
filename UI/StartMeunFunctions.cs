using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMeunFunctions : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler {
	[HideInInspector] public Text myText;
	public enum MenuFunction {START, QUIT, CONTROLS, CREDITS, LEVEL,SWITCHMENUS}
	[SerializeField] bool text = true;
	[HideInInspector] public bool selected;
	public MenuFunction menuFunction;

	delegate void MyMenuFucntion();
    MyMenuFucntion myMenuFunction;
	[SerializeField] Color highlightedColor;
	[SerializeField] Color normalColor;
	[SerializeField] Color disabledColor;
	[SerializeField] Color pressedColor;
	[SerializeField] Color BackGroundColor;
	[SerializeField] public Image line1;
	[SerializeField] public Image line2;
	[Tooltip("What level to activate with this button")]
	[SerializeField] int level;
	[SerializeField] string whatMenuToActivate;
	bool disabled = false;
	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<Text>();
		myText.color = normalColor;
		if (!text)
			line1.color = BackGroundColor;
		switch(menuFunction)
		{
			case StartMeunFunctions.MenuFunction.START:
				// Debug.Log("My delegate function starts the game");
				myMenuFunction = FindObjectOfType<StartMenuManager>().StartGame;
				break;
			case StartMeunFunctions.MenuFunction.CONTROLS:
				myMenuFunction = ShowControlsMenu;
				// Debug.Log("My delegate function opens CONTROLS Menu");
				break;
			case StartMeunFunctions.MenuFunction.QUIT:
				myMenuFunction = quitGame;
				// Debug.Log("My delegate function Quits the game");
				break;
			case StartMeunFunctions.MenuFunction.CREDITS:
//				Debug.Log("My delegate function shows credits");
				break;
			case StartMeunFunctions.MenuFunction.LEVEL:
//				Debug.Log("startMenuFunctions button for choosing a level");
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
		 if (selected == false)
         	myText.color = highlightedColor; //Or however you do your color
		 if (text == true)
		 {
			line1.enabled = true;
		 	line2.enabled = true;
		 	line1.color = highlightedColor;
		 	line2.color = highlightedColor;
		 }
		 else
		 {
			if (selected == false)
			{
				line1.color = BackGroundColor;
		 		line2.color = BackGroundColor;
			}
		 }
		 SwitchDelegateFunction();
		//  Debug.Log(eventData.pointerEnter);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
		 if (selected == false)
         	myText.color = normalColor; //Or however you do your color
		 if (text == true)
		 {
			line1.enabled = false;
		 	line2.enabled = false;
		 }
		 else
		 {
			 if (selected == false)
			 {
				line1.color = BackGroundColor;
			 	line2.color = BackGroundColor;
			 }
		 }
		 myMenuFunction = null;
     }
	 public void OnPointerUp(PointerEventData eventData)
	 {
		if (text == true)
		{
			myText.color = normalColor; //Or however you do your color
		 	line1.color = normalColor;
		 	line2.color =	normalColor;
		 	line1.enabled = false;
		 	line2.enabled = false;
		}
		else
		{
			myText.color = normalColor;
			line1.color = BackGroundColor;
		}
		if (myMenuFunction != null)
			myMenuFunction();
	 }
	 public void OnPointerDown(PointerEventData eventData)
	 {
		 myText.color = pressedColor;
		 if (text == true)
		 {
			line1.color = pressedColor;
		 	line2.color = pressedColor;
		 }
		 else
		 {
			 line1.color = BackGroundColor;
		 }
	 }
	void quitGame()
	{
		#if UNITY_EDITOR
      		UnityEditor.EditorApplication.isPlaying = false;
 		#else
 			Application.Quit();
 		#endif
	}

	void ShowControlsMenu()
	{
		SwitchMenu();
	}

	[SerializeField] int maxLevel = 1; // TODO: make this a serialized field 
	void ChooseALevel()
	{
		// highlight that the level is chosen
		
		// StartMeunFunctions[] buttons = FindObjectsOfType<StartMeunFunctions>();
		foreach (StartMeunFunctions x in FindObjectsOfType<StartMeunFunctions>())
		{
			x.selected = false;
			x.myText.color = x.normalColor;
			x.line1.color = x.BackGroundColor;
		}
		selected = true;
		line1.color = highlightedColor;
		myText.color = pressedColor;
		GetComponentInChildren<Text>().text = "Level " + (level + 1).ToString();
		FindObjectOfType<LevelChooser>().chosenLevel = level;
	}

	void SwitchMenu()
	{
		FindObjectOfType<UImanager>().SwithMenus(whatMenuToActivate);
	}
	void SwitchDelegateFunction()
	{
		switch(menuFunction)
		{
			case StartMeunFunctions.MenuFunction.START:
				// Debug.Log("My delegate function starts the game");
				myMenuFunction = FindObjectOfType<StartMenuManager>().StartGame;
				break;
			case StartMeunFunctions.MenuFunction.CONTROLS:
				myMenuFunction = ShowControlsMenu;
				// Debug.Log("My delegate function opens Options Menu");
				break;
			case StartMeunFunctions.MenuFunction.QUIT:
				myMenuFunction = quitGame;
				// Debug.Log("My delegate function Quits the game");
				break;
			case StartMeunFunctions.MenuFunction.CREDITS:
//				Debug.Log("My delegate function shows credits");
				break;
			case StartMeunFunctions.MenuFunction.LEVEL:
				myMenuFunction = ChooseALevel;
//				Debug.Log("startMenuFunctions button for choosing a level");
				break;
			case StartMeunFunctions.MenuFunction.SWITCHMENUS:
				myMenuFunction = SwitchMenu;
				break;
			default:
				break;
		}
	}
}
