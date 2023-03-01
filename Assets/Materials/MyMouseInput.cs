using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ButtonBehavior;

public class MyMouseInput : MonoBehaviour
{
    int index = 1; // for labeling each cube that gets generated

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (ButtonBehavior)

        if (Input.GetMouseButtonUp(0))  // check if left button is pressed
        {
            // take mouse position, convert from screen space to world space, do a raycast, store output of raycast into 
            // hitInfo object ...

            #region Screen To World
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo); // starting point of ray in world coordinates, direction of ray
            if (hit)
            {
                Debug.Log(hitInfo.transform.name);
                Debug.Log(hitInfo.transform.tag);
                #region HIDE
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.tag = "MyCube" + index;
                //index++;
                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;
                #endregion

                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                #region HIDE
                if (hitInfo.transform.name.Equals("Base"))
                {
                    Debug.Log("hitInfo tag = base");
                    cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                #region HIDE
                else
                {
                    if (hitInfo.normal == new Vector3(0, 0, 1)) // z+
                    {
                        cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z + (0.5f));
                    }
                    #region HIDE
                    if (hitInfo.normal == new Vector3(1, 0, 0)) // x+
                    {
                        cube.transform.position = new Vector3(hitInfo.point.x + (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 1, 0)) // y+
                    {
                        cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y + (0.5f), hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, 0, -1)) // z-
                    {
                        cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z - (0.5f));
                    }
                    if (hitInfo.normal == new Vector3(-1, 0, 0)) // x-
                    {
                        cube.transform.position = new Vector3(hitInfo.point.x - (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    }
                    if (hitInfo.normal == new Vector3(0, -1, 0)) // y-
                    {
                        cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y - (0.5f), hitInfo.transform.position.z);
                    }
                    #endregion
                }
                #endregion

                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, 2, false);
                Debug.Log(hitInfo.normal);
                #endregion


            }
            else
            {
                Debug.Log("No hit");
            }
            #endregion
        }
    }
}