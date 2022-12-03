using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeaveMeAlone
{
    public static class _MainErrorMessageHandler
    {
        private static formMain MainForm;

        public static void SetMainForm(formMain mainForm)
        {
            MainForm = mainForm;
        }
        public static void RecieveError(int errorStatusCode)
        {
            switch (errorStatusCode)
            {
                case 400: Error400(); break;
                case 401: Error401(); break;
                case 403: Error403(); break;
                case 404: Error404(); break;
                case 427: Error427(); break;
                case 440: Error440(); break;
                case 500: Error500(); break;
                case 502: Error502(); break;
                case 503: Error503(); break;
                case 504: Error503(); break;
                case 507: Error507(); break;

                default: MessageBox.Show("" + errorStatusCode); break;
            }
        }



        //client errors
        private static void Error400()
        {//Bad Request

        }
        private static void Error401()//Unauthorized
        {

        }
        private static void Error403()//Forbidden
        {

        }
        private static void Error404()//Not Found
        {

        }
        private static void Error427()//too many requests
        {

        }
        private static void Error440()//Login Timeout
        {

        }


        //server errors
        private static void Error500()//Internal Server Error
        {

        }
        private static void Error502()//Bad Gateway
        {

        }
        private static void Error503()//Service Unavaliable
        {

        }
        private static void Error504()//Gateway Timeout
        {

        }
        private static void Error507()//Insufficient Storage
        {

        }
    }
}
