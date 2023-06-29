namespace C6_CommandPattern
{
    internal class Program
    {
        public static void Main(string[] args)
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
    }
}