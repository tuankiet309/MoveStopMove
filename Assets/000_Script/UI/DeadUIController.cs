using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadUIController : MonoBehaviour
{
    [SerializeField]
    string[] empathysForRhapsody;
    [SerializeField] private TextMeshProUGUI empathyText;
    [SerializeField] private TextMeshProUGUI rankedText;
    [SerializeField] private TextMeshProUGUI KillerText;
    [SerializeField] private Button continueBtn;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private RectTransform reviveHolder;
    [SerializeField] private Button reviveButton;
    private float originalSize;
    private void Start()
    {
        rankedText.text = (EnemySpawner.Instance.NumberOfEnemyLeft +1).ToString();
        KillerText.text = Player.Instance.GetComponent<LifeComponent>().KillerName;
        int score = Player.Instance.GetComponent<ActorInfomationController>().Score;
        int randomEmpathy = Random.Range(0,empathysForRhapsody.Length);
        empathyText.text = empathysForRhapsody[randomEmpathy];
        originalSize = reviveHolder.sizeDelta.x;
        if(score < 5)
        {
            gold.text = "0";
            reviveHolder.sizeDelta = new Vector2(reviveHolder.sizeDelta.x / 3, reviveHolder.sizeDelta.y);
            reviveButton.gameObject.SetActive(false);
        }
        else
        {
            gold.text = score.ToString();
            reviveHolder.sizeDelta = new Vector2(originalSize, reviveHolder.sizeDelta.y);
            reviveButton.gameObject.SetActive(true);
        }
        continueBtn.onClick.AddListener(OnContinueClick);
    }
    private void OnContinueClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
