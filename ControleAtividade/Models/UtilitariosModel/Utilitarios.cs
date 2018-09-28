using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ControleAtividade.Models.UtilitariosModel
{
    public class Utilitarios
    {
        public static string RemoverFormatacaoCPF(string CPF)
        {
            return CPF.Replace(".", string.Empty).Replace("-", string.Empty);
        }

        public static string IncluirFormatacaoCPF(string CPF)
        {
                return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static class Enumerados
        {
            public static string GetEnumDescription(Enum en)
            {
                Type type = en.GetType();

                MemberInfo[] memInfo = type.GetMember(en.ToString());

                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }

                return en.ToString();
            }
        }

    }
}
