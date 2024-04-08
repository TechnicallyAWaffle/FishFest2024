using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject guide;

    public GameObject comicPage1;
    public GameObject comicPage2;
    public GameObject comicPage3;
    public GameObject comicPage4;
    public GameObject comicPage5;
    public GameObject comicPage6;

    public GameObject comicPage2_1;
    public GameObject comicPage2_2;
    public GameObject comicPage2_3;
    public GameObject comicPage2_4;
    public GameObject comicPage2_5;
    public GameObject comicPage2_6;

    private int count = 0;

    public void NextScene()
    {
        switch (count)
        {
            case 0:
                guide.SetActive(false);
                comicPage1.SetActive(true);
                break;
            case 1:
                comicPage2.SetActive(true);
                break;
            case 2:
                comicPage3.SetActive(true);
                break;
            case 3:
                comicPage4.SetActive(true);
                break;
            case 4:
                comicPage5.SetActive(true);
                break;
            case 5:
                comicPage6.SetActive(true);
                break;
            case 6:
                comicPage1.SetActive(false);
                comicPage2.SetActive(false);
                comicPage3.SetActive(false);
                comicPage4.SetActive(false);
                comicPage5.SetActive(false);
                comicPage6.SetActive(false);

                comicPage2_1.SetActive(true);
                break;
            case 7:
                comicPage2_2.SetActive(true);
                break;
            case 8:
                comicPage2_3.SetActive(true);
                break;
            case 9:
                comicPage2_4.SetActive(true);
                break;
            case 10:
                comicPage2_5.SetActive(true);
                break;
            case 11:
                comicPage2_6.SetActive(true);
                break;
            case 12:
                Player.Instance.introManager = null;
                SceneManager.LoadScene(1);
                break;
        }
        ++count;
    }
}
