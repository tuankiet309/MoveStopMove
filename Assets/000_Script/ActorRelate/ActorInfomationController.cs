using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class ActorInfomationController : MonoBehaviour
{
    //Danh sach bien luu tru thong tin se duoc gan theo CONSTANT
    private int score;
    private int scoreMilestone;
    private int scoreMilestoneIncreaser;
    private float bodyScalerIncreaser;

    //Cac component can thiet de giao tiep voi script nay
    [SerializeField] DetectionCircle circle;
    [SerializeField] ActorAttacker attacker;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] RectTransform visuallizeCircle;
    [SerializeField] Transform playerVisualize;
    [SerializeField] bool isPlayer;

    public int Score { get => score; private set { } }

    private void Awake()
    {
        scoreMilestone = CONSTANT_VALUE.FIRST_SCORE_MILESTONE;
        scoreMilestoneIncreaser = CONSTANT_VALUE.SCORE_MILESTONE_INCREASER;
        bodyScalerIncreaser = CONSTANT_VALUE.BODY_SCALER_INCREASER;
    }
    private void OnEnable()
    {
        if(attacker != null) 
        attacker.onKillSomeone.AddListener(UpdateStatus);
    }
    private void OnDisable()
    {
        if (attacker != null)
            attacker.onKillSomeone.RemoveListener(UpdateStatus);
    }
    private void Start()
    {
       
        if(isPlayer )
            visuallizeCircle.sizeDelta = new Vector2(circle.CircleRadius * 2, circle.CircleRadius * 2);
    }
    private void UpdateStatus()
    {
        score++;
        CheckForUpgrade();
        scoreText.text = score.ToString();
    }


    //Kiem tra co du to chat de duoc nang cap
    private void CheckForUpgrade()
    {
        if (score >= scoreMilestone)
        {
            playerVisualize.localScale += new Vector3(bodyScalerIncreaser,bodyScalerIncreaser,bodyScalerIncreaser);
            circle.UpdateCircleRadius();
            scoreMilestone += scoreMilestoneIncreaser;
            scoreMilestoneIncreaser += 1;
            if (isPlayer)
                visuallizeCircle.sizeDelta = new Vector2(circle.CircleRadius * 2, circle.CircleRadius * 2);
        }
    }

    //Gan ten aka dung cho enemy
    public void UpdateName(string name)
    {
        nameText.text = name;
    }

    internal string GetName()
    {
        return nameText.text;
    }
}
