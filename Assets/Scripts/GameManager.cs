using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClearText;

    [SerializeField] AudioClip gameClearSE;
    [SerializeField] AudioClip gameOverSE;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void GameOver(){
        gameOverText.SetActive(true);
        audioSource.PlayOneShot(gameOverSE);
    }
    public void GameClear(){
        gameClearText.SetActive(true);
        audioSource.PlayOneShot(gameClearSE);
    }
}
