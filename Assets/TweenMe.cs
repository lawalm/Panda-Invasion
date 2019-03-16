using UnityEngine;
using System.Collections;

public class TweenMe : MonoBehaviour
{
    private Animator fadeImgAnim;

    // Start is called before the first frame update
    void Start()
    {
        fadeImgAnim = GetComponent<Animator>();

        StartCoroutine(FadeInAnim());
    }

    private void FadeInAnimation()
    {
        fadeImgAnim.Play("testIn");
    }

    public void FadeOutAnimation()
    {
        fadeImgAnim.Play("FadeOut");
    }

    IEnumerator FadeInAnim()
    {
        fadeImgAnim.Play("testIn");
        yield return new WaitForSeconds(1f);
        //FadeOutAnimation();

    }

   
}
