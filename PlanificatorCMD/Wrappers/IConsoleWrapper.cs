namespace PlanificatorCMD.Wrappers
{
    public interface IConsoleWrapper
    {
        void Write(string str);
        void WriteLine();
        void WriteLine(string str);
    }
}