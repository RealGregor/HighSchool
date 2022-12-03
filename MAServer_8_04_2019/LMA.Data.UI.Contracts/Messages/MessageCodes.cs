using System;
using System.Collections.Generic;
using System.Text;

namespace LMA.Data.UI.ViewModels.Messages
{
    public static class MessageCodes
    {
        public static Dictionary<int, string> dictionary = new Dictionary<int, string>
        {
            {0, "No message"},
            {1, "Tenant does not exist"},
            {2, "Šifra avto dela je napisana v napačni obliki."},
            {3, "Success"},
            {4, "User with given email does not exist"},
            {5, "No informations were given"},
			{6, "Could not read your data from database"},
			{7, "New status is equal to old status"},
			{8, "Minimal time for status available not reached"},
			{9, "You reached your limit for unavailability"},
			{10, "Current password is incorrect"},
			{11, "Password changed successfully"},
			{12, "You need to confirm your email first.\nWe sent a confirmation link to your email address"},
			{13, "Password is incorrect"},
			{14, "User does not exist"},
			{15, "You are not member of any group"},
			{16, "Wrong request"},
			{17, "Wrong email"},
			{18, "You already are in requested group"},
			{19, "Invite already exists"},
			{20, "You can not add this user to group without invite"},
			{21, "User was successfully added to group"},
			{22, "Permission denied"},
			{23, "Group was successfully deleted"},
			{24, "User is not a memeber of this group"},
			{25, "User was uccessfully deleted from group"},
			{26, "Group does not exist"},
			{27, "Invite does not exists"},
			{28, "Tenant not found"},
			{29, "User was successfully added to group"},
			{30, "Invite already exists"},
			{31, "MaxDayUnavailableTime invalid"},
			{32, "MaxSingleUnavailableTime invalid"},
			{33, "MinSingleAvailableTime invalid"},
			{34, "Only user with role 'Master' has permission to create new tenant"},
			{35, "Only user with role 'Master' has permission to delete tenant"},
			{36, "Only user with role 'Master' has permission to set tenant data"}
        };
    }
}
