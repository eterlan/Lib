using UnityEngine;

namespace Lib
{
    public static class MathUtil
    {
        /// <summary>
        /// 重映射. 从a区间映射到b区间
        /// </summary>
        /// <param name="x">输入值</param>
        /// <param name="rangeL1">原始最小值</param>
        /// <param name="rangeR1">原始最大值</param>
        /// <param name="rangeL2">映射范围最小值</param>
        /// <param name="rangeR2">映射范围最大值</param>
        /// <returns></returns>
        public static float Remap(float x, float rangeL1, float rangeR1, float rangeL2, float rangeR2)
        {
            var clampX = ClampAuto(x, rangeL1, rangeR1);
            var result = (clampX - rangeL1) / (rangeR1 - rangeL1) * (rangeR2 - rangeL2) + rangeL2;
            return result;
        }

        /// <summary>
        /// 自动判断大小
        /// </summary>
        /// <returns></returns>
        public static float ClampAuto(float x, float a, float b)
        {
            var min = a;
            var max = b;
            if (a > b)
            {
                min = b;
                max = a;
            }

            return Mathf.Clamp(x, min, max);
        }

        public static Vector2Int RoundVector2(Vector2 input)
        {
            return new Vector2Int(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y));
        }
    }
}