using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilRigComponentChecker : MonoBehaviour
{

    public static bool timeToCheck = true;
    public static int badTries = 0;
    public string correctOrder = "";
    public Text[] textFields;
    public GameObject endScreen;

    private ClickRemove[] pieces;
    // Start is called before the first frame update
    void Start()
    {

        pieces = GetComponentsInChildren<ClickRemove>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timeToCheck)
        {
            bool removed = true;
            foreach (ClickRemove currentPiece in pieces)
            {
                if (!currentPiece.removed)
                {
                    removed = false;
                }
            }

            if (removed)
            {
                //do something
                string congratz = "Congragulations! You managed to solve the correct order!";
                string mistakes = "";
                if (badTries == 0)
                {
                    mistakes = "WOW! You made no mistakes with this run through!";
                }
                else if (badTries == 1)
                {
                    mistakes = "You made " + badTries + " mistake, try run through it again to get that down to 0!";
                }
                else
                {
                    mistakes = "You made " + badTries + " mistakes, try run through it again to get that down!";
                }
                string order = "The correct order for the pieces are " + correctOrder;

                endScreen.SetActive(true);

                textFields[0].text = congratz;
                textFields[1].text = mistakes;
                textFields[2].text = order;


            }


            timeToCheck = false;

        }
    }

    private List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }
}
