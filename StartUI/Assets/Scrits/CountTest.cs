﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTest : MonoBehaviour
{

    public Text m_txtMain = null; // 카운트할 텍스트
    public Button m_StartBtn = null; // 시작 버튼
    public Image m_Background = null;

    private int CheckTime = 0;

    private string strStart = "";


    private void Start()
    {
        Initialize();

        m_StartBtn.onClick.AddListener(OnClicked_StartBtn);
    }


    private void Initialize()
    {
        CheckTime = 3;
        strStart = "Start";
    }

    IEnumerator EnumFunc_CountDown(float timer)
    {
        while (CheckTime > 0)
        {
            SetText();

            yield return new WaitForSeconds(timer);

            m_txtMain.rectTransform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            CheckTime--;

            yield return new WaitForSeconds(timer);
        }

        timer = 1.0f;

        m_txtMain.text = strStart;

        yield return new WaitForSeconds(timer);
        m_txtMain.gameObject.SetActive(false);

        yield return null;
    }

    private void OnClicked_StartBtn()
    {
        m_Background.gameObject.SetActive(false);

        SetText();
        m_StartBtn.gameObject.SetActive(false);
        StopAllCoroutines();
        StartCoroutine("EnumFunc_CountDown", 0.5f);
    }

    private void SetText()
    {
        m_txtMain.text = CheckTime.ToString();

        m_txtMain.rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        m_txtMain.rectTransform.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

}
