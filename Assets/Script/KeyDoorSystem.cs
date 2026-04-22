using UnityEngine;

public class KeyDoorSystem : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject WinCanvas,LoseCanvas;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Enemie"))
        {
            LoseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject.gameObject);
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            if (hasKey)
            {
                Destroy(collision.gameObject.gameObject);
                WinCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Mainmenu(){
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
