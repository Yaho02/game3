using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int happiness;
    void Start()
    {
        happiness = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHappiness(int amount)
    {
        happiness += amount;
    }

    public int GetAmount()
    {
        return happiness;
    }
}
