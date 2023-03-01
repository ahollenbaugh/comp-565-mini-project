using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour
{
    int n;
    public string OnButtonPress()
    {
        //n++;
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name + " button clicked " + n + " times.");
        return EventSystem.current.currentSelectedGameObject.name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
