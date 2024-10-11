using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas UIGameplay;
    [SerializeField] Canvas UIHall;
    [SerializeField] Button PlayBTN;
    [SerializeField] Button MainMenuBTN;
    private void Awake()
    {
        PlayBTN.onClick.AddListener(SwitchToGamePlayUI);
        MainMenuBTN.onClick.AddListener(SwitchToHallUI);
    }
    private void SwitchToGamePlayUI()
    {
        TurnOffUI();
        UIGameplay.gameObject.SetActive(true);
        GameManager.Instance.SetGameState(Enum.GameState.NormalPVP);
    }
    private void SwitchToHallUI()
    {
        TurnOffUI();
        UIHall.gameObject.SetActive(true);
        GameManager.Instance.SetGameState(Enum.GameState.Hall);
    }
    private void TurnOffUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
