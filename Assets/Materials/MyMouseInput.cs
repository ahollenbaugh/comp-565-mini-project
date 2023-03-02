using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMouseInput : MonoBehaviour
{
    public PrimitiveType objectType;

    public void ChangePrimitiveTypeCube()
    {
        objectType = PrimitiveType.Cube;
    }

    public void ChangePrimitiveTypeSphere()
    {
        objectType = PrimitiveType.Sphere;
    }

    public void ChangePrimitiveTypeCapsule()
    {
        objectType = PrimitiveType.Capsule;
    }

    // Start is called before the first frame update
    void Start()
    {
        objectType = PrimitiveType.Cube;

        // CreatePrimitive returns a GameObject
        // PrimitiveType.Capsule is a PrimitiveType
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
            Debug.Log(hitInfo.transform.tag);
            if (hit)
            {
                #region HIDE
                var geomObj = GameObject.CreatePrimitive(objectType);
                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;
                #endregion

                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                #region HIDE
                if (hitInfo.transform.name.Equals("Base") && !hitInfo.transform.tag.Equals("button"))
                {
                    geomObj.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                #region HIDE
                else
                {
                    geomObj.transform.position = hitInfo.transform.position + (hitInfo.normal);
                    geomObj.transform.rotation = Quaternion.LookRotation(hitInfo.normal, Vector3.up);
                    //if (hitInfo.normal == new Vector3(0, 0, 1)) // z+
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z + (0.5f));
                    //}
                    //#region HIDE
                    //if (hitInfo.normal == new Vector3(1, 0, 0)) // x+
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.point.x + (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    //}
                    //if (hitInfo.normal == new Vector3(0, 1, 0)) // y+
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y + (0.5f), hitInfo.transform.position.z);
                    //}
                    //if (hitInfo.normal == new Vector3(0, 0, -1)) // z-
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.position.y, hitInfo.point.z - (0.5f));
                    //}
                    //if (hitInfo.normal == new Vector3(-1, 0, 0)) // x-
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.point.x - (0.5f), hitInfo.transform.position.y, hitInfo.transform.position.z);
                    //}
                    //if (hitInfo.normal == new Vector3(0, -1, 0)) // y-
                    //{
                    //    cube.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.point.y - (0.5f), hitInfo.transform.position.z);
                    //}
                    //#endregion
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