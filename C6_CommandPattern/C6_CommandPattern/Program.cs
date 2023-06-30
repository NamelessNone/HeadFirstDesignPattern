using System;

namespace C6_CommandPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RemoteControl7();
        }

        public static void SimpleRemoteControl()
        {
            //client code
            SimpleRemoteControl invoker = new SimpleRemoteControl();
            Light reciever = new Light();
            LightOnCmd lightOn = new LightOnCmd(reciever);

            GarageDoor garageDoor = new GarageDoor();
            GarageDoorOpenCmd garageDoorOpenCmd = new GarageDoorOpenCmd(garageDoor);
            
            invoker.SetCmd(lightOn);
            invoker.BtnPressed();
            invoker.SetCmd(garageDoorOpenCmd);
            invoker.BtnPressed();
        }

        public static void RemoteControl7()
        {
            RemoteControl7 invoker = new RemoteControl7();
            CeilingFan fan = new CeilingFan("LivingRoom");
            CeilingFanHighCmd ceilingFanHighCmd = new CeilingFanHighCmd(fan);
            CeilingFanMediumCmd ceilingFanMediumCmd = new CeilingFanMediumCmd(fan);
            CeilingFanStopCmd ceilingFanStopCmd = new CeilingFanStopCmd(fan);
            
            invoker.SetCommand(0,ceilingFanHighCmd, ceilingFanStopCmd);
            invoker.SetCommand(1, ceilingFanMediumCmd, ceilingFanStopCmd);
            
            invoker.BtnOnPressed(0);
            invoker.BtnOffPressed(0);
            Console.WriteLine(invoker);
            invoker.BtnUndoPressed();
            
            invoker.BtnOnPressed(1);
            Console.WriteLine(invoker);
            invoker.BtnUndoPressed();
            
        }
    }
}