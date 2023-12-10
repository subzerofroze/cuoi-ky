using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiChuyen : MonoBehaviour
{
    public Char1 char1;
    public Char2 char2;
    public Char3 char3;
    public Char4 char4;
    public Char5 char5;

    public Text addtext;

    public float[] finishTimes;

    // Start is called before the first frame update
    void Start()
    {
        char1 = GameObject.FindGameObjectWithTag("Char1").GetComponent<Char1>();
        char2 = GameObject.FindGameObjectWithTag("Char2").GetComponent<Char2>();
        char3 = GameObject.FindGameObjectWithTag("Char3").GetComponent<Char3>();
        char4 = GameObject.FindGameObjectWithTag("Char4").GetComponent<Char4>();
        char5 = GameObject.FindGameObjectWithTag("Char5").GetComponent<Char5>();

    }

    // Update is called once per frame
    void Update()
    {
        TimesArray();

        Finalranking();
    }

    void TimesArray()
    {
        // Khởi tạo mảng với 5 phần tử
        finishTimes = new float[5];

        finishTimes[0] = char1.FinishTime();
        finishTimes[1] = char2.FinishTime();
        finishTimes[2] = char3.FinishTime();
        finishTimes[3] = char4.FinishTime();
        finishTimes[4] = char5.FinishTime();

        // Sắp xếp mảng tăng dần
        System.Array.Sort(finishTimes);

    }

   
    /*
    public void CurrentRanking()
    {
        //Vị trí thứ nhất theo thời gian
        if (finishTimes[0] == char1.CurrentPosition())
        {
            addtext.text = char1.GetName() + " is in 1st place";
        }
        if (finishTimes[0] == char2.CurrentPosition())
        {
            addtext.text = char2.GetName() + " is in 1st place";
        }
        if (finishTimes[0] == char3.CurrentPosition())
        {
            addtext.text = char3.GetName() + " is in 1st place";
        }
        if (finishTimes[0] == char4.CurrentPosition())
        {
            addtext.text = char4.GetName() + " is in 1st place  ";
        }
        if (finishTimes[0] == char5.CurrentPosition())
        {
            addtext.text = char5.GetName() + " is in 1st place";
        }
    }
    */

    [ContextMenu("Add Text")]
    public void Finalranking()
    {
        //Vị trí thứ nhất
        if (finishTimes[0] == char1.FinishTime())
        {
            addtext.text = char1.GetName() + " finished in 1st place in " + char1.FinishTime().ToString() + " s";
        }
        if (finishTimes[0] == char2.FinishTime())
        {
            addtext.text = char2.GetName() + " finished in 1st place in " + char2.FinishTime().ToString() + " s";
        }
        if (finishTimes[0] == char3.FinishTime())
        {
            addtext.text = char3.GetName() + " finished in 1st place in " + char3.FinishTime().ToString() + " s";
        }
        if (finishTimes[0] == char4.FinishTime())
        {
            addtext.text = char4.GetName() + " finished in 1st place in " + char4.FinishTime().ToString() + " s";
        }
        if (finishTimes[0] == char5.FinishTime())
        {
            addtext.text = char5.GetName() + " finished in 1st place in " + char5.FinishTime().ToString() + " s";
        }

        //Vị trí thứ hai
        if (finishTimes[1] == char1.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char1.GetName() + " finished in 2nd place in " + char1.FinishTime().ToString() + " s");
        }
        if (finishTimes[1] == char2.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char2.GetName() + " finished in 2nd place in " + char2.FinishTime().ToString() + " s");
        }
        if (finishTimes[1] == char3.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char3.GetName() + " finished in 2nd place in " + char3.FinishTime().ToString() + " s");
        }
        if (finishTimes[1] == char4.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char4.GetName() + " finished in 2nd place in " + char4.FinishTime().ToString() + " s");
        }
        if (finishTimes[1] == char5.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char5.GetName() + " finished in 2nd place in " + char5.FinishTime().ToString() + " s");
        }

        //Vị trí thứ ba
        if (finishTimes[2] == char1.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char1.GetName() + " finished in 3rd place in " + char1.FinishTime().ToString() + " s");
        }
        if (finishTimes[2] == char2.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char2.GetName() + " finished in 3rd place in " + char2.FinishTime().ToString() + " s");
        }
        if (finishTimes[2] == char3.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char3.GetName() + " finished in 3rd place in " + char3.FinishTime().ToString() + " s");
        }
        if (finishTimes[2] == char4.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char4.GetName() + " finished in 3rd place in " + char4.FinishTime().ToString() + " s");
        }
        if (finishTimes[2] == char5.FinishTime())
        {
            addtext.text = addtext.text + "\n" + (char5.GetName() + " finished in 3rd place in " + char5.FinishTime().ToString() + " s");
        }
    }

}
