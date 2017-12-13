using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testsite.BizLogic
{
    public class Point:IDisposable
    {
        string _twitterId;
        string _name;
        string _office;
        int _repeatCount;
        int _seed;
        public Point(string TwitterId,string Name,string Office,int RepeatCount)
        {
            _twitterId =TwitterId;
            _name=Name;
            _office= Office;
            _repeatCount= RepeatCount;
            _seed = Environment.TickCount;
        }
        public int GetFamousPoint()
        {
            Random cRandom = new System.Random(_seed + _repeatCount);
            var score = cRandom.Next(999);
            return score;
        }

        public int GetSkillPoint()
        {
            Random cRandom = new System.Random(_seed + _repeatCount +1);
            var score = cRandom.Next(999);
            return score;
        }

        public void Dispose()
        {

        }

    }
}
