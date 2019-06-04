using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models.Annotations
{
    public class MyStatusAttribute : ValidationAttribute
    {
        //массив для хранения допустимых статусов
        private static string[] myStatus;

        public MyStatusAttribute(string[] Status)
        {
            myStatus = Status;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < myStatus.Length; i++)
                {
                    if (strval == myStatus[i])
                        return true;
                }
            }
            return false;
        }
    }
}