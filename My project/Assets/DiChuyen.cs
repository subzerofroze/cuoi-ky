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

    private bool timesArray = false;

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

        char1.EncounterAnimation();
        char2.EncounterAnimation();
        char3.EncounterAnimation();
        char4.EncounterAnimation();
        char5.EncounterAnimation();

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
        timesArray = true;
    }


    public int Ranking(MonoBehaviour character)
    {
        if (timesArray)
        {
            float finishTime = 0;

            // Kiểm tra nếu đối tượng là Char1 thì gọi FinishTime
            if (character is Char1 char1Instance)
            {
                finishTime = char1Instance.FinishTime();
                if (finishTimes[0] == finishTime)
                {
                    return 1;
                }
                //return 0;
            }
            // Kiểm tra nếu đối tượng là Char2 thì gọi FinishTime
            else if (character is Char2 char2Instance)
            {
                finishTime = char2Instance.FinishTime();
                if (finishTimes[0] == finishTime)
                {
                    return 1;
                }
                //return 0;
            }
            else if (character is Char3 char3Instance)
            {
                finishTime = char3Instance.FinishTime();
                if (finishTimes[0] == finishTime)
                {
                    return 1;
                }
                //return 0;
            }
            else if (character is Char4 char4Instance)
            {
                finishTime = char4Instance.FinishTime();
                if (finishTimes[0] == finishTime)
                {
                    return 1;
                }
                //return 0;
            }
            else if (character is Char5 char5Instance)
            {
                finishTime = char5Instance.FinishTime();
                if (finishTimes[0] == finishTime)
                {
                    return 1;
                }
                //return 0;
            }
        }
        return 0;
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
        if(timesArray)
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
}
