using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_TP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
      if( obj.gameObject.CompareTag("Player"))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);


    }
}
