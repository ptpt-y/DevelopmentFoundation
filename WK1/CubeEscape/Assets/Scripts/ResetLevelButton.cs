using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelButton : MonoBehaviour
{
    [SerializeField]
    KeyCode KeyReset;
    void Update()
    {
        if (Input.GetKey(KeyReset))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
