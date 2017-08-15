using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.OracleClient
{
    public class PersonCard
    {
        public static string NewPersonCard()
        {
            Random rnd;
            string[] _crabodistrict = new string[] { "350201", "350202", "350203", "350204", "350205", "350206", "350211", "350205", "350213" };

            rnd = new Random(System.DateTime.Now.Millisecond);

            //PIN = District + Year(50-92) + Month(01-12) + Date(01-30) + Seq(001-600)
            string _pinCode = string.Format("{0}19{1}{2:00}{3:00}{4:000}", _crabodistrict[rnd.Next(0, 8)], rnd.Next(50, 92), rnd.Next(1, 12), rnd.Next(1, 30), rnd.Next(1, 600));
            #region Verify
            char[] _chrPinCode = _pinCode.ToCharArray();
            //校验码字符值
            char[] _chrVerify = new char[] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
            //i----表示号码字符从由至左包括校验码在内的位置序号；
            //ai----表示第i位置上的号码字符值；
            //Wi----示第i位置上的加权因子，其数值依据公式intWeight=2（n-1）(mod 11)计算得出。
            int[] _intWeight = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };
            int _craboWeight = 0;
            for (int i = 0; i < 17; i++)//从1 到 17 位,18为要生成的验证码
            {
                _craboWeight = _craboWeight + Convert.ToUInt16(_chrPinCode[i].ToString()) * _intWeight[i];
            }
            _craboWeight = _craboWeight % 11;
            _pinCode += _chrVerify[_craboWeight];
            #endregion
            return _pinCode;
        }
    }
}
