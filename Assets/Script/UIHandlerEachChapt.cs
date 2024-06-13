using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandlerEachChapt : MonoBehaviour
{
    public Button btnPrev;// <<
    public Button btnShowBoth;
    public Button btnNxt;// >>

    public Text txtShowBoth;
    public Text txtKanaTitle;
    public Text txtKana;
    public Text txtKanjiTitle;
    public Text txtKanji;
    public Text txtRemarkTitle;
    public Text txtRemark;
    public Text txtMmMeaning;

    public GameObject panelCover;

    private KotobaList kotobaList;
    private int kotobaIndex = 0;
    private int kotobaLastIndex = 0;
    private bool isShowBothClicked = false;

    private void Awake()
    {
        InitData();
        InitKotobaMode();
        txtShowBoth.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_SHOW_BOTH);
        txtKanaTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_SPELLING);
        txtKanjiTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_KANJI);
        txtRemarkTitle.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_OTHER);
    }

    private void InitData()
    {
        kotobaList = JsonUtility.FromJson<KotobaList>(Resources.Load<TextAsset>("JSON/chapter" + Constants.CHAPTER_NUM).text);
        kotobaLastIndex = kotobaList.kotoba.Count - 1;
        ShowData();
    }

    private void InitKotobaMode()
    {
        if (Constants.CUR_KOTOBA_MODE == Constants.KOTOBA_MODE_SHOW_MM)
        {
            // hide Japanese
            ToggleJapanese(false);
        }
        else if (Constants.CUR_KOTOBA_MODE == Constants.KOTOBA_MODE_SHOW_JP)
        {
            // hide Myanmar
            ToggleMyanmar(false);
        }
        else
        {
            // hide [ShowBothButton] 
            btnShowBoth.gameObject.SetActive(false);
        }
    }

    private void ToggleJapanese(bool b)
    {
        txtKanaTitle.gameObject.SetActive(b);
        txtKana.gameObject.SetActive(b);
        txtKanjiTitle.gameObject.SetActive(b);
        txtKanji.gameObject.SetActive(b);
        txtRemarkTitle.gameObject.SetActive(b);
        txtRemark.gameObject.SetActive(b);
    }

    private void ToggleMyanmar(bool b)
    {
        txtMmMeaning.gameObject.SetActive(b);
    }

    private void ShowData()
    {
        txtKana.text = kotobaList.kotoba[kotobaIndex].kana;
        txtKanji.text = kotobaList.kotoba[kotobaIndex].kanji;
        txtRemark.text = kotobaList.kotoba[kotobaIndex].remark;
        txtMmMeaning.text = mmfont.Net.Converter.Uni2ZG(kotobaList.kotoba[kotobaIndex].meaning);
    }

    public void OnBtnPrevClick()// <<
    {
        if (Constants.CUR_KOTOBA_MODE != Constants.KOTOBA_MODE_SHOW_BH) btnShowBoth.gameObject.SetActive(true);
        if (isShowBothClicked)
        {
            isShowBothClicked = false;
            InitKotobaMode();// re-init
        }
        kotobaIndex = --kotobaIndex < 0 ? 0 : kotobaIndex;
        ShowData();
    }

    public void OnBtnShowBothClick()
    {
        isShowBothClicked = true;
        ToggleJapanese(true);
        ToggleMyanmar(true);
        btnShowBoth.gameObject.SetActive(false);
    }

    public void OnBtnNxtClick()// >>
    {
        if (Constants.CUR_KOTOBA_MODE != Constants.KOTOBA_MODE_SHOW_BH) btnShowBoth.gameObject.SetActive(true);
        if (isShowBothClicked)
        {
            isShowBothClicked = false;
            InitKotobaMode();// re-init
        }
        kotobaIndex = ++kotobaIndex > kotobaLastIndex ? kotobaLastIndex : kotobaIndex;
        ShowData();
    }

    public void OnBtnCloseClick()
    {
        panelCover.SetActive(true);
        SceneManager.LoadScene(0);
    }

    [System.Serializable]
    private class KotobaList
    {
        public List<Kotoba> kotoba;
    }
}
