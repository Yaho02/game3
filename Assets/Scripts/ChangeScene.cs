using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScence : MonoBehaviour
{
    public int stage;

    public void loading()
    {
        StartCoroutine(loadScene());

    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(stage);
    }
}
