using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming phone call!!...");
            if (OnRing != null)
            {
                OnRing();
            }
        }
    }
    class RingTonePlayer
    {
        public void PlayTone()
        {
            Console.WriteLine("PLaying the ringtone!!!...");

        }
    }
    class ScreenDisplay
    {
        public void ShowCallerInformation()
        {
            Console.WriteLine("Displaying caller information on the screen!!!...");
        }
    }
    class vibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("The mobile phone is vibrating!!!...");
        }
    }

    class PhoneRing
    {
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone();
            RingTonePlayer ringTonePlayer = new RingTonePlayer();
            ScreenDisplay screenDisplay = new ScreenDisplay();
            vibrationMotor vibrationMotor = new vibrationMotor();
            phone.OnRing += ringTonePlayer.PlayTone;
            phone.OnRing += screenDisplay.ShowCallerInformation;
            phone.OnRing += vibrationMotor.Vibrate;
            phone.ReceiveCall();
        }

    }
}

