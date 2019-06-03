using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Signals
{
    public partial class GraphicsSignalView : UserControl, IView
    {
        private SignalDocument document;
        private int viewNumber;
        float pixelPerSec = 100; //számok hasraütésszerűen, ezzel jól néz ki az ábrázolás
        int pixelPerValue = 5;
        double zoom = 1;

        public GraphicsSignalView()
        {
            InitializeComponent();
        }

        public GraphicsSignalView(SignalDocument document)
        {
            InitializeComponent();
            this.document = document;
        }

        public Document GetDocument()
        {
            return document;
        }

        public int ViewNumber
        {
            get { return viewNumber; }
            set { viewNumber = value; }
        }

        protected override void OnPaint(PaintEventArgs e) //felülírjuk a függvényt a rajzoláshoz
        {
            base.OnPaint(e); //meg kell hívni az őst

            Pen pen = new Pen(Color.Red, 1);
            pen.DashStyle = DashStyle.Dash;
            pen.EndCap = LineCap.ArrowAnchor;
            e.Graphics.DrawLine(pen, 0, ClientSize.Height, 0, 0);
            e.Graphics.DrawLine(pen, 0, ClientSize.Height / 2, ClientSize.Width, ClientSize.Height / 2);
            
            //az előző pár sorban rajzoltuk fel szaggatott pirossal a tengelyeket
            bool firstvalue = true;
            SignalValue prevsignal = null;
            float x1 = 0, y1 = 0, x2 = 0, y2;
            //végigmegyünk az adatainkon és a mostani és előző jel alapján fogjuk kirajzolni a vonalat, és a pontokat
            foreach (SignalValue currentsignal in document.Signals)
            {
                y2 = (float)-(currentsignal.Value * pixelPerValue * zoom) + (ClientSize.Height / 2); //megmondjuk, hogy milyen magasan legyen a vonal "vége"
                if (firstvalue)
                {
                    firstvalue = false; //figyelünk arra, hogy a feladat alapján az első elem az különleges, tehát az x2-t nem változtatjuk
                }
                else
                {
                    x2 += (float)(((currentsignal.TimeStamp.Ticks - prevsignal.TimeStamp.Ticks) / 10000000) * pixelPerSec * zoom); //elemenként csúsztatunk jobbra a négyzetek és "vonalvégek" kirajzolásánál
                    e.Graphics.DrawLine(new Pen(Color.Blue, 3), x1, y1, x2, y2); //kékkel berajzoljuk a vonalat a kiszámolt koordináták alapján
                }
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new RectangleF(x2, y2, 5, 5)); //majd a vonalak elejéhez be is rajzoljuk a kis négyzeteket
                prevsignal = currentsignal; //a végpontok számolásához el kell tárolnunk az előző jelet is
                x1 = x2; //és mivel tudjuk, hogy egy adott vonal végpontja a következő kezdőpontja lesz, ezért
                y1 = y2; //ezeket az adatokat átcseréljük
            }

        }

        private void BPlusZoom_Click(object sender, EventArgs e)
        {
            zoom *= 1.2;
            Invalidate();
        }

        private void BMinuszoom_Click(object sender, EventArgs e)
        {
            zoom /= 1.2;
            Invalidate();
        }
    }
}
