using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        // Debug.Log("CompleteLevel");
        completeLevelUI.SetActive(true);
    }
}
