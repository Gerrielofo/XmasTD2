using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject death;
    public GameObject victory;

    private void Update()
    {
        if(PlayerStats.player1Lives <= 0 || PlayerStats.player2Lives <= 0)
        {
            FinishGame();
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }      
    }
    public void FinishGame()
    {
        if(gameObject.layer == 10)
        {
            Debug.Log("Player 1 death");
            if(PlayerStats.player1Lives > 0)
            {
                victory.SetActive(true);
                Debug.Log("Game Won Player 1");
            }
            else
            {
                death.SetActive(true);
            }
        }
        else if(gameObject.layer == 11)
        {
            Debug.Log("Player 2 death");
            if (PlayerStats.player2Lives > 0)
            {
                victory.SetActive(true);
                Debug.Log("Game Won Player 2");
            }
            else
            {
                death.SetActive(true);
            }
        }
        
    }
    
}
