using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_TP : MonoBehaviour
{
    public GameObject fade_obj;
    private void OnTriggerEnter2D(Collider2D obj)
    {
      if( obj.gameObject.CompareTag("Player"))
        fade_obj.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
