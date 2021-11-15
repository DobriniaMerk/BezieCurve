using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace BezieCurve
{
    class Curve
    {
        public List<Vector2f> points;
        float step = 0.01f;
        int pinned = -1;

        public Curve()
        {
            points = new List<Vector2f>();
        }

        public void AddPoint(float x, float y)
        {
            points.Add(new Vector2f(x, y));
        }

        public Vector2f GetPoint(float t, List<Vector2f> p = null)
        {
            if (p == null)
                p = points;

            if(p.Count == 2)
            {
                return ((p[1] - p[0]) * t) + p[0];
            }
            else
            {
                List<Vector2f> ret = new List<Vector2f>();
                for(int i = 0; i < p.Count - 1; i++)
                {
                    List<Vector2f> r = new List<Vector2f>();
                    r.Add(p[i]);
                    r.Add(p[i + 1]);
                    ret.Add(GetPoint(t, r));
                }
                return GetPoint(t, ret);
            }
        }

        public void Draw(RenderWindow rw, bool drawPoints)
        {
            CircleShape cs;
            for (float i = 0f; i <= 1; i += step)
            {
                Vector2f pos = GetPoint(i);
                cs = new CircleShape(5);
                cs.Position = pos + new Vector2f(-2.5f, -2.5f);
                rw.Draw(cs);
            }

            if(drawPoints)
                foreach (Vector2f point in points)
                {
                    cs = new CircleShape(10);
                    cs.Position = point + new Vector2f(-5, -5);
                    cs.FillColor = Color.Blue;
                    rw.Draw(cs);
                }
        }

        public void MouseMoved(Vector2f pos)
        {
            if (pinned >= 0)
            {
                points[pinned] = pos;
            }
        }

        public void MousePressed(Vector2f pos)
        {
            for(int i = 0; i < points.Count; i++)
            {
                if (pos.Distanse(points[i]) <= 20)
                {
                    pinned = i;
                    return;
                }
            }

            pinned = -1;
        }

        public void MouseReleased()
        {
            pinned = -1;
        }
    }
}
