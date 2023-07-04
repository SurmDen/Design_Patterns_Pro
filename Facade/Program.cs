using System;

namespace Facade
{
    public class TextEditor
    {
        public void WriteCode()
        {
            Console.WriteLine("Write code");
        }

        public void SaveCode()
        {
            Console.WriteLine("Save the text of the code");
        }
    }

    public class CLR
    {
        public void Run()
        {
            Console.WriteLine("Run CLR");
        }

        public void JITCompilerRun()
        {
            Console.WriteLine("JIT compiler working");
        }

        public void Execute()
        {
            Console.WriteLine("CLR is executing machine commands");
        }

        public void Stop()
        {
            Console.WriteLine("CLR stop the work, garbage is cleaned, threads are stopped");
        }
    }

    public class VisualStudioFacade
    {
        private TextEditor textEditor;
        private CLR CLR;

        public VisualStudioFacade(TextEditor editor, CLR cLR)
        {
            textEditor = editor;
            CLR = cLR;
        }

        public void Run()
        {
            textEditor.WriteCode();
            textEditor.SaveCode();
            CLR.Run();
            CLR.JITCompilerRun();
            CLR.Execute();
        }

        public void Stop()
        {
            CLR.Stop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade(new SubsystemA(), new SubsystemB(), new SubsystemC());

            //we call first operation(in real it much more difficult)
            facade.FirstOperation();
            //...
            facade.SecondOperation();

            Console.WriteLine();

            VisualStudioFacade programm = new VisualStudioFacade(new TextEditor(), new CLR());

            programm.Run();
            programm.Stop();

            Console.ReadLine();
        }
    }
}
