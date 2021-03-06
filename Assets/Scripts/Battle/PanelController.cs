﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
  public static PanelController instance;

  public GameObject ImagePanel;
  public GameObject NamePanel;
  public GameObject TeamPanel;
  public GameObject HealthPanel;
  public TextMeshProUGUI TypeTxt;
  public TextMeshProUGUI TurnTxt;
  public GameObject TurnTeamPnl;
  public GameObject AtkPnl;
  public GameObject MvPnl;
  public GameObject AtkRngPnl;

  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    NamePanel.GetComponent<TextMeshProUGUI>().text = "";
    ImagePanel.GetComponent<Image>().enabled = false;
    TeamPanel.SetActive(false);
    HealthPanel.SetActive(false);
    AtkPnl.SetActive(false);
    MvPnl.SetActive(false);
    AtkRngPnl.SetActive(false);
    TurnTxt.text = "";
    TypeTxt.text = "";
  }

  public static void SwitchChar(UnitProxy unit)
  {
    instance.SwitchCharImages(unit);
    instance.SwitchCharName(unit);
    instance.SetTeam(unit);
    instance.SetCharHealth(unit);
    instance.SetCharAttack(unit);
    instance.SetCharMv(unit);
    instance.SetTurnText(unit);
    instance.SetTypeText(unit);
    instance.SetCharAtkRng(unit);
  }

  public void SetTurnPanel(string msg)
  { 
      TurnTeamPnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = msg;
  }

  void SwitchCharImages(UnitProxy unit)
  {
    if (unit == null)
    {
      ImagePanel.GetComponent<Image>().enabled = false;
    }
    else
    {
      Sprite img = unit.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
      ImagePanel.GetComponent<Image>().enabled = true;
      ImagePanel.GetComponent<Image>().sprite = img;
    }
  }

  void SwitchCharName(UnitProxy unit)
  {
    string txt = unit == null ? "" : unit.GetData().characterMoniker;
    NamePanel.GetComponent<TextMeshProUGUI>().text = txt;
  }

  void SetTeam(UnitProxy unit)
  {
    if (unit == null)
    {
      TeamPanel.SetActive(false);
    }
    else
    {
      TeamPanel.SetActive(true);
      // TODO: Change the outline banner here based on the faction
      TeamPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unit.GetData().GetTeam().ToString();
    }
  }

  void SetCharHealth(UnitProxy unit)
  {
    if (unit == null)
    {
      HealthPanel.SetActive(false);
      return;
    }
    HealthPanel.SetActive(true);
    HealthPanel.GetComponent<Image>().enabled = true;
    foreach (Transform t in HealthPanel.transform)
    {
      if (t.name.Equals("HealthFillBar"))
      {
        t.GetComponent<Image>().fillAmount = (float) unit.GetData().GetCurrHealth() / (float)unit.GetData().mxHlth;
      } else if (t.name.Equals("HealthText"))
      {
        t.GetComponent<TextMeshProUGUI>().text = unit.GetData().GetCurrHealth().ToString() + " / " + unit.GetData().mxHlth.ToString();
      }
    }
  }

  void SetCharAttack(UnitProxy unit)
  {
    if (unit == null)
    {
      AtkPnl.SetActive(false);
      return;
    }
    AtkPnl.SetActive(true);
    AtkPnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unit.GetData().GetAttack().ToString();
  }

  void SetCharMv(UnitProxy unit)
  {
    if (unit == null)
    {
      MvPnl.SetActive(false);
      return;
    }
    MvPnl.SetActive(true);
    MvPnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unit.GetData().GetMoveSpeed().ToString();
  }

  void SetCharAtkRng(UnitProxy unit)
  {
    if (unit == null)
    {
      AtkRngPnl.SetActive(false);
      return;
    }
    AtkRngPnl.SetActive(true);
    AtkRngPnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unit.GetData().GetAtkRange().ToString();
  }

  void SetTurnText(UnitProxy unit)
  {
    string txt = unit == null ? "" : unit.GetData().GetTurnActions().ToString();
    TurnTxt.text = txt;
  }

  void SetTypeText(UnitProxy unit)
  {
    string txt = unit == null ? "" : unit.GetData().uType.ToString();
    TypeTxt.text = txt;
  }
}