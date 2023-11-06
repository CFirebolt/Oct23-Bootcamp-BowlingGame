using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public string displayNewText;

    [SerializeField]
    string displayText = "Game Started";

    public Transform testCube;

    public float rotateSpeed;
    public float moveSpeed; 

    void Start()
    {
        Debug.Log(displayText);
        
        int i = 5;
        if (i == 5 || i == 3)
        {
            Debug.Log("Value of i is 5 and 3");
        }
        else
        {
            Debug.Log("i is not equal to 5");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up);

        //testCube.Rotate(new Vector3(0, 1, 0) * rotateSpeed);
        testCube.Rotate(Vector3.up * rotateSpeed *Time.deltaTime);
        testCube.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));


        //testCube.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is being pressed");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Bar is pressed");
        }
        if (Input.GetKeyUp(KeyCode.C))

        {
            Debug.Log("C is released");
        }
        
    }
}
