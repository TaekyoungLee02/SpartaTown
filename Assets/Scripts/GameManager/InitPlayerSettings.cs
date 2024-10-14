using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class InitPlayerSettings : MonoBehaviour
{
    [SerializeField] private List<Sprite> playerSprites;
    [SerializeField] private List<Button> spriteButtons;
    [SerializeField] private List<AnimatorController> animControllers;
    [SerializeField] private GameObject selectCharacterBoard;
    [SerializeField] private Button spriteSelectButton;
    [SerializeField] private Button submitButton;
    [SerializeField] private Image selectedSprite;
    [SerializeField] private TextMeshProUGUI playerName;

    private AnimatorController animController;

    private void Awake()
    {
        for(int i = 0; i < spriteButtons.Count; i++)
        {
            int temp = i;
            spriteButtons[i].onClick.AddListener(() => SelectSprite(temp));
        }

        spriteSelectButton.onClick.AddListener(() => OpenSpriteSelectBoard());
        submitButton.onClick.AddListener(() => SubmitPlayerSetting());
    }

    private void SubmitPlayerSetting()
    {
        if(playerName.text == "") return;

        GameManager.Instance.InitPlayerSetting(selectedSprite.sprite, playerName.text, animController);
    }

    private void OpenSpriteSelectBoard()
    {
        selectCharacterBoard.SetActive(true);
    }

    private void SelectSprite(int index)
    {
        selectedSprite.sprite = playerSprites[index];
        selectCharacterBoard.SetActive(false);
        animController = animControllers[index];

        if (index == 0) selectedSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        else selectedSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
    }
}
