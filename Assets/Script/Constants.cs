using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // Scene Names
    public static string SN_EACH_CHAPTER = "EachChapterScene";

    // Kotoba mode
    public const int KOTOBA_MODE_SHOW_MM = 1;
    public const int KOTOBA_MODE_SHOW_JP = 2;
    public const int KOTOBA_MODE_SHOW_BH = 3;


    public static int CHAPTER_NUM = -99;// use for json chapter file name chapt1, chapt2, etc
    public static int CUR_KOTOBA_MODE = -99;// Current kotoba mode

}
