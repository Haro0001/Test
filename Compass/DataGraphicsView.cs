using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Compass02
{
    internal class DataGraphicsView : GraphicsView
    {
        public DataDrawble DataDrawble = new DataDrawble();
        public DataGraphicsView()
        {
            Drawable = DataDrawble;
        }
        public void AddData(Vector3 data)
        {
            this.DataDrawble.drawData.Add(data);
        }
    }
}
