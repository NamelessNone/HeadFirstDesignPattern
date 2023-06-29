using System;

namespace C6_CommandPattern
{
    public interface IReceiver
    {
        
    }
    
    public class Light: IReceiver
    {
        public void On()
        {
            Console.WriteLine($"Light is On");
        }

        public void Off()
        {
            Console.WriteLine($"Light is Off");
        }
    }

    public class GarageDoor : IReceiver
    {
        public void Up()
        {
            Console.WriteLine($"Garage door is opening");
        }
        
        public void Down(){ Console.WriteLine($"Garage door is closing");}
        public void Stop(){ Console.WriteLine($"Garage door has stopped moving");}
        public void LightOn(){ Console.WriteLine($"Garage light is on");}
        public void LightOff(){ Console.WriteLine($"Garage light is off");}
    }

    public class Stereo : IReceiver
    {
        public void On(){}
        public void Off(){}
        public void SetCd(){}
        public void SetDvd(){}
        public void SetRadio(){}
        public void SetVol(int vol){}
    }

    public class CeilingFan : IReceiver
    {
        public enum State
        {
            HIGH=3,
            MEDIUM=2,
            LOW=1,
            OFF=0,
        }
    
        private string _location;
        private State _speed;

        public CeilingFan(string position)
        {
            _location = position;
        }
        
        public void SetSpeed(State speed)
        {
            _speed = speed;
        }

        public State CurrentSpeed => _speed;
    }
}