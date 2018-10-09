using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHandling : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
	QuitAndRestart quitAndRestart;
	// Use this for initialization
	void Start () {
		quitAndRestart = FindObjectOfType<QuitAndRestart>();
	}
	
	// Update is called once per frame
	public void OnPointerEnter(PointerEventData eventData)
     {
	   quitAndRestart.mouseOverMenu = true;
		//  Debug.Log(eventData.pointerEnter);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
        quitAndRestart.mouseOverMenu = false;
     }
}
