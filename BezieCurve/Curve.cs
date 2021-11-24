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
        List<float> distances;
        List<float> ts;

        public Curve()
        {
            distances = new List<float>();
            points = new List<Vector2f>();
            ts = new List<float>();
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
            Vector2f pos = GetPoint(0f), lastPos;
            float l = 0f;
            distances = new List<float>();

            for (float i = 0; i <= 1; i += step)
            {
                lastPos = pos;
                pos = GetPoint(i);
                l += lastPos.Distanse(pos);
                distances.Add(l);
            }

            Font f = new Font("OpenSans-Regular.ttf");

            Text t = new Text("" + l, f);
            rw.Draw(t);

            for(float i = 0f; i < l; i += 5)
            {
                for(int j = 1; j < distances.Count; j++)
                {
                    if(distances[j] > i)
                    {
                        float ratio =  (i - distances[j - 1]) / (distances[j] - distances[j - 1]);
                        cs = new CircleShape(6);
                        cs.Position = GetPoint((j-1)*step + (step*ratio)) + new Vector2f(-3, -3);
                        rw.Draw(cs);
                        break;
                    }
                }
            }

            if (drawPoints)
            {
                foreach (Vector2f point in points)
                {
                    cs = new CircleShape(10);
                    cs.Position = point + new Vector2f(-5, -5);
                    cs.FillColor = Color.Blue;
                    rw.Draw(cs);
                }
            }
        }

        public void MouseMoved(Vector2f pos)
        {
            if (pinned >= 0)
            {
                points[pinned] = pos + new Vector2f(-5, -5);
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
