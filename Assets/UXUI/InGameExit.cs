using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameExit : MonoBehaviour
{
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
