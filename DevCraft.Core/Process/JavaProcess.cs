using System;

namespace DevCraft.Core.Process
{
    public class JavaProcess : ProcessBase
    {
        private readonly string _jarName;

        public JavaProcess(string jarName, string workingDirectory)
            : base("java.exe", workingDirectory)
        {
            if (string.IsNullOrWhiteSpace(jarName)) throw new ArgumentException(string.Format("JAR Name is not valid: {0}", jarName));

            _jarName = jarName;
        }

        protected override string GetArguments()
        {
            return string.Format("-Xmx1024M -Xms1024M -jar {0} nogui", _jarName);
        }
    }
}