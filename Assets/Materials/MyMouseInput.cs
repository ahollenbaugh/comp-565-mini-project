using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMouseInput : MonoBehaviour
{
    public PrimitiveType objectType;
    GameObject geomObj;
    bool objPlaced = false;

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
        // Set default object type:
        objectType = PrimitiveType.Cube;

        // Create initial GameObject:
        geomObj = GameObject.CreatePrimitive(objectType);
    }

    // Update is called once per frame
    void Update()
    {
        if (!objPlaced)
        {
            // Try getting raycast data while you move the mouse around instead of only when it's clicked:
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo); // starting point of ray in world coordinates, direction of ray
            Debug.Log("Raycast coordinates: (" + hitInfo.point.x + ", " + hitInfo.point.y + ", " + hitInfo.point.z + ")");
            geomObj.transform.position = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);

            if (Input.GetMouseButtonUp(0))  // check if left button is pressed
            {
                // take mouse position, convert from screen space to world space, do a raycast, store output of raycast into 
                // hitInfo object ...

                #region Screen To World
                //RaycastHit hitInfo = new RaycastHit();
                //bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo); // starting point of ray in world coordinates, direction of ray

                if (hit)
                {
                    #region HIDE
                    //var geomObj = GameObject.CreatePrimitive(objectType);
                    //cube.GetComponent<BoxCollider>().isTrigger = true;
                    //cube.GetComponent<Renderer>().material = blockMaterial;
                    #endregion

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
                    }
                    #endregion

                    objPlaced = true;

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
        else
        {
            // Need to make a new object:
            geomObj = GameObject.CreatePrimitive(objectType);
            objPlaced = false;

        }
        
        //if (Input.GetMouseButtonUp(1))
        //{
        //    // If the user right-clicks on an object, it explodes.
        //    hitInfo = new RaycastHit();
        //    hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        //    if (hit)
        //    {
        //        if (!hitInfo.transform.name.Equals("Base"))
        //        {
        //            var exp = hitInfo.transform.gameObject.AddComponent<TriangleExplosion>();
        //            StartCoroutine(exp.SplitMesh(true));

        //        }
        //    }
        //}
    }
}