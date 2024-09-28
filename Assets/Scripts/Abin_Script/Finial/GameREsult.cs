using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameREsult : MonoBehaviour
{
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("벽에 부딪힘");
        }
    }
}
