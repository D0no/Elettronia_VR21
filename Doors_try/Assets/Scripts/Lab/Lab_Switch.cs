using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_Switch : Interactable

  
{
    public Animator LabSwitch;
    public Animator LabCurrent;
    public Animator LabResistor;
    public Animator LabVoltage;
    private int State;

    public override void Interact(GameObject caller)
    {
       if (State == 0) 
        {
            //prima animazione
            LabSwitch.SetInteger("Lab_Switch", 1);
            LabVoltage.SetInteger("Lab_Voltage", 1);
            LabCurrent.SetInteger("Lab_Current", 1);

            State = 1;
        }


      else if (State == 1) 
        {
            //seconda animazione
            LabSwitch.SetInteger("Lab_Switch", 2);
            LabResistor.SetInteger("Lab_Res", 1);
            //LabVoltage.SetInteger("Lab_Voltage", 2);
            LabCurrent.SetInteger("Lab_Current", 2);

            State = 2;
        }

      else if (State == 2)
        {
            //terza animazione
            LabSwitch.SetInteger("Lab_Switch", 3);
            LabResistor.SetInteger("Lab_Res", 2);
            //LabVoltage.SetInteger("Lab_Voltage", 3);
            LabCurrent.SetInteger("Lab_Current", 3);

            State = 3;

        }

       else if (State == 3)
        {
            //reset 
            LabSwitch.SetInteger("Lab_Switch", 4);
            LabResistor.SetInteger("Lab_Res", 3);
            LabVoltage.SetInteger("Lab_Voltage", 2);
            LabCurrent.SetInteger("Lab_Current", 4);

            State = 0;

        }

       else
        {
            State = 0;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        State = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


}
