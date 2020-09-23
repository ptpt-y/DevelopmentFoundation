using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;
    [SerializeField]
    string sceneName;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == strTag)
        {
            FindObjectOfType<GameManager>().CompleteLevel();
        }
        
    }
}
