using System;
using System.Text;
using System.Text.RegularExpressions;

namespace advt.Common
{
    public class TypeConverter
    {

        /// <summary>
        /// ������ת��ΪInt32����
        /// </summary>
        /// <param name="expression">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(object expression, int defValue)
        {
            return TypeConverter.ObjectToInt(expression, defValue);
        }

        /// <summary>
        /// Object ת���� Guid
        /// </summary>
        /// <param name="ObjValue">ObjValue</param>
        /// <returns></returns>
        public static Guid ObjectToGuid(Object ObjValue)
        {
            return StrToGuid(ObjValue.ToString());
        }
        /// <summary>
        /// string ת���� Guid
        /// </summary>
        /// <param name="strValue">string</param>
        /// <returns></returns>
        public static Guid StrToGuid(string strValue)
        {
            try
            {
                return new Guid(strValue);
            }
            catch
            {
                return new Guid();
            }

        }

        /// <summary>
        /// int��ת��Ϊstring��
        /// </summary>
        /// <returns>ת�����string���ͽ��</returns>
        public static string IntToStr(int intValue)
        {
            return Convert.ToString(intValue);
        }

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ObjToBool(object expression)
        {
            return ObjToBool(expression, false);
        }

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ObjToBool(object expression, bool defValue)
        {
            if (expression != null)
                return ObjToBool(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool ObjToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                    return true;
                else if (string.Compare(expression, "false", true) == 0)
                    return false;
            }
            return defValue;
        }

        /// <summary>
        /// ������ת��ΪInt32����,Ĭ��ֵΪ 0
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        /// <summary>
        /// ������ת��ΪInt32����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string��ת��ΪDecimal��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static decimal StrToDecimal(object strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToDecimal(strValue.ToString(), 0);
        }

        /// <summary>
        /// string��ת��ΪDecimal��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static decimal StrToDecimal(string strValue, decimal defValue)
        {
            var intValue = defValue;
            var IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
            if (IsFloat)
                decimal.TryParse(strValue, out intValue);
            return intValue;
        }

        /// <summary>
        /// ������ת��ΪInt32����,ת��ʧ�ܷ���0
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        /// <summary>
        /// ������ת��ΪInt32����
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(string str, int defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;

            return Convert.ToInt32(StrToFloat(str, defValue));
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float ObjectToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float StrToFloat(object strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                    float.TryParse(strValue, out intValue);
            }
            return intValue;
        }

        /// <summary>
        /// ������ת��Ϊ����ʱ������
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dateTime;
                if (DateTime.TryParse(str, out dateTime))
                    return dateTime;
            }
            return defValue;
        }

        /// <summary>
        /// ������ת��Ϊ����ʱ������
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }

        /// <summary>
        /// ������ת��Ϊ����ʱ������
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static DateTime ObjectToDateTime(object obj)
        {
            return StrToDateTime(obj.ToString());
        }

        /// <summary>
        /// ������ת��Ϊ����ʱ������
        /// </summary>
        /// <param name="obj">Ҫת���Ķ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StrToDateTime(obj.ToString(), defValue);
        }
    }
}
