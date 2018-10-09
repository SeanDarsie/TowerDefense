using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler { 
	
	public enum PauseMenuFunction {QUIT,RESTART,RESUME,RESTARTMENU,QUITMENU,NO}
	public PauseMenuFunction pauseMenuFunction;
	[SerializeField] Text myText;
	[SerializeField] Image line1;
	[SerializeField] Image line2;
	[SerializeField] Color normalColor;
	[SerializeField] Color highlightedColor;
	[SerializeField] Color pressedColor;
	[SerializeField] Color disabledColor;
	// Delegates for switching what each "button" does
	delegate void MyPauseMenuFunction();
	MyPauseMenuFunction myPauseMenuFunction;
	// Delegates for switching what each "button" does
	
	// [SerializeField] GameObject ;	
	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<Text>();
		myText.color = normalColor;
		line1.color = normalColor;
		line2.color = normalColor;
		SwitchDelegateFunction();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerEnter(PointerEventData eventData)
     {
         myText.color = highlightedColor; //Or however you do your color
		 line1.enabled = true;
		 line2.enabled = true;
		 line1.color = highlightedColor;
		 line2.color = highlightedColor;
		 SwitchDelegateFunction();
		//  Debug.Log(eventData.pointerEnter);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         myText.color = normalColor; //Or however you do your color
		 line1.enabled = false;
		 line2.enabled = false;
		 myPauseMenuFunction = null;
     }
	 public void OnPointerUp(PointerEventData eventData)
	 {
		 myText.color = normalColor; //Or however you do your color
		 line1.color = normalColor;
		 line2.color =	normalColor;
		 line1.enabled = false;
		 line2.enabled = false;
		 if (myPauseMenuFunction != null)
			myPauseMenuFunction();
	 }
	 public void OnPointerDown(PointerEventData eventData)
	 {
		 myText.color = pressedColor;
		 line1.color = pressedColor;
		 line2.color = pressedColor;
	 }
	 void SwitchDelegateFunction()
	{
		switch(pauseMenuFunction)
		{
			case PauseMenuFunction.NO:
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().No;
				break;
			case PauseMenuFunction.QUITMENU:
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().AreYouSureQuit;
				break;
			case PauseMenuFunction.RESTARTMENU:
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().AreYouSureRestart;
				break;
			case PauseMenuFunction.RESTART:
				// Debug.Log("My delegate function starts the game");
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().RestartLevel;
				break;
			case PauseMenuFunction.QUIT:
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().QuitGame;
				break;
			case PauseMenuFunction.RESUME:
				myPauseMenuFunction = FindObjectOfType<QuitAndRestart>().UnPauseGame;
				// Debug.Log("My delegate function Quits the game");
				break;
			default:
				break;
		}
	}
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		myText = GetComponentInChildren<Text>();
		myText.color = normalColor;
		line1.enabled = false;
		line2.enabled = false;
		line1.color = normalColor;
		line2.color = normalColor;
		SwitchDelegateFunction();
	}
}
