using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEnd : MonoBehaviour
{
    [SerializeField] Sprite FiredEnding;
    [SerializeField] Sprite SuccessEnding;
    [SerializeField] Sprite NicePersonEnding;
    [SerializeField] Sprite SlackerEnding;
    [SerializeField] Sprite HighEQEnding;

    public TMP_Text SlackerCaughtText;
    public TMP_Text FalseAlarmText;
    public TMP_Text VIPText;

    public TMP_Text title;
    public Image endingImage;

    public string FiredTitle;
    public string SuccessTitle;
    public string NicePersonTitle;
    public string SlackerTitle;
    public string HighEQTitle;

    public GameObject StatPanel;
    public GameObject EndingPanel;

    private Sound soundToPlay;
    public Sound successSound;
    public Sound neutralSound;

    void Update()
    {
        if (StatPanel.activeSelf == true)
        {
            //if mouse is clicked, close the stat panel and open ending panel
            if (Input.GetMouseButtonDown(0))
            {
                StatPanel.SetActive(false);
                EndingPanel.SetActive(true);
            }
        }
    }
    public void ShowEnding(Result GameEndResult)
    {

        StatPanel.SetActive(true);
        this.gameObject.SetActive(true);
        switch (GameEndResult)
        {
            case Result.Failure:
                title.text = FiredTitle;
                endingImage.sprite = FiredEnding;
                soundToPlay = neutralSound;
                break;
            case Result.GoodGuesser:
                title.text = SuccessTitle;
                endingImage.sprite = SuccessEnding;
                soundToPlay = successSound;
                break;
            case Result.NicePerson:
                title.text = NicePersonTitle;
                endingImage.sprite = NicePersonEnding;
                soundToPlay = successSound;
                break;
            case Result.Slacker:
                title.text = SlackerTitle;
                endingImage.sprite = SlackerEnding;
                soundToPlay = neutralSound;
                break;
        }

        string slackerCaught = "在良心有限公司员工们的" + LevelManager.Instance.TotalSlacker + "次摸鱼尝试中，你成功捉到了" + PlayerState.Instance.TotalCorrectCatch + "次摸鱼行为。";

        SlackerCaughtText.text = slackerCaught;

        string falseAlarmComment;
        if (PlayerState.Instance.TotalFalseAlarm == 0)
        {
            falseAlarmComment = "你没有任何误报，没有员工因为你的错误被解雇。";
        }
        else
        {
            falseAlarmComment = "你有" + PlayerState.Instance.TotalFalseAlarm + "次的误报摸鱼行为，虽然偶尔有人不满，但为了提升公司的产出，我们宁可杀错也不能放过任何摸鱼员工。";
        }
        FalseAlarmText.text = falseAlarmComment;

        string VIPComment;

        if (PlayerState.Instance.CaughtBossKid)
        {
            VIPComment = "你可能没有发现，你举报的最后一名摸鱼员工是公司老板的孩子。希望不会有什么不好的事情发生。";
        }
        else
        {
            VIPComment = "你或许已经发现了老板的儿子。你从来没有举报过他的摸鱼行为，这是你的智慧还是你的运气？";
        }

        VIPText.text = VIPComment;

    }
}
