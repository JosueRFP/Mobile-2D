using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardsColection : MonoBehaviour
{
    [SerializeField][Min(1)] int gridCardsLimit = 1;
    [SerializeField][Min(0)] int cardsAmount = 0;
    [SerializeField] GameObject card;
    [SerializeField] GameObject grid;

    [SerializeField] Button nextPage;
    [SerializeField] Button previousPage;
    GridLayoutGroup[] collectionPages;
    int pagesIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tempGrid = Instantiate(grid, transform); // no instantiate se for colocado o transform como segundo argumento será instanciado como filho do objeto
        for (int i = 0; i < cardsAmount; i++) 
        {          
            if (i % gridCardsLimit == 0 && i != 0)// não estpa otimizado o if, quando passa de 14 cria um novo grid
            {// aqui em baixo ele renova a referência utilizada pelo instantiate da carta
                tempGrid = Instantiate(grid, transform);
                tempGrid.SetActive(false);
            }
            Instantiate(card, tempGrid.transform);
        }

        collectionPages = GetComponentsInChildren<GridLayoutGroup>(true);
        ActiveUIElements();
        nextPage.onClick.AddListener(delegate
        {
            CollectionNavigate(1);
        });
        previousPage.onClick.AddListener(delegate
        {
            CollectionNavigate(-1);

        });
    }

    public void CollectionNavigate(int value)
    {
        collectionPages[pagesIndex]. gameObject.SetActive(false);

        pagesIndex += value;
            
        if (pagesIndex >= collectionPages.Length)
            pagesIndex = 0;

        if(pagesIndex < 0)
            pagesIndex = collectionPages.Length - 1;
                
        collectionPages[pagesIndex].gameObject.SetActive(true);

    }

    public void ActiveUIElements()
    {
        nextPage.gameObject.SetActive(true);
        previousPage.gameObject.SetActive(true);
    }



}
