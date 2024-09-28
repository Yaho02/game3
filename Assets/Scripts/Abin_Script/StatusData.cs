using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status Data", menuName = "Custom/Status Data", order = int.MaxValue)]
public class StatusData : ScriptableObject
{
    [SerializeField]
    public int maxtime;
    [SerializeField]
    public int Happy;
    [SerializeField]
    public int Damage;

    [SerializeField]
    public int Heal;

    public void SaveStatus()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("Status Data", jsonData);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    public void LoadStatus()
    {
        if (PlayerPrefs.HasKey("Status Data"))
        {
            string jsonData = PlayerPrefs.GetString("Status Data");
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
    }
}
