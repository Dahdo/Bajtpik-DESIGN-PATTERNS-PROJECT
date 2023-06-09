﻿using Project4_Strategy;
using Project5_Memento;
using System.Transactions;

namespace Project4_Command {
    //Singleton class
    public class Invoker {
        private static Queue<ICommand>? CommandQueue;
        private static List<string>? Arguments;
        private static Context context = new Context();
        private static IStrategy strategy;
        private static Stack<IMemento> UndoMementoStack = new Stack<IMemento>();
        private static Stack<IMemento> RedoMementoStack = new Stack<IMemento>();
        private static Stack<ICommand> UndoCommandStack = new Stack<ICommand>();
        private static Stack<ICommand> RedoCommandStack = new Stack<ICommand>();
        private static IMemento CurrentState;
        private static ICommand CurrentCommand;

        private Invoker() {}

        public static void AddArguments(List<string> args) {
            Invoker.Arguments = new List<string>(args);
        }

        public static void Log(ICommand command) {
            if(CommandQueue == null) {
                Invoker.CommandQueue = new Queue<ICommand>();
            }
            CommandQueue.Enqueue(command); //for history and export, load
            if(command.GetType() == typeof(EditCommand) || command.GetType() == typeof(DeleteCommand)
                || command.GetType() == typeof(AddCommand)) {
                Invoker.Backup(CurrentCommand);
            }
        }

        public static void History() {
            if (Invoker.CommandQueue == null)
                return;
            int count = 0;
            foreach(var command in CommandQueue) {
                Console.WriteLine($"-------------------------{count++}-----------------------");
                Console.WriteLine(command.ToString());
            }
        }

        public static void Export() {
            try {
                if (Invoker.Arguments?.Count > 1 && Invoker.Arguments[1].ToLower() == "plaintext")
                    Invoker.context.SetStrategy(new TXTExporter(Invoker.Arguments[0], CommandQueue));
                else
                    Invoker.context.SetStrategy(new XMLExporter(Invoker.Arguments[0]));
            }catch (Exception e) {
                Console.WriteLine($"Error: [{e.Message}]");
            }
            Invoker.context.DoStrategy();
        }

        public static void Load() {
            try {
                if (Invoker.Arguments?.Count != 0)
                    Invoker.context.SetStrategy(new TXTLoader(Invoker.Arguments[0]));
                else
                    Invoker.context.SetStrategy(new XMLExporter(Invoker.Arguments[0]));
            }
            catch (Exception e) {
                Console.WriteLine($"Error(Load): [{e.Message}]");
            }
            Invoker.context.DoStrategy();
        }

        private static void Backup(ICommand command) {
            //We first initialize the current state and command. The new state replaces them
            if(CurrentState != null && CurrentCommand != null) {
                Invoker.UndoMementoStack.Push(CurrentState);
                UndoCommandStack.Push(CurrentCommand);
            }
            initCurrent(command);
        }

        public static void Undo() {
            if (UndoMementoStack.Count == 0) {
                Console.WriteLine("No undoable command left!");
                return;
            }

            RedoCommandStack.Push(CurrentCommand);
            RedoMementoStack.Push(CurrentState);

            IMemento memento = Invoker.UndoMementoStack.Pop();
            ICommand command = Invoker.UndoCommandStack.Pop();
            command.GetOriginator().Restore(memento);
            initCurrent(command);

            //to handle the copy of the same object
            if(RedoMementoStack.Count > 0 && UndoMementoStack.Count != 0) {
                RedoCommandStack.Push(CurrentCommand);
                RedoMementoStack.Push(CurrentState);

                memento = Invoker.UndoMementoStack.Pop();
                command = Invoker.UndoCommandStack.Pop();
                command.GetOriginator().Restore(memento);
                initCurrent(command);
            }
            
        }
        public static void Redo() {
            if (RedoMementoStack.Count == 0) {
                Console.WriteLine("No redoable command left!");
                return;
            }
            UndoCommandStack.Push(CurrentCommand);
            UndoMementoStack.Push(CurrentState);

            IMemento memento = Invoker.RedoMementoStack.Pop();
            ICommand command = Invoker.RedoCommandStack.Pop();
            command.GetOriginator().Restore(memento);
            initCurrent(command);

            //to handle the copy of the same object
            if (UndoMementoStack.Count > 0 && RedoMementoStack.Count != 0) {
                UndoCommandStack.Push(CurrentCommand);
                UndoMementoStack.Push(CurrentState);

                memento = Invoker.RedoMementoStack.Pop();
                command = Invoker.RedoCommandStack.Pop();
                command.GetOriginator().Restore(memento);
                initCurrent(command);
            }
        }

        public static void InitialStateBackup(ICommand command) {
            if (command.GetType() == typeof(EditCommand) || command.GetType() == typeof(DeleteCommand)
                || command.GetType() == typeof(AddCommand)) {
                Invoker.Backup(command);
            }
        }

        private static void initCurrent(ICommand command) {
            CurrentCommand = null;
            CurrentState = null;
            CurrentCommand = command;
            CurrentState = CurrentCommand.GetOriginator().Save();
        }


        //LEGACY ROUTINES
        public static void Commit() {
            if (Invoker.CommandQueue == null)
                return;
            foreach (var command in CommandQueue) {
                command.Execute();
            }
        }
        public static void Dismiss() {
            Invoker.CommandQueue?.Clear();
        }
        public static void AddCommand(ICommand command) {
            if (CommandQueue == null) {
                Invoker.CommandQueue = new Queue<ICommand>();
            }
            CommandQueue.Enqueue(command);
        }
    }
}
