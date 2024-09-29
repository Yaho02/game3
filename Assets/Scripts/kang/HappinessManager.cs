using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int happiness = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //happiness += 100;
    }

    /*public void AddHappiness(int amount)
    {
        happiness += amount;
    }

    public int GetAmount()
    {
        return happiness;
    }*/
    
    public void RightMeal()
    {
        happiness += 100;
        Debug.Log("증가");
    }

    public void WrongMeal()
    {
        happiness -= 100;
    }
}
