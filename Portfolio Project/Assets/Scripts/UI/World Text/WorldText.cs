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
    void Start()
    {
        if(TextFloat)
        {
            TextFade = true;
        }
        if(TextFade)
        {
            StartCoroutine(FadeOut());
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(TextFloat)
        {
            MoveText();
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

}
