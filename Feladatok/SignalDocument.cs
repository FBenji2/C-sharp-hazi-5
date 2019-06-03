using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalDocument : Document
    {
        private List<SignalValue> signals = new List<SignalValue>();

        private SignalValue[] testValues = new SignalValue[]
            {
                 new SignalValue(10, new DateTime(2017, 1, 1, 1, 1, 1, 123)),
                 new SignalValue(20, new DateTime(2017, 1, 1, 1, 1, 2, 456)),
                 new SignalValue(30, new DateTime(2017, 1, 1, 1, 1, 3, 789)),
                 new SignalValue(10, new DateTime(2017, 1, 1, 1, 1, 4, 101)),
                 new SignalValue(-10, new DateTime(2017, 1, 1, 1, 1, 5, 112)),
                 new SignalValue(-19, new DateTime(2017, 1, 1, 1, 1, 6, 131))
            };

        public IReadOnlyList<SignalValue> Signals
        {
            get { return signals; }
        }

        public SignalDocument(string name) 
            : base(name)
        {
            signals.AddRange(testValues);
        }

        public override void SaveDocument(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (SignalValue v in signals)
                {
                    string dt = v.TimeStamp.ToUniversalTime().ToString("o");
                    sw.WriteLine(v.Value + "\t" + dt + '\n');
                }

            }
        }

        public override void LoadDocument(string filePath)
        {
            signals.Clear();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() != "") //ha ures kihagyjuk
                    {
                        string[] columns = line.Split('\t');
                        double d = double.Parse(columns[0]);
                        DateTime dt = DateTime.Parse(columns[1]);
                        DateTime localDt = dt.ToLocalTime();
                        signals.Add(new SignalValue(d, localDt));
                    }

                }
            }
            TraceValues();
            UpdateAllViews();
        }

        void TraceValues()
        {
            foreach (SignalValue signal in signals)
                Trace.WriteLine(signal.ToString());
        }
    }
}
