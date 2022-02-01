using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Playbuttonclicked");
        SceneManager.LoadScene(1);
    }
}
