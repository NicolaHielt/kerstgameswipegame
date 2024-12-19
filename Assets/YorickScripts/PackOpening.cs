using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PackOpening : MonoBehaviour
{
    public List<GameObject> cardPrefabs;
    public Transform container;
    public int cardsToShow = 10;
    public float cardSpacing = 50f;
    public float rowSpacing = 150f;
    public int packsOpened = 0;
    [SerializeField] TextMeshProUGUI openedText;
    public void OpenPack()
    {
        packsOpened++;
        openedText.text = "Opened: " + packsOpened;
        ClearContainer();

        float startX = -((5 - 1) * (100f + cardSpacing)) / 2f;
        float startY = 0f;

        for (int i = 0; i < cardsToShow; i++)
        {
            int randomIndex = Random.Range(0, cardPrefabs.Count);
            GameObject selectedCardPrefab = cardPrefabs[randomIndex];
            GameObject card = Instantiate(selectedCardPrefab, container);
            card.name = $"Card_{i + 1}";
            card.SetActive(true);
            RectTransform cardTransform = card.GetComponent<RectTransform>();
            if (cardTransform != null)
            {
                int row = i / 5;
                int col = i % 5;

                float xPos = startX + col * (100f + cardSpacing);
                float yPos = startY - row * rowSpacing;

                cardTransform.anchoredPosition = new Vector2(xPos, yPos);
            }
            else
            {
                Debug.LogWarning($"Geen RectTransform gevonden op kaart prefab: {card.name}");
            }
        }

        Debug.Log($"{cardsToShow} kaarten geladen!");
    }

    private void ClearContainer()
    {
        foreach (Transform child in container)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
