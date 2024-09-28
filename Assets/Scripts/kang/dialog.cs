using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite cg;
}

public class dialog : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Button agree_button;

    private bool isDialogue = false;
    private int count = 1;
    
    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialogue()
    {
        //ONOFF(true);//대화 시작
        NextDialogue();
    }

     ///private void ONOFF(bool _flag)
    //{
        //sprite_DialogueBox.gameObject.SetActive(_flag);
        //sprite_StandingCG.gameObject.SetActive(_flag);
        //txt_Dialogue.gameObject.SetActive(_flag);
        //agree_button.gameObject.SetActive(_flag);
        //isDialogue = _flag;
    //}

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count ++;
        if (count == 3)
        {
            count = 0;
        } 
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
