namespace Lecture7.Model
{
    public interface ICustomAction
    {
        string PluginName { get; }

        void Run();
    }
}
