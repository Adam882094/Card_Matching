using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public const int col = 4;
    public const int row = 4;
    public const float offX = 2f;
    public const float offY = 2f;

    [SerializeField] private MemoryCard original;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPos = original.transform.position;

        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        cards = randAssign(cards);

        for (int cnt = 0; cnt < col; cnt++)
        {
            for (int cntTwo = 0; cntTwo < row; cntTwo++)
            {
                MemoryCard card;
                if (cnt == 0 && cntTwo == 0)
                {
                    card = original;
                }
                else
                {
                    card = Instantiate(original) as MemoryCard;
                }

                int index = cntTwo * col + cnt;
                int Num = cards[index];
                card.ChangeSprite(Num, images[Num]);

                float posX = (offX * cnt) + startPos.x;
                float posY = (offY * cntTwo) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
    private int[] randAssign(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int let = 0; let < newArray.Length; let++)
        {
            int tmp = newArray[let];
            int r = Random.Range(let, newArray.Length);
            newArray[let] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MemoryCard cardOne;
    private MemoryCard cardTwo;

    public bool canReveal
    {
        get { return cardTwo == null; }
    }

    public void CardRevealed(MemoryCard card)
    {
        if (cardOne == null)
        {
            cardOne = card;
        }
        else
        {
            cardTwo = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (cardOne.Num != cardTwo.Num)
        {
            yield return new WaitForSeconds(0.5f);
            cardOne.Wrong();
            cardTwo.Wrong();
        }

        cardOne = null;
        cardTwo = null;

    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
