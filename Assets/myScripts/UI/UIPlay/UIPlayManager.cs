using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIPlayManager : MonoBehaviour
{
    public static UIPlayManager instance;
    [SerializeField]
    private GameObject uiMain;
    [SerializeField]
    private GameObject uiEndGame;

    //[SerializeField]
    //private GameObject player;
    private Vector3 tempPositionCar;


    [SerializeField]
    private Button playBtn;
    [SerializeField]
    private Button homeBtn;


    public TextMeshProUGUI txtVelocity;

    public TextMeshProUGUI txtScore;
    public Text txtYourScore;


    [SerializeField]
    private int idScene;

    private int score;

    private GameObject player;

    private void Awake()
    {
        score = 0;
        UpdateScore(score);
        instance = this;
        uiEndGame.SetActive(false);

        homeBtn.onClick.AddListener(LoadHomeScene);
        playBtn.onClick.AddListener(PlayAgain);

        player = GameObject.FindWithTag("Player");

    }

    public void UpdateScore(int _score)
    {
        score += _score;
        txtScore.text = $"Score: {score}";
    }

    private void FixedUpdate()
    {
        //cap nhat toc do

        //float speed = player.GetComponent<Rigidbody>().velocity.magnitude;
        //txtVelocity.text = $"{speed} Km/h";

    }

    private void Start()
    {
        //player.GetComponent<Rigidbody>();

    }

    
    private void LoadHomeScene()
    {
        SceneManager.LoadScene("MainMenu1");
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene("Level1" + idScene);
    }


    public void SetPositionPlayer()
    {

        // player.transform.position = position;
    }

    public void EndGame()
    {
        uiEndGame.SetActive(true);
        txtYourScore.text = $"You Score: {score}";
       
    }

    
}
