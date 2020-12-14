using PostSharp.Aspects;
using System;
using System.Diagnostics;
using System.IO;

namespace Aircash.Utils.AOP
{
    [Serializable]
    public class LoggerAspect : OnMethodBoundaryAspect
    {
        private Guid _methodCallIdentifier;
        private string filePath = @"C:\Log\Log.txt";

        public override void OnEntry(MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();

            Debug.WriteLine("{0} - Entering method {1} with arguments: {2}",
                _methodCallIdentifier,
                args.Method.Name,
                string.Join(", ", args.Arguments));


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Method entry :" + args.Method.Name + Environment.NewLine + "Arguments :" + string.Join(", ", args.Arguments) +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Debug.WriteLine("{0} - Exited method {1}",
                _methodCallIdentifier,
                args.Method.Name);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Method exit :" + args.Method.Name +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Debug.WriteLine("{0} - Date time: {1} - Method {2} raised exception with message: {3}{4}{5}",
                _methodCallIdentifier,
                DateTime.Now,
                args.Method.Name,
                args.Exception.Message,
                Environment.NewLine,
                args.Exception.StackTrace);


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Message :" + args.Exception.Message + Environment.NewLine + "StackTrace :" + args.Exception.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }


    }
}