using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyins : MonoBehaviour
{
    Stack<string> BlockLine = new Stack<string>();


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            BlockLine.Push("왼쪽");
            Debug.Log(BlockLine);

            Debug.Log("왼쪽방향키");
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            BlockLine.Push("오른쪽");
            Debug.Log(BlockLine);
            Debug.Log("오른쪽방향키");
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("위쪽방향키");
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("아래쪽방향키");
        }
    }
}
