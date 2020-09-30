using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Utils
{
    public class Common
    {
        public static Color GetRandomColor()
        {
            var randomNumFirst = new Random(Guid.NewGuid()
                                                .GetHashCode());

            var randomNumSencond = new Random(Guid.NewGuid()
                                                  .GetHashCode());

            //为了在白色背景上显示，尽量生成深色
            var R = randomNumFirst.Next(256);
            var G = randomNumSencond.Next(256);

            var B = R + G > 400
                        ? 0
                        : 400 - R - G;

            B = B > 255
                    ? 255
                    : B;

            return Color.FromArgb(R, G, B);
        }


    }
}
