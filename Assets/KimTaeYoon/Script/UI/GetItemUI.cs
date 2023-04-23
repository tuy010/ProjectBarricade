using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetItemUI : MonoBehaviour
{
    [Title("UI")]
    [SerializeField] private Image bg;
    [SerializeField] private TextMeshProUGUI text;
    [Title("Changes")]
    [SerializeField] private float moveDis;
    [SerializeField] private float moveTime;
    //[SerializeField] private float alphaChance;
    private float timer;
    private float bgAlpha;
    private float textAlpha;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        bgAlpha = bg.color.a;
        textAlpha = text.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        bg.rectTransform.position += new Vector3(0, moveDis / moveTime * Time.deltaTime, 0);
        bg.color -= new Color(0,0,0, bgAlpha / moveTime * Time.deltaTime);
        text.color -= new Color(0, 0, 0, textAlpha / moveTime * Time.deltaTime);

        if(timer >= moveTime)
        {
            Destroy(gameObject);
        }
    }

    public TextMeshProUGUI GetText() => text;
}
