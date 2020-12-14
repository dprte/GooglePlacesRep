using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Aircash.Utils.AOP
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class TimingAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        Stopwatch _StopWatch;
        private string filePath = @"C:\Log\Log.txt";
        private Guid _methodCallIdentifier;

        public override void OnEntry(PostSharp.Aspects.MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();
            _StopWatch = Stopwatch.StartNew();
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Timer started on method: " + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
            base.OnEntry(args);
        }

        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();

            Debug.WriteLine(string.Format("[{0}] took {1}ms to execute",
              new StackTrace().GetFrame(1).GetMethod().Name,
                _StopWatch.ElapsedMilliseconds));

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Timer execute on method :" + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString() + " " + "Time: " + string.Format("[{0}] took {1}ms to execute",
              new StackTrace().GetFrame(1).GetMethod().Name,
                _StopWatch.ElapsedMilliseconds));
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
            base.OnExit(args);
        }
    }
}
