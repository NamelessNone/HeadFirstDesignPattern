using System;
using System.Collections.Generic;

namespace C6_CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class MacroCommand : ICommand
    {
        private List<ICommand> _commands;

        public MacroCommand(IEnumerable<ICommand> commands)
        {
            _commands = new List<ICommand>();
            foreach (var command in commands)
            {
                _commands.Add(command);
            }
        }

        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            _commands.Reverse();
            foreach (var command in _commands)
            {
                command.Undo();
            }
            _commands.Reverse();
        }
    }

    public class NoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine($"NoCommand executed");
        }
        
        public void Undo(){}
    }
    
    public class LightOnCmd: ICommand
    {
        private Light _light;

        public LightOnCmd(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }
    
    public class LightOffCmd: ICommand
    {
        private Light _light;

        public LightOffCmd(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    public class GarageDoorOpenCmd : ICommand
    {
        private GarageDoor _door;

        public GarageDoorOpenCmd(GarageDoor door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Up();
        }
        
        public void Undo()
        {
            _door.Down();
        }
    }



    public class StereoOffCmd : ICommand
    {
        private Stereo _stereo;

        public StereoOffCmd(Stereo stereo)
        {
            _stereo = stereo;
        }

        public void Execute()
        {
            _stereo.Off();
        }
        
        public void Undo()
        {
            _stereo.On();
        }
    }
    
    public class StereoOnWithCdCmd : ICommand
    {
        private Stereo _stereo;

        public StereoOnWithCdCmd(Stereo stereo)
        {
            _stereo = stereo;
        }

        public void Execute()
        {
            _stereo.On();
            _stereo.SetCd();
            _stereo.SetVol(11);
        }
        
        public void Undo()
        {
            _stereo.Off();
        }
    }

    public class CeilingFanHighCmd : ICommand
    {
        private CeilingFan _ceilingFan;
        private CeilingFan.State _prevSpeed;

        public CeilingFanHighCmd(CeilingFan fan)
        {
            _ceilingFan = fan;
        }
        
        public void Execute()
        {
            _prevSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(CeilingFan.State.HIGH);
        }
        
        public void Undo()
        {
            var curSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(_prevSpeed);
            _prevSpeed = curSpeed;
        }
    }
    
    public class CeilingFanStopCmd : ICommand
    {
        private CeilingFan _ceilingFan;
        private CeilingFan.State _prevSpeed;

        public CeilingFanStopCmd(CeilingFan fan)
        {
            _ceilingFan = fan;
        }
        
        public void Execute()
        {
            _prevSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(CeilingFan.State.OFF);
        }
        
        public void Undo()
        {
            var curSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(_prevSpeed);
            _prevSpeed = curSpeed;
        }
    }
    
    public class CeilingFanMediumCmd : ICommand
    {
        private CeilingFan _ceilingFan;
        private CeilingFan.State _prevSpeed;

        public CeilingFanMediumCmd(CeilingFan fan)
        {
            _ceilingFan = fan;
        }
        
        public void Execute()
        {
            _prevSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(CeilingFan.State.MEDIUM);
        }
        
        public void Undo()
        {
            var curSpeed = _ceilingFan.CurrentSpeed;
            _ceilingFan.SetSpeed(_prevSpeed);
            _prevSpeed = curSpeed;
        }
    }
}