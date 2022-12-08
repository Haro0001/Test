using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Compass02
{
    internal class DataDrawble : IDrawable
    {
        public ArrayList drawData = new();
        public float x = 0;
        public float y = 0;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (drawData.Count == 0)
                return;
            canvas.DrawCircle(200 *(1 - x),250 + 400 * y, 15);
            int cnt = drawData.Count;
            for (int i = 0; i < cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                x = data.X;
                y = data.Y;
            }
        }
    }
}
