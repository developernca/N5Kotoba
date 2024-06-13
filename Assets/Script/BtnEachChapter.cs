using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnEachChapter : MonoBehaviour
{
    public Text txtChapterNum;// Chapter 1, 2, 3, etc
    public Text txtChapter;
    private int nameId;

    private void Start()
    {
        string[] arr = gameObject.name.Split("_");
        nameId = int.Parse(arr[1]);
        txtChapterNum.text = nameId.ToString();
        txtChapter.text = mmfont.Net.Converter.Uni2ZG(MmConstants.TXT_CHAPTER);
    }

    public void OnBtnClick()
    {
        Constants.CHAPTER_NUM = nameId;
        SceneManager.LoadScene(Constants.SN_EACH_CHAPTER);
    }
}
