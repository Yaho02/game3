using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status Data", menuName = "Custom/Status Data", order = int.MaxValue)]
public class StatusData : ScriptableObject
{
    [SerializeField]
    public int maxtime;
    [SerializeField]
    public int Mineral;
    [SerializeField]
    public int Wood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
