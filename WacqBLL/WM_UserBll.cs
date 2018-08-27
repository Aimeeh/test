using HandleModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using WacqAbsFactory;
using WacqIBLL;

namespace WacqBLL
{
    public class WM_UserBll:BaseBLL<WM_User>,IWM_UserBLL
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool GetUserObjCheck(string UserID, string PassWord,out string backMsg)
        {
            backMsg = "";
            //加载操作表格对象
            AbsFacory absfact = AbsFacory.CreatInstance();
            //加载用户表
            IWM_UserBLL iusbll = absfact.CreatIWM_UserBllInstance();
            //根据登录账号得到用户对象
            var obj = iusbll.Query(p => p.Account == UserID).FirstOrDefault();
            //判断是不是超级管理员系统账户
            if (UserID== ConfigHelper.AppSettings("CurrentUserName"))
            {
                if (Md5Helper.MD5(DESEncrypt.Encrypt(PassWord.ToLower(), Md5Helper.GetMD5Code()).ToLower(), 32).ToLower()== ConfigHelper.AppSettings("CurrentPassword"))
                {
                    backMsg = "";
                    return true;
                }
                else
                {
                    backMsg = "密码错误!";
                }
            }
            else
            {
                if (obj != null)
                {
                    //验证用户填写密码是否与数据库密码一致
                    string passWord = obj.Password;
                    if (Md5Helper.MD5(DESEncrypt.Encrypt(PassWord.ToLower(), Md5Helper.GetMD5Code()).ToLower(), 32).ToLower() == passWord)
                    {
                        backMsg = obj.CompanyID;
                        return true;
                    }
                    else
                    {
                        backMsg = "密码错误!";
                    }
                }
                else
                {
                    backMsg = "用户或密码错误!";
                }
            }
            return false;
        }
    }
}
