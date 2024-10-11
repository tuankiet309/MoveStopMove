using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    [SerializeField] Canvas ingameUI;
    [SerializeField] Canvas settingUI;
    [SerializeField] Canvas deadUI;
    [SerializeField] Button continueBtn;
    [SerializeField] Button restartBtn;
    [SerializeField] Button settingBtn;

    private void Start()
    {
        continueBtn.onClick.AddListener(SwitchToIngame);
        settingBtn.onClick.AddListener(SwitchToSetting);
        GameManager.Instance.onStateChange.AddListener(SwitchToDeadUI);
        SwitchToIngame();
    }
    private void SwitchToIngame()
    {
        TurnOffOtherUI();
        ingameUI.gameObject.SetActive(true);
    }
    private void SwitchToSetting()
    {
        TurnOffOtherUI();
        settingUI.gameObject.SetActive(true);
    }
    private void SwitchToDeadUI(Enum.GameState gameState)
    {
        if (gameState == Enum.GameState.Dead)
        {
            TurnOffOtherUI();
            deadUI.gameObject.SetActive(true);
        }
    }
    private void TurnOffOtherUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
