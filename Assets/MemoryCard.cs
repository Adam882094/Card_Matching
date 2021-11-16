using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private GameObject backCard;
    public void OnMouseDown()
    {
        if (backCard.activeSelf && controller.canReveal)
        {
            backCard.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    private int _Num;
    public int Num
    {
        get { return _Num; }
    }

    public void ChangeSprite(int Num, Sprite image)
    {
        _Num = Num;
        GetComponent<SpriteRenderer>().sprite = image; 
    }

    public void Wrong()
    {
        backCard.SetActive(true);
    }
}
