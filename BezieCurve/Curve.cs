using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace BezieCurve
{
    class Curve
    {
        List<Vector2f> points;

        public Curve()
        {
            points = new List<Vector2f>();
        }

        public void AddPoint(Vector2f pos)
        {
            points.Add(pos);
        }

        Vector2f getPoint(float t, List<Vector2f> p)
        {
            if(p.Count == 2)
            {
                return (p[1] - p[0]) * t;
            }
            else
            {
                List<Vector2f> ret = new List<Vector2f>();
                for(int i = 0; i < p.Count - 1; i++)
                {
                    List<Vector2f> r = new List<Vector2f>();
                    r.Add(p[i]);
                    r.Add(p[i + 1]);
                    ret.Add(getPoint(t, r));
                }
                return getPoint(t, ret);
            }
        }
    }
}
