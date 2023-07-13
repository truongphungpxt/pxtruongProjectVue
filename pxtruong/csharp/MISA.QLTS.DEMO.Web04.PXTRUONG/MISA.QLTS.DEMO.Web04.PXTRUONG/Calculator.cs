namespace MISA.QLTS.DEMO.Web04.PXTRUONG
{
    /// <summary>
    /// Lớp cộng trừ nhân chia 
    /// Create: pxtruong(9/6/2023)
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng 2 số nguyên
        /// </summary>
        /// <param name="a">Số hạng 1</param>
        /// <param name="b"> Số hạng 2</param>
        /// <returns> Tổng của 2 số</returns>
        /// Create by: pxtruong(9/6/2023)
        public  long Add(int a, int b)
        {
            return (long)a+b;

        }
        /// <summary>
        /// Hàm trừ 2 số nguyên
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// Create by: pxtruong(9/6/2023)
        /// <returns> Hiệu của 2 số</returns>
        public long Sub(int a, int b)
        {
            return (long)a - b;
        }
        /// <summary>
        /// Hàm nhân 2 số nguyên
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// Create by: pxtruong(9/6/2023)
        /// <exception cref="NotImplementedException"></exception>
         public long Mul(int a, int b)
        {
           return (long)a*b;
        }
        /// <summary>
        /// Hàm chia 2 số nguyên
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// Create by: pxtruong(9/6/2023)
        /// <exception cref="NotImplementedException"></exception>
        public double Div(int a, int b)
        {
            if (b==0)
            {
                throw new Exception("Không chia cho 0");
            }
            return (double)a/b;
        }
    }
}
