using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 
/// ui text�� �ҷ����� ���� �κ�

using JetBrains.Annotations;


/// </summary>
public class Gold_amount : MonoBehaviour
{
    public Text Gold;
    public int gold;



    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text = "GOLD : " + gold ;
    }
}
