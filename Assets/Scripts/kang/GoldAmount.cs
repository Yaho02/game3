using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldAmount : MonoBehaviour
{
    public Text Gold;
    public int gold;
    public GameObject ob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gold = ob.GetComponent<Gold_manager>().gold;
        Gold.text = "" + gold;
    }
}