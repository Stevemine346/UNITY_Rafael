using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else 
        {
            Destroy(gameObject);
        }     
    }

    public void GameOver()
    {
        SceneManager.LoadScene("DemoGameOver");
    }

    public void YouWin()
    {
        SceneManager.LoadScene("Winner");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
