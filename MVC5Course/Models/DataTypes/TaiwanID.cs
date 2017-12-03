using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC5Course.Models.DataTypes
{
    public class TaiwanID : DataTypeAttribute
    {
        public TaiwanID() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string user_id = value.ToString();
            int[] uid = new int[10];    //數字陣列存放身分證字號用
            int chkTotal;               //計算總和用
            Regex reg = new Regex("[a-zA-Z]{1}\\d{9}");
            bool result = true;

            if (!reg.IsMatch(user_id))    // 檢查組成是否為 英文(1)+數字(9)
            {
                result = false;
            }
            else
            {
                user_id = user_id.ToUpper();    //將身分證字號英文改為大寫

                //將輸入的值存入陣列中
                for (int i = 1; i < user_id.Length; i++)
                {
                    uid[i] = Convert.ToInt32(user_id.Substring(i, 1));
                }
                //將開頭字母轉換為對應的數值
                switch (user_id.Substring(0, 1).ToUpper())
                {
                    case "A": uid[0] = 10; break;
                    case "B": uid[0] = 11; break;
                    case "C": uid[0] = 12; break;
                    case "D": uid[0] = 13; break;
                    case "E": uid[0] = 14; break;
                    case "F": uid[0] = 15; break;
                    case "G": uid[0] = 16; break;
                    case "H": uid[0] = 17; break;
                    case "I": uid[0] = 34; break;
                    case "J": uid[0] = 18; break;
                    case "K": uid[0] = 19; break;
                    case "L": uid[0] = 20; break;
                    case "M": uid[0] = 21; break;
                    case "N": uid[0] = 22; break;
                    case "O": uid[0] = 35; break;
                    case "P": uid[0] = 23; break;
                    case "Q": uid[0] = 24; break;
                    case "R": uid[0] = 25; break;
                    case "S": uid[0] = 26; break;
                    case "T": uid[0] = 27; break;
                    case "U": uid[0] = 28; break;
                    case "V": uid[0] = 29; break;
                    case "W": uid[0] = 32; break;
                    case "X": uid[0] = 30; break;
                    case "Y": uid[0] = 31; break;
                    case "Z": uid[0] = 33; break;
                }
                //檢查第一個數值是否為1.2(判斷性別)
                if (!(uid[1] == 1 || uid[1] == 2))
                {
                    result = false;
                }
                else
                {
                    chkTotal = (uid[0] / 10 * 1) + (uid[0] % 10 * 9);

                    int k = 8;
                    for (int j = 1; j < 9; j++)
                    {
                        chkTotal += uid[j] * k;
                        k--;
                    }

                    chkTotal += uid[9];

                    if (chkTotal % 10 != 0)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}