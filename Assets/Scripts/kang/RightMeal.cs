using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMeal : MonoBehaviour
{
    // Start is called before the first frame update
    void rightMeal()
    {
        FindObjectOfType<HappinessManager>().AddHappiness(100);
    }
}
