using System;
using System.Collections.Generic;
using System.Text;

namespace C6_CommandPattern
{
    public class Invokers
    {
        
    }
    
    //只有一个按钮的遥控器
    public class SimpleRemoteControl
    {
        private ICommand slot;

        public SimpleRemoteControl()
        {
            
        }

        public void SetCmd(ICommand cmd)
        {
            slot = cmd;
        }

        public void BtnPressed()
        {
            slot.Execute();
        }
    }


    // control with 7sets of On/Off buttons
    public class RemoteControl7
    {
        private List<ICommand> _onCommands;
        private List<ICommand> _offCommands;
        private ICommand _lastCommand;

        public RemoteControl7()
        {
            _onCommands = new List<ICommand>();
            _offCommands = new List<ICommand>();
            ICommand noCmd = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                _onCommands.Add(noCmd);
                _offCommands.Add(noCmd);
            }

            _lastCommand = noCmd;
        }

        public void SetCommand(int slot, ICommand onCmd, ICommand offCmd)
        {
            if (slot < 0 || slot > 6)
            {
                Console.WriteLine($"slot {slot} not supported");
                return;
            }

            _onCommands[slot] = onCmd;
            _offCommands[slot] = offCmd;
        }

        public void BtnOnPressed(int slot)
        {
            _onCommands[slot].Execute();
            _lastCommand = _onCommands[slot];
        }

        public void BtnOffPressed(int slot)
        {
            _offCommands[slot].Execute();
            _lastCommand = _offCommands[slot];
        }

        public void BtnUndoPressed()
        {
            _lastCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"==== Remote Control ====\n");
            for (int i = 0; i < _onCommands.Count; i++)
            {
                sb.Append($"[slot {i}] {_onCommands[i].GetType().Name} {_offCommands[i].GetType().Name}\n");
            }

            return sb.ToString();
        }
    }
}