using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameObject player;


    private string playerName;
    private Sprite playerSprite;
    private RuntimeAnimatorController animController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null) return null;
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitPlayerSetting(Sprite playerSprite, string playerName, RuntimeAnimatorController animController)
    {
        this.playerName = playerName;
        this.playerSprite   = playerSprite;
        this.animController = animController;

        SceneManager.sceneLoaded += LoadMainScene;

        SceneManager.LoadScene("MainScene");
    }

    private void LoadMainScene(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player");

        if (player != null)
        {
            player.GetComponent<PlayerStatus>().playerName = playerName;
            player.GetComponent<SpriteRenderer>().sprite = playerSprite;
            player.GetComponent<PlayerAnim>().SetAnimByCharacter(animController);
        }
    }
}
