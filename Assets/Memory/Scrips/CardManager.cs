using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    int selectCount = 0;
    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    List<MemoryMove> cards;

    List<MemoryMove> moves = new List<MemoryMove>();

    void Start()
    {
        cards = GetComponentsInChildren<MemoryMove>().ToList<MemoryMove>();

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].FlipCard();
        }
    }

    public void SelectCard(MemoryMove card)
    {
        switch(selectCount)
        {
            case 0:
                card.ShowFront();
                selectCount++;
                moves.Add(card);
                    break;
            case 1:
                card.ShowFront();
                selectCount++;
                moves.Add(card);
                StartCoroutine(ResolveCards());
            break;
        }
    }

    IEnumerator ResolveCards()
    {
        if (moves[0].cardName == moves[1].cardName)
        {
            yield return new WaitForSeconds(1);
            foreach (MemoryMove move in moves)
            {
                cards.Remove(move);
                Destroy(move.gameObject);
            }

            if(cards.Count == 0) {
                particle.Play();
                yield return new WaitForSeconds(2);
                GameObject.Find("DontDestroy").GetComponent<DontDestroy>().LoadScene("Kerstboom", 2);
            }
            
            
        }
        else if(moves[0].cardName != moves[1].cardName)
        {
            yield return new WaitForSeconds(2);
            foreach (MemoryMove move in moves)
            {
                move.ShowBack();
            }

        }
        moves.Clear();
        selectCount = 0;
        yield return new WaitForSeconds(.1f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
