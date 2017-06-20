using System.Diagnostics;

namespace Plor_V4
{
    class Launcher
    {
        //Launch:
        public void launch(string path)
        {
            Process.Start(path);
        }
    }
}