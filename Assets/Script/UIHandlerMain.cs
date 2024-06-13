using UnityEngine;
using UnityEngine.UI;

public class UIHandlerMain : MonoBehaviour
{
    public int chapterCount;

    public Text txtShowMm;
    public Text txtShowJa;
    public Text txtShowBoth;
    public Text txtDonation;

    public GameObject objScrollContent;// scroll content
    public GameObject pfbEachChapter;// prefab

    private void Awake()
    {
        ReInit();
        txtShowMm.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_TGL_SHOWMM);
        txtShowJa.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_TGL_SHOWJA);
        txtShowBoth.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_TGL_SHOWBOTH);
        txtDonation.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_DNT_DESC);

        // set up chapter list
        for (int i = 1; i <= chapterCount; i++)
        {
            GameObject obj = Instantiate(pfbEachChapter, objScrollContent.transform);
            obj.name = obj.name + "_" + i;
        }
    }

    private void ReInit()
    {
        Constants.CHAPTER_NUM = -99;
        Constants.CUR_KOTOBA_MODE = -99;
        Constants.CUR_KOTOBA_MODE = Constants.KOTOBA_MODE_SHOW_MM;
    }

    public void OnShowMmTglChanged(bool chk)
    {
        if (chk) Constants.CUR_KOTOBA_MODE = Constants.KOTOBA_MODE_SHOW_MM;
    }

    public void OnShowJaTglChanged(bool chk)
    {
        if (chk) Constants.CUR_KOTOBA_MODE = Constants.KOTOBA_MODE_SHOW_JP;
    }

    public void OnShowBhTglChanged(bool chk)
    {
        if (chk) Constants.CUR_KOTOBA_MODE = Constants.KOTOBA_MODE_SHOW_BH;
    }

}
