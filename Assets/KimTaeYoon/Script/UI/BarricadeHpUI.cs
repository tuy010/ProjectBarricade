using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarricadeHpUI : MonoBehaviour
{
    [SerializeField]
    private Barricade barricade;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private Canvas canvas;

    void Update()
    {
        Vector3 tmp;
        tmp = Camera.main.WorldToScreenPoint(barricade.transform.position + new Vector3(0, 0f, 0));

        if (tmp.z < 0)
        {
            if (canvas.gameObject.activeSelf) canvas.gameObject.SetActive(false);
        }
        else
        {
            if (!canvas.gameObject.activeSelf) canvas.gameObject.SetActive(true);
            rectTransform.position = tmp;
        }
        text.text = barricade.GetHp() + " / " + barricade.GetMaxHp();
    }

    public void InitUI(Barricade b)
    {
        barricade = b;
    }
}
