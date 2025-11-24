using UnityEngine;
using TMPro;
using System.Collections;

public class WorldText : MonoBehaviour
{
    [SerializeField] string DisplayText;

    [SerializeField] TextMeshProUGUI Text;

    [SerializeField] float lifeTime=1;

    [SerializeField] float TextFloatSpeed;
    [SerializeField] bool TextFloat=false;
    [SerializeField] bool TextFade = false;
    [SerializeField] Transform DisplayPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool started = false;

    public void SetValue(float floatSpeed, float lifetime, bool textfloat, bool textFade, Transform displaypoint)
    {
        HideText(true);
        this.lifeTime = lifetime;
        TextFloatSpeed = floatSpeed;
        TextFloat = textfloat;
        TextFade = textFade;
        DisplayPoint = displaypoint;

        this.transform.position=displaypoint.transform.position;

    }
    public void WordStart()
    {
        if(TextFloat)
        {
            TextFade = true;
        }
        if(TextFade)
        {
            StartCoroutine(FadeOut());
        }
        started = true;
        HideText(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (TextFloat)
            {
                MoveText();
            }
        }
       
    }

    public void MoveText()
    {
        transform.Translate(Vector2.up * TextFloatSpeed * Time.deltaTime);
    }

    public IEnumerator FadeOut()
    {
        float startAlpha = Text.color.a;
        float rate=1.0f/lifeTime;
        float progress = 0.0f;

        while(progress<1)
        {
            Color temp= Text.color;
            temp.a = Mathf.Lerp(startAlpha, 0,progress);

            Text.color = temp;
            progress += rate * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    public void SetText(string NewText)
    {
        Text.text = NewText;
    }

    public void HideText(bool hide)
    {
       Text.gameObject.SetActive(!hide);
    }

    public void HideTexttoggle()
    {
        Text.gameObject.SetActive(!Text.gameObject.activeInHierarchy);
    }
}
