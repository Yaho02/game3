using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SNum : MonoBehaviour
{
    public StatusData collect;

    public string item;
    // Start is called before the first frame update
    public void CLicking()
    {
        //Debug.Log("유후");
        switch(item)
        {
            case "water":
                Debug.Log("물");
                if (collect.Happy>100.0f)
                {
                    break;
                }
                else{
                    collect.Happy += 20;
                }
                Debug.Log("Happy" + collect.Happy);
                break;

            case "fire":
                Debug.Log("불");
                if (collect.Happy>100.0f)
                {
                    break;
                }
                else{
                    collect.Happy -= 20;
                }
                Debug.Log("Happy" + collect.Happy);
                break;
            
            case "wind":
                Debug.Log("qkfka");
                if (collect.Happy>100.0f)
                {
                    break;
                }
                else{
                    collect.Happy -= 20;
                }
                Debug.Log("Happy" + collect.Happy);
                break;
        }

    }
}
