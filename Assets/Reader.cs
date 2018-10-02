using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Reader : MonoBehaviour

{
    public GameObject EndPortal;
    public GameObject InstantKiller;

    public GameObject StraightPrefab;
    public GameObject TurnRightPrefab;
    public GameObject TurnLeftPrefab;
    public GameObject EndCapPrefab;
    public GameObject StartPrefab;

    float MagicNumber = 10;


    // Use this for initialization
    public void Read()
    {

        LSystem LSystem = new LSystem("./Assets/Level.txt");
        LSystem.Head = "Level";
        
        

        string[] result = LSystem.Calculate();
        Debug.Log(string.Join(", ", result));


        float x = 0;
        float z = 0;

        float nextX = 0;
        float nextZ = 1;
        float currentRotation = 0;
        Quaternion currentQuat = Quaternion.identity;
        
        for (int i = 0; i < result.Length; i++)
        {
            string roomString = result[i];
            Vector3 f;
            

            switch (roomString) {
                case "Start":
                    QuickUp(StartPrefab, new Vector3(x, 0, z), currentQuat);
                    break;
                case "Straight":
                case "InstantDeath":
                    QuickUp(StraightPrefab, new Vector3(x, 0, z), currentQuat);
                    //QuickUp(InstantKiller, new Vector3(x, 2.5f, 0), currentQuat);
                    break;
                case "TurnRight":
                    QuickUp(TurnRightPrefab, new Vector3(x, 0, z), currentQuat);

                    currentRotation -= 90;
                    currentQuat = Quaternion.Euler(0, -currentRotation, 0);
                    f = currentQuat * Vector3.forward;
                    nextZ = f.z;
                    nextX = f.x;
                    break;
                case "TurnLeft":
                    QuickUp(TurnLeftPrefab, new Vector3(x, 0, z), currentQuat);
                   
                    currentRotation += 90;                    
                    currentQuat = Quaternion.Euler(0, -currentRotation, 0);
                    f = currentQuat * Vector3.forward;
                    nextZ = f.z;
                    nextX = f.x;
                    break;
                case "End":
                    QuickUp(EndCapPrefab, new Vector3(x, 0, z), currentQuat);
                    QuickUp(EndPortal, new Vector3(x, 2.5f, z), currentQuat);

                    break;
                default:
                    Debug.Log("Whoa, you weren't prepared for this room" + roomString);
                    break;
            }


            x += MagicNumber * 2 * nextX;
            z += MagicNumber * 2 * nextZ;
            
        }
        


    }

    private GameObject QuickUp(GameObject gameObject, Vector3 position)
    {
        return QuickUp(gameObject, position, Quaternion.identity);
    }

    private GameObject QuickUp(GameObject gameObject, Vector3 position, Quaternion quaternion)
    {
        GameObject newObject = Instantiate<GameObject>(gameObject, position, quaternion);
        newObject.transform.parent = GameState.EveryonesParent.transform;
        return newObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
