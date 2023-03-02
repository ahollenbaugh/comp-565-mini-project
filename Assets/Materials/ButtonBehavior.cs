using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static MyMouseInput; // for changing the spawning gameobjects

public class ButtonBehavior : MonoBehaviour
{
    public MyMouseInput mymouseinput;
    public void OnButtonPress()
    {
        mymouseinput.objectType = PrimitiveType.Cube;
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
