using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.CommandPattern
{
    /// <summary>
    /// Invoker - Simple remote control that executes commands
    /// </summary>
    public class RemoteControl
    {
        private ICommand _command;
        private Stack<ICommand> _undoStack;

        public RemoteControl()
        {
            _undoStack = new Stack<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command.Execute();
            _undoStack.Push(_command);
        }

        public void PressUndo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("⚠️ Nothing to undo!");
            }
        }
    }
}